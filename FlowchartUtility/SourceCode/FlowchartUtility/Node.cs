using System.Collections;

class Node
{
    // Member variables

    private string m_strID;
    private string m_strInformation;
    private bool m_bReachedFromStartNode;
    private ArrayList m_Decisions;

    // Constructor

    public Node(string strID, string strInformation)
    {
        m_strID = strID;
        m_strInformation = strInformation;
        m_bReachedFromStartNode = (strID == "start"); 
        m_Decisions = new ArrayList();
    }

    // Access procedures

    public string getID()
    {
        return m_strID;
    }

    public string getInformation()
    {
        return m_strInformation;
    }

    public bool isReachedFromStartNode()
    {
        return m_bReachedFromStartNode;
    }

    public ArrayList getDecisions()
    {
        return m_Decisions;
    }

    // Specifies that this node can be reached from the start node

    public void wasReachedFromStartNode()
    {
        m_bReachedFromStartNode = true;
    }

    // Adds a decision to the node's list of available decisions

    public void addDecision(Decision decision)
    {
        m_Decisions.Add(decision);
    }
}