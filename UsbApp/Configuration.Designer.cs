namespace UsbApp
{
    partial class Configuration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Placez un Ztamp sur le mir:ror pour le configurer");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Configuration));
            this.label1 = new System.Windows.Forms.Label();
            this.labelIdZtamp = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonSupprAction = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.buttonAddAction = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxImg = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNom = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Identifiant du Ztamp";
            // 
            // labelIdZtamp
            // 
            this.labelIdZtamp.AutoSize = true;
            this.labelIdZtamp.Location = new System.Drawing.Point(130, 14);
            this.labelIdZtamp.Name = "labelIdZtamp";
            this.labelIdZtamp.Size = new System.Drawing.Size(0, 13);
            this.labelIdZtamp.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.buttonSupprAction);
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Controls.Add(this.buttonAddAction);
            this.groupBox1.Location = new System.Drawing.Point(16, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(532, 332);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Actions à réaliser";
            // 
            // buttonSupprAction
            // 
            this.buttonSupprAction.Enabled = false;
            this.buttonSupprAction.Location = new System.Drawing.Point(408, 196);
            this.buttonSupprAction.Name = "buttonSupprAction";
            this.buttonSupprAction.Size = new System.Drawing.Size(118, 48);
            this.buttonSupprAction.TabIndex = 4;
            this.buttonSupprAction.Text = "Supprimer une action";
            this.buttonSupprAction.UseVisualStyleBackColor = true;
            this.buttonSupprAction.Click += new System.EventHandler(this.buttonSupprAction_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(7, 20);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "NodeAdd";
            treeNode1.Text = "Placez un Ztamp sur le mir:ror pour le configurer";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(395, 306);
            this.treeView1.TabIndex = 3;
            // 
            // buttonAddAction
            // 
            this.buttonAddAction.Enabled = false;
            this.buttonAddAction.Location = new System.Drawing.Point(408, 120);
            this.buttonAddAction.Name = "buttonAddAction";
            this.buttonAddAction.Size = new System.Drawing.Size(118, 50);
            this.buttonAddAction.TabIndex = 1;
            this.buttonAddAction.Text = "Ajouter une action";
            this.buttonAddAction.UseVisualStyleBackColor = true;
            this.buttonAddAction.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Image associée";
            // 
            // comboBoxImg
            // 
            this.comboBoxImg.FormattingEnabled = true;
            this.comboBoxImg.Location = new System.Drawing.Point(132, 79);
            this.comboBoxImg.Name = "comboBoxImg";
            this.comboBoxImg.Size = new System.Drawing.Size(176, 21);
            this.comboBoxImg.TabIndex = 4;
            this.comboBoxImg.SelectedIndexChanged += new System.EventHandler(this.comboBoxImg_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(428, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(120, 120);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(16, 486);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(152, 23);
            this.button3.TabIndex = 7;
            this.button3.Text = "Sauvegarder";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Location = new System.Drawing.Point(199, 486);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(160, 23);
            this.button4.TabIndex = 8;
            this.button4.Text = "Annuler";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nom associé";
            // 
            // textBoxNom
            // 
            this.textBoxNom.Location = new System.Drawing.Point(132, 44);
            this.textBoxNom.Name = "textBoxNom";
            this.textBoxNom.Size = new System.Drawing.Size(161, 20);
            this.textBoxNom.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 486);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "Fermer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 521);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxImg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelIdZtamp);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Configuration";
            this.Text = "Configuration des Ztamps";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelIdZtamp;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxImg;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonAddAction;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNom;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button buttonSupprAction;
        private System.Windows.Forms.Button button1;
    }
}