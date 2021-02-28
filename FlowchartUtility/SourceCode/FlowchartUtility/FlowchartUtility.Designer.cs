using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace FlowchartUtility
{
    partial class FlowchartUtility
    {
        // Singleton flowchart instance

        private Flowchart flowchart = Flowchart.getFlowchart();

        // GUI controls

        private TextBox TB_Information = new TextBox();
        private ComboBox CB_Decisions = new ComboBox();
        private Button B_Continue = new Button();
        private Button B_Load = new Button();
        private Button B_Quit = new Button();
        private GroupBox GB_Information = new GroupBox();
        private GroupBox GB_Decisions = new GroupBox();
        private GroupBox GB_Menu = new GroupBox();
 
        private void InitializeComponent()
        {
            // Client window initialisation
            
            Text = "Flowchart Utility";
            ClientSize = new Size(488, 338);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;

            // GUI controls initialisation

            TB_Information.Location = new Point(6, 19);
            TB_Information.Multiline = true;
            TB_Information.ReadOnly = true;
            TB_Information.Size = new Size(452, 183);
            
            CB_Decisions.DropDownStyle = ComboBoxStyle.DropDownList;
            CB_Decisions.Location = new Point(6, 19);
            CB_Decisions.Size = new Size(352, 21);
            
            B_Continue.Location = new Point(364, 19);
            B_Continue.Size = new Size(94, 21);
            B_Continue.Text = "Continue";
            
            B_Load.Location = new Point(135, 19);
            B_Load.Size = new Size(94, 21);
            B_Load.Text = "Load";
           
            B_Quit.Location = new Point(235, 19);
            B_Quit.Size = new Size(94, 21);
            B_Quit.Text = "Quit";
            
            GB_Information.Controls.Add(TB_Information);
            GB_Information.Location = new Point(12, 13);
            GB_Information.Size = new Size(464, 208);
            GB_Information.Text = "Information";
            
            GB_Decisions.Controls.Add(CB_Decisions);
            GB_Decisions.Controls.Add(B_Continue);
            GB_Decisions.Location = new Point(12, 227);
            GB_Decisions.Size = new Size(464, 46);
            GB_Decisions.Text = "Decisions";
            
            GB_Menu.Controls.Add(B_Load);
            GB_Menu.Controls.Add(B_Quit);
            GB_Menu.Location = new Point(12, 279);
            GB_Menu.Size = new Size(464, 46);
            GB_Menu.Text = "Menu";

            InitialiseInformationAndDecisions();

            // Add the GUI controls to the client window

            Controls.Add(GB_Information);
            Controls.Add(GB_Decisions);
            Controls.Add(GB_Menu);

            // The selected control should default to the Load button

            B_Load.Select();

            // Event handlers

            CB_Decisions.SelectedIndexChanged += new EventHandler(SelectedDecision);
            B_Continue.Click += new EventHandler(ClickedContinue);
            B_Load.Click += new EventHandler(ClickedLoad);
            B_Quit.Click += new EventHandler(ClickedQuit);
        }

        private void DisplayErrorMessage(string strError)
        {
            // Displays the given error message

            InitialiseInformationAndDecisions();
            MessageBox.Show(strError, "Error", MessageBoxButtons.OK, 
                                               MessageBoxIcon.Exclamation);
        }

        private void InitialiseInformationAndDecisions()
        {
            // Displays the initial information and decisions

            TB_Information.Text = "To begin, please load an XML file.";
            CB_Decisions.Items.Clear();
            CB_Decisions.Items.Add("No decisions available");
            CB_Decisions.SelectedIndex = 0;
            B_Continue.Enabled = false;
        }

        private void UpdateInformationAndDecisions(string strID)
        {
            // Displays the information and decisions for the node with the given ID

            Node node = flowchart.findNode(strID);
            TB_Information.Text = node.getInformation();
            CB_Decisions.Items.Clear();
            CB_Decisions.Items.Add("Make a decision...");
            CB_Decisions.Items.AddRange(node.getDecisions().ToArray());
            CB_Decisions.SelectedIndex = 0;
        }

        private void SelectedDecision(object o, EventArgs args)
        {
            // Enables the Continue button when a decision is selected

            B_Continue.Enabled = (CB_Decisions.SelectedIndex != 0);
        }

        private void ClickedContinue(object o, EventArgs args)
        {
            // Continues to the next node in the flowchart based on the decision selected

            Decision decision = (Decision) CB_Decisions.SelectedItem;
            UpdateInformationAndDecisions(decision.getIDreference());
        }

        private void ClickedLoad(object o, EventArgs args)
        {
            // Asks the user which XML flowchart file they would like to load

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Flowchart Files (*.xml)|*.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Attempt to load the flowchart the user selected

                    flowchart.Load(dialog.FileName);
                    UpdateInformationAndDecisions("start");
                }
                catch (XmlException)
                {
                    // If the flowchart does not satisfy the DTD, display an error message

                    DisplayErrorMessage("Flowchart is not structured according to the DTD");
                }
                catch (Exception error)
                {
                    // If the flowchart is invalid, display an error message

                    DisplayErrorMessage(error.Message);
                }
            }
        }

        private void ClickedQuit(object o, EventArgs args)
        {
            // Exit the utility

            Dispose();
        }
    }
}