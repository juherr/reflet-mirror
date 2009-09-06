using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace UsbApp
{
    public partial class ConfigNouvAction : Form
    {
        Configuration formConfigCaller;

        public ConfigNouvAction()
        {
            InitializeComponent();
            comboBoxTypeAction.Items.Add("Poser");
            comboBoxTypeAction.Items.Add("Retirer");
        }

        public ConfigNouvAction(Configuration formConfig)
            : this()
        {
            formConfigCaller = formConfig;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Tous les fichiers (*.*)|*.*";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            dialog.Title = "Choisissez l'application à lancer";
            if (dialog.ShowDialog() == DialogResult.OK)
                textBoxFilePath.Text = dialog.FileName;     
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Action actionDemandee = Action.REMISE_ENDROIT;
            if ((string)(comboBoxTypeAction.SelectedItem) == "Poser")
                actionDemandee = Action.POSE;
            else if ((string)(comboBoxTypeAction.SelectedItem) == "Retirer")
                actionDemandee = Action.RETIRE;
            else return;
            ztampStruct actionOuAjouter = formConfigCaller.findAction(actionDemandee);
            actionOuAjouter.addAction(textBoxFilePath.Text,textBoxParam.Text);
            formConfigCaller.isZtampModified = true;
            formConfigCaller.refreshTree();
            this.Hide();
        }
    }
}
