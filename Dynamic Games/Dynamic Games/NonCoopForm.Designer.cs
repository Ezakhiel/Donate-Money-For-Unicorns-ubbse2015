namespace Dynamic_Games
{
    partial class NonCoopForm
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
            this.NoPTB = new System.Windows.Forms.TextBox();
            this.InvestmentTB = new System.Windows.Forms.TextBox();
            this.MultiTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.GraphTypeCB = new System.Windows.Forms.ComboBox();
            this.ContributorTB = new System.Windows.Forms.TextBox();
            this.DefectorTB = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.StartButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.NrCoopTB = new System.Windows.Forms.TextBox();
            this.graphBox = new System.Windows.Forms.PictureBox();
            this.percTB = new System.Windows.Forms.TextBox();
            this.Cont = new System.Windows.Forms.Label();
            this.nrDefTB = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.ruleCB = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RestartButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NoPTB
            // 
            this.NoPTB.Location = new System.Drawing.Point(125, 35);
            this.NoPTB.Name = "NoPTB";
            this.NoPTB.Size = new System.Drawing.Size(140, 20);
            this.NoPTB.TabIndex = 0;
            // 
            // InvestmentTB
            // 
            this.InvestmentTB.Location = new System.Drawing.Point(125, 73);
            this.InvestmentTB.Name = "InvestmentTB";
            this.InvestmentTB.Size = new System.Drawing.Size(140, 20);
            this.InvestmentTB.TabIndex = 1;
            // 
            // MultiTB
            // 
            this.MultiTB.Location = new System.Drawing.Point(125, 116);
            this.MultiTB.Name = "MultiTB";
            this.MultiTB.Size = new System.Drawing.Size(140, 20);
            this.MultiTB.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of Players:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Investment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Multiplication Factor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(338, 76);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Graph Type:";
            // 
            // GraphTypeCB
            // 
            this.GraphTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GraphTypeCB.FormattingEnabled = true;
            this.GraphTypeCB.Items.AddRange(new object[] {
            "Random Graph",
            "Small World Graph"});
            this.GraphTypeCB.Location = new System.Drawing.Point(421, 73);
            this.GraphTypeCB.Name = "GraphTypeCB";
            this.GraphTypeCB.Size = new System.Drawing.Size(140, 21);
            this.GraphTypeCB.TabIndex = 7;
            // 
            // ContributorTB
            // 
            this.ContributorTB.Location = new System.Drawing.Point(106, 221);
            this.ContributorTB.Name = "ContributorTB";
            this.ContributorTB.ReadOnly = true;
            this.ContributorTB.Size = new System.Drawing.Size(100, 20);
            this.ContributorTB.TabIndex = 8;
            this.ContributorTB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DefectorTB
            // 
            this.DefectorTB.Location = new System.Drawing.Point(106, 256);
            this.DefectorTB.Name = "DefectorTB";
            this.DefectorTB.ReadOnly = true;
            this.DefectorTB.Size = new System.Drawing.Size(100, 20);
            this.DefectorTB.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Contributors:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(34, 259);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Defectors:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(33, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 22);
            this.label7.TabIndex = 12;
            this.label7.Text = "Payoffs:";
            // 
            // StartButton
            // 
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StartButton.Location = new System.Drawing.Point(280, 218);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(140, 24);
            this.StartButton.TabIndex = 13;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(665, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Nr of Cooperators:";
            // 
            // NrCoopTB
            // 
            this.NrCoopTB.Location = new System.Drawing.Point(775, 37);
            this.NrCoopTB.Name = "NrCoopTB";
            this.NrCoopTB.ReadOnly = true;
            this.NrCoopTB.Size = new System.Drawing.Size(140, 20);
            this.NrCoopTB.TabIndex = 14;
            // 
            // graphBox
            // 
            this.graphBox.Location = new System.Drawing.Point(37, 289);
            this.graphBox.Name = "graphBox";
            this.graphBox.Size = new System.Drawing.Size(709, 278);
            this.graphBox.TabIndex = 16;
            this.graphBox.TabStop = false;
            // 
            // percTB
            // 
            this.percTB.Location = new System.Drawing.Point(421, 34);
            this.percTB.Name = "percTB";
            this.percTB.ReadOnly = true;
            this.percTB.Size = new System.Drawing.Size(140, 20);
            this.percTB.TabIndex = 17;
            // 
            // Cont
            // 
            this.Cont.AutoSize = true;
            this.Cont.Location = new System.Drawing.Point(338, 38);
            this.Cont.Name = "Cont";
            this.Cont.Size = new System.Drawing.Size(70, 13);
            this.Cont.TabIndex = 18;
            this.Cont.Text = "Cooperator%:";
            // 
            // nrDefTB
            // 
            this.nrDefTB.Location = new System.Drawing.Point(775, 70);
            this.nrDefTB.Name = "nrDefTB";
            this.nrDefTB.ReadOnly = true;
            this.nrDefTB.Size = new System.Drawing.Size(140, 20);
            this.nrDefTB.TabIndex = 19;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(676, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(82, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "Nr of Defectors:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(680, 116);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(78, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Money earned:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(779, 113);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(140, 20);
            this.textBox1.TabIndex = 21;
            // 
            // ruleCB
            // 
            this.ruleCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ruleCB.FormattingEnabled = true;
            this.ruleCB.Items.AddRange(new object[] {
            "Neighbors Decide",
            "Mult. Fact. Grows",
            "Minimum Percentage"});
            this.ruleCB.Location = new System.Drawing.Point(421, 113);
            this.ruleCB.Name = "ruleCB";
            this.ruleCB.Size = new System.Drawing.Size(140, 21);
            this.ruleCB.TabIndex = 24;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 119);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Rule: ";
            // 
            // RestartButton
            // 
            this.RestartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RestartButton.Location = new System.Drawing.Point(280, 252);
            this.RestartButton.Name = "RestartButton";
            this.RestartButton.Size = new System.Drawing.Size(140, 24);
            this.RestartButton.TabIndex = 25;
            this.RestartButton.Text = "Restart";
            this.RestartButton.UseVisualStyleBackColor = true;
            this.RestartButton.Click += new System.EventHandler(this.RestartButton_Click);
            // 
            // NonCoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 579);
            this.Controls.Add(this.RestartButton);
            this.Controls.Add(this.ruleCB);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nrDefTB);
            this.Controls.Add(this.Cont);
            this.Controls.Add(this.percTB);
            this.Controls.Add(this.graphBox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.NrCoopTB);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DefectorTB);
            this.Controls.Add(this.ContributorTB);
            this.Controls.Add(this.GraphTypeCB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MultiTB);
            this.Controls.Add(this.InvestmentTB);
            this.Controls.Add(this.NoPTB);
            this.Name = "NonCoopForm";
            this.Text = "NonCoopForm";
            this.Load += new System.EventHandler(this.NonCoopForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.graphBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NoPTB;
        private System.Windows.Forms.TextBox InvestmentTB;
        private System.Windows.Forms.TextBox MultiTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox GraphTypeCB;
        private System.Windows.Forms.TextBox ContributorTB;
        private System.Windows.Forms.TextBox DefectorTB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox NrCoopTB;
        private System.Windows.Forms.PictureBox graphBox;
        private System.Windows.Forms.TextBox percTB;
        private System.Windows.Forms.Label Cont;
        private System.Windows.Forms.TextBox nrDefTB;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox ruleCB;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button RestartButton;
    }
}