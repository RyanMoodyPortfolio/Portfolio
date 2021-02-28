using System;
using System.Xml;
using System.Xml.Schema;
using System.Collections;

class Flowchart
{
    // Member variables

    private static Flowchart m_Flowchart;
    private static ArrayList m_Nodes;

    // Singleton Constructor

    public static Flowchart getFlowchart()
    {
        if (m_Flowchart == null)
        {
            m_Flowchart = new Flowchart();
            m_Nodes = new ArrayList();
        }

        return m_Flowchart;
    }

    public Node findNode(string strID)
    {
        // Finds and returns the node in the flowchart with the given ID

        foreach (Node node in m_Nodes)
        {
            if (node.getID() == strID)
            {
                // Found node
                return node;
            }
        }

        // Node not found
        return null;
    }

    private void findReachableNodes(Node node)
    {
        // Recursively find all nodes that can be reached via the given node's decisions

        foreach (Decision decision in node.getDecisions())
        {
            // Get the node reached by a decision
            Node reachedNode = findNode(decision.getIDreference());

            // Only consider nodes that have not been previously 
            // reached to prevent infinite recursion
            if (!reachedNode.isReachedFromStartNode())
            {
                // State that this node can be reached from the start node
                reachedNode.wasReachedFromStartNode();

                // Recursively find the nodes that this node reaches
                findReachableNodes(reachedNode);
            }
        }
    }

    public void Load(string strFile)
    {
        // Loads an XML flowchart file

        checkFlowchartSatisfiesDTD(strFile);
        StoreFlowchart(strFile);
        checkHasStartNode();
        checkReferencedNodesExist();
        checkAllNodesReachableFromStartNode();
    }

    private void StoreFlowchart(string strFile)
    {
        // Stores a flowchart internally. This means that the XML document
        // containing the flowchart only needs to be accessed and validated once.

        // Remove existing flowchart nodes
        m_Nodes.Clear();

        // Load the XML representation of the flowchart 
        XmlDocument document = new XmlDocument();
        document.Load(strFile);
        XmlNode flowchart = document.DocumentElement;

        foreach (XmlNode node in flowchart.ChildNodes)
        {
            // Get node data
            string strID = node.Attributes["ID"].Value;
            checkNotDuplicateID(strID);
            string strInformation = node.Attributes["information"].Value;
            
            // Create a node from this data
            Node newNode = new Node(strID, strInformation);

            foreach (XmlNode decision in node.ChildNodes)
            {
                // Get decision data
                string strIDreference = decision.Attributes["IDreference"].Value;
                checkNotSelfReferencingID(strID, strIDreference);
                string strDescription = decision.Attributes["description"].Value;

                // Create a decision from this data
                Decision newDecision = new Decision(strIDreference, strDescription);

                // Add the decision to the node
                newNode.addDecision(newDecision);
            }

            // If a node represents an end to the flowchart,
            // then allow the user to restart the flowchart
            if (node.ChildNodes.Count == 0)
            {
                newNode.addDecision(new Decision("start", "Restart"));
            }

            // Add the node to the flowchart
            m_Nodes.Add(newNode);
        }
    }

    private void checkNotDuplicateID(string strID)
    {
        // Throws an exception if a flowchart has duplicate node IDs

        if (findNode(strID) != null)
        {
            throw new Exception("Flowchart has more than one node with ID \"" + strID + "\"");
        }
    }

    private void checkNotSelfReferencingID(string strID, string strIDreference)
    {
        // Throws an exception if a flowchart has any self referencing nodes

        if (strID == strIDreference)
        {
            throw new Exception("Flowchart node \"" + strID + "\" is self referencing");
        }
    }

    private void checkHasStartNode()
    {
        // Throws an exception if a flowchart does not have a start node

        if (findNode("start") == null)
        {
            throw new Exception("Flowchart does not have a start node");
        }
    }

    private void checkAllNodesReachableFromStartNode()
    {
        // Finds all nodes that are reachable from the start node
        findReachableNodes(findNode("start"));

        foreach (Node node in m_Nodes)
        {
            // Throws an exception if a flowchart has any nodes 
            // that are not reachable from the start node

            if (!node.isReachedFromStartNode())
            {
                throw new Exception("Flowchart contains unreachable node \"" 
                                                    + node.getID() + "\"");
            }
        }
    }

    private void checkReferencedNodesExist()
    {
        // Checks the existence of all nodes 
        // referred to by all of the flowchart's decisions

        foreach (Node node in m_Nodes)
        {
            foreach (Decision decision in node.getDecisions())
            {
                // Get the node referred to by a decision

                string strID = decision.getIDreference();

                // Throws an exception if the referred node does not exist

                if (findNode(strID) == null)
                {
                    throw new Exception("Flowchart refers to node \"" + strID +
                                                    "\" which does not exist");
                }
            }
        }
    }

    private void checkFlowchartSatisfiesDTD(string strFile)
    {
        // Checks a flowchart's structure satisfies the flowchart DTD

        // Creates an XML reader with DTD validation settings
        XmlReaderSettings settings = new XmlReaderSettings();
        settings.ProhibitDtd = false;
        settings.ValidationType = ValidationType.DTD;
        settings.ValidationEventHandler += new ValidationEventHandler(DTDError);
        XmlReader reader = XmlReader.Create(strFile, settings);

        // Read and validate the entire XML document
        while (reader.Read()) ;

        // The flowchart satisfies the DTD - close the XML reader
        reader.Close();
    }

    private void DTDError(object o, ValidationEventArgs args)
    {
        // Throws an XML exception if a flowchart does not satisfy the DTD

        throw new XmlException();
    }
}