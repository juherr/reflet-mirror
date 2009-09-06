using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using UsbLibrary;
using System.IO; 

namespace UsbApp
{
    public partial class Configuration : Form
    {
        //current ztamp actions
        protected List<ztampStruct> ztampActions = null;
        protected string currentIdZtamp = string.Empty;
        protected bool isZtampPresent = false;
        public bool isZtampModified = false;

        public Configuration()
        {
            InitializeComponent();
            fillCombo();
        }

        private void fillCombo()
        {
            DirectoryInfo di = new DirectoryInfo(Application.StartupPath + "/img");
            FileInfo[] rgFiles = di.GetFiles("*.jpg");
            foreach (FileInfo fi in rgFiles)
            {
                this.comboBoxImg.Items.Add(fi.Name);
            }
        }
        public void processConfigAction(byte[] mirrorData)
        {
            MirrorLogic logic = new MirrorLogic();
            if (mirrorData[1] == 1) //action miroir
            {
                if (mirrorData[2] == 4) //remis à l'endroit
                {
                    //this.lb_read.Items.Insert(0, "Remise à l'endroit du mir:ror");
                }
                else if (mirrorData[2] == 5) // mise à l'envers
                {
                    //this.lb_read.Items.Insert(0, "Retournement du mir:ror");
                }
            }
            else if (mirrorData[1] == 2) //action ztamp
            {
                string idZtamp = String.Empty;
                for (int i = 3; i <= 13; i++)
                    idZtamp += mirrorData[i].ToString("X2");
                currentIdZtamp = idZtamp;
                this.labelIdZtamp.Text = idZtamp;
                this.Text = String.Format("Configuration du Ztamp {0}", idZtamp);
                if (mirrorData[2] == 1) //dépot
                {
                    //on vide le treeview
                    treeView1.Nodes.Clear();

                    //affichage des actions
                    ztampActions = logic.getMirrorLogic(idZtamp);
                    fillActionTree();
                    fillInfoZtamp();

                    buttonAddAction.Enabled = true;
                    buttonSupprAction.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    isZtampPresent = true;
                }
                else if (mirrorData[2] == 2) // retrait
                {
                    //on efface tout
                    treeView1.Nodes.Clear();
                    this.textBoxNom.Text = String.Empty;
                    this.comboBoxImg.SelectedItem = null;
                    this.pictureBox1.ImageLocation = String.Empty;
                    this.Text = String.Format("Configuration des Ztamps");
                    this.labelIdZtamp.Text = String.Empty;
                    this.treeView1.Nodes.Add("Placez un Ztamp sur le mir:ror pour le configurer");
                    buttonAddAction.Enabled = false;
                    buttonSupprAction.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                    isZtampPresent = false;
                    isZtampModified = false;
                    ztampActions = null;
                }
            }
            else
            {
                Console.WriteLine("tiens, une erreur inconnue est survenue...");
            }
        }

        private void saveNewConfig()
        {
            MirrorLogic logic = new MirrorLogic();
            List<ztampStruct> fullZtampList = logic.GetZtampList();
            List<ztampStruct> newZtampList = new List<ztampStruct>();
            //suppression des actions actuelles
            foreach (ztampStruct zStruct in fullZtampList)
            {
                if (zStruct.ztampID != currentIdZtamp)
                    newZtampList.Add(zStruct);
            }
            foreach (ztampStruct zStruct in ztampActions)
            {
                zStruct.ztampName = this.textBoxNom.Text;
                zStruct.ztampImg = (string)(this.comboBoxImg.SelectedItem);
                newZtampList.Add(zStruct);
            }
            logic.SetZtampList(newZtampList);
            isZtampModified = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigNouvAction dialogConfig = new ConfigNouvAction(this);
            dialogConfig.Show();
        }

        private void fillActionTree()
        {
            foreach (ztampStruct action in ztampActions)
            {
                if (action != null)
                {
                    TreeNode nodeAction = this.treeView1.Nodes.Add(action.ztampAction.ToString(), action.ztampAction.ToString());
                    foreach (string cLine in action.ztampAppCLine)
                    {
                        nodeAction.Nodes.Add(cLine);
                    }
                    nodeAction.ExpandAll();
                }
            }
        }

        private void fillInfoZtamp()
        {
            foreach (ztampStruct action in ztampActions)
            {
                if (action != null)
                {
                    this.textBoxNom.Text = action.ztampName;
                    this.comboBoxImg.SelectedItem = action.ztampImg;
                    if (!String.IsNullOrEmpty(action.ztampImg))
                        this.pictureBox1.ImageLocation = Application.StartupPath + "/img/" + action.ztampImg;
                }
            }
        }

        public bool refreshTree()
        {
            treeView1.Nodes.Clear();
            fillActionTree();
            return true;
        }

        //trouver une action avec le ztampId actuel
        public ztampStruct findAction(Action typeAction)
        {
            foreach (ztampStruct action in ztampActions)
            {
                if (action.ztampAction == typeAction)
                {
                    return action;
                }
            }
            //action introuvable
            //on la crée
            ztampStruct newAction = new ztampStruct();
            newAction.ztampID = currentIdZtamp;
            newAction.ztampAction = typeAction;
            ztampActions.Add(newAction);
            return newAction;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveNewConfig();
            Console.WriteLine("sauvé");
        }

        private void buttonSupprAction_Click(object sender, EventArgs e)
        {
            int index = this.treeView1.SelectedNode.Index;
            string actionNode = this.treeView1.SelectedNode.Parent.Name;
            Console.WriteLine(index);
            Console.WriteLine(actionNode);
            foreach (ztampStruct action in ztampActions)
            {
                if (action != null && action.ztampAction.ToString()==actionNode)
                {
                    action.ztampAppCLine.RemoveAt(index);
                    action.ztampAppArgs.RemoveAt(index);
                    refreshTree();
                    return;
                }
            }
            isZtampModified = true;
        }

        private void comboBoxImg_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbBox = sender as ComboBox;
            if (!String.IsNullOrEmpty((string)(cbBox.SelectedItem)))
                this.pictureBox1.ImageLocation = Application.StartupPath + "/img/" + (string)(cbBox.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MirrorLogic logic = new MirrorLogic();

            //on vide le treeview
            treeView1.Nodes.Clear();

            //affichage des actions
            ztampActions = logic.getMirrorLogic(currentIdZtamp);
            fillActionTree();
            fillInfoZtamp();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (isZtampPresent && isZtampModified)
            {
                if (MessageBox.Show("Vous n'avez pas enregistré les modifications sur le z:tamp.\nVoulez-vous vraiment fermer la fenêtre ?",
                    "Données z:tamp non enregistrées", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.Close();
                }
            }
            else
                this.Close();
        }


    }
}
