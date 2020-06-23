﻿namespace WindowsFormsApp1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.cbAlgorithm = new System.Windows.Forms.ComboBox();
            this.lblAlgorithmType = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbTypeAlgorithm = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblActions = new System.Windows.Forms.Label();
            this.tmrPacman = new System.Windows.Forms.Timer(this.components);
            this.picBoxPacman = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPacman)).BeginInit();
            this.SuspendLayout();
            // 
            // cbAlgorithm
            // 
            this.cbAlgorithm.FormattingEnabled = true;
            this.cbAlgorithm.Items.AddRange(new object[] {
            "Uninformed Search",
            "Informed Search"});
            this.cbAlgorithm.Location = new System.Drawing.Point(973, 62);
            this.cbAlgorithm.Name = "cbAlgorithm";
            this.cbAlgorithm.Size = new System.Drawing.Size(243, 24);
            this.cbAlgorithm.TabIndex = 0;
            this.cbAlgorithm.SelectionChangeCommitted += new System.EventHandler(this.cbAlgorithm_SelectionChangeCommitted);
            // 
            // lblAlgorithmType
            // 
            this.lblAlgorithmType.AutoSize = true;
            this.lblAlgorithmType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblAlgorithmType.Location = new System.Drawing.Point(967, 39);
            this.lblAlgorithmType.Name = "lblAlgorithmType";
            this.lblAlgorithmType.Size = new System.Drawing.Size(249, 20);
            this.lblAlgorithmType.TabIndex = 1;
            this.lblAlgorithmType.Text = "Одберете тип на алгоритам";
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(41, 732);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(85, 36);
            this.button1.TabIndex = 2;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(978, 251);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(238, 517);
            this.textBox1.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.picBoxPacman);
            this.panel1.Location = new System.Drawing.Point(41, 39);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(700, 700);
            this.panel1.TabIndex = 4;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cbTypeAlgorithm
            // 
            this.cbTypeAlgorithm.Enabled = false;
            this.cbTypeAlgorithm.FormattingEnabled = true;
            this.cbTypeAlgorithm.Location = new System.Drawing.Point(973, 162);
            this.cbTypeAlgorithm.Name = "cbTypeAlgorithm";
            this.cbTypeAlgorithm.Size = new System.Drawing.Size(243, 24);
            this.cbTypeAlgorithm.TabIndex = 5;
            this.cbTypeAlgorithm.SelectionChangeCommitted += new System.EventHandler(this.cbTypeAlgorithm_SelectionChangeCommitted);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(886, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Одберете алгоритам за пребарување";
            // 
            // lblActions
            // 
            this.lblActions.AutoSize = true;
            this.lblActions.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblActions.Location = new System.Drawing.Point(1156, 228);
            this.lblActions.Name = "lblActions";
            this.lblActions.Size = new System.Drawing.Size(60, 20);
            this.lblActions.TabIndex = 7;
            this.lblActions.Text = "Акции";
            // 
            // tmrPacman
            // 
            this.tmrPacman.Enabled = true;
            this.tmrPacman.Interval = 500;
            // 
            // picBoxPacman
            // 
            this.picBoxPacman.Image = ((System.Drawing.Image)(resources.GetObject("picBoxPacman.Image")));
            this.picBoxPacman.Location = new System.Drawing.Point(36, 563);
            this.picBoxPacman.Name = "picBoxPacman";
            this.picBoxPacman.Size = new System.Drawing.Size(49, 49);
            this.picBoxPacman.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxPacman.TabIndex = 0;
            this.picBoxPacman.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1275, 901);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lblActions);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbTypeAlgorithm);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lblAlgorithmType);
            this.Controls.Add(this.cbAlgorithm);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxPacman)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAlgorithm;
        private System.Windows.Forms.Label lblAlgorithmType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbTypeAlgorithm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblActions;
        private System.Windows.Forms.Timer tmrPacman;
        private System.Windows.Forms.PictureBox picBoxPacman;
    }
}

