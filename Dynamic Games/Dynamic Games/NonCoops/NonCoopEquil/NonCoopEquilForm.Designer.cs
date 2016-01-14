namespace Dynamic_Games
{
    partial class NonCoopEquilForm
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
            this.cbGame = new System.Windows.Forms.ComboBox();
            this.lGame = new System.Windows.Forms.Label();
            this.lNBPlayers = new System.Windows.Forms.Label();
            this.cbNRPlayers = new System.Windows.Forms.ComboBox();
            this.cbEquil = new System.Windows.Forms.ComboBox();
            this.lEquil = new System.Windows.Forms.Label();
            this.bStart = new System.Windows.Forms.Button();
            this.pParam = new System.Windows.Forms.Panel();
            this.tbPM = new System.Windows.Forms.TextBox();
            this.lparam4 = new System.Windows.Forms.Label();
            this.tbSmax = new System.Windows.Forms.TextBox();
            this.lparam3 = new System.Windows.Forms.Label();
            this.tbParC = new System.Windows.Forms.TextBox();
            this.tbParA = new System.Windows.Forms.TextBox();
            this.lparam2 = new System.Windows.Forms.Label();
            this.lparam1 = new System.Windows.Forms.Label();
            this.lParam = new System.Windows.Forms.Label();
            this.lvResult = new System.Windows.Forms.ListView();
            this.lArchive = new System.Windows.Forms.Label();
            this.lConclusion = new System.Windows.Forms.Label();
            this.pParam.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbGame
            // 
            this.cbGame.FormattingEnabled = true;
            this.cbGame.Location = new System.Drawing.Point(12, 52);
            this.cbGame.Name = "cbGame";
            this.cbGame.Size = new System.Drawing.Size(121, 21);
            this.cbGame.TabIndex = 0;
            this.cbGame.SelectedIndexChanged += new System.EventHandler(this.cbGame_SelectedIndexChanged);
            // 
            // lGame
            // 
            this.lGame.AutoSize = true;
            this.lGame.Location = new System.Drawing.Point(13, 36);
            this.lGame.Name = "lGame";
            this.lGame.Size = new System.Drawing.Size(35, 13);
            this.lGame.TabIndex = 1;
            this.lGame.Text = "Game";
            // 
            // lNBPlayers
            // 
            this.lNBPlayers.AutoSize = true;
            this.lNBPlayers.Location = new System.Drawing.Point(13, 95);
            this.lNBPlayers.Name = "lNBPlayers";
            this.lNBPlayers.Size = new System.Drawing.Size(92, 13);
            this.lNBPlayers.TabIndex = 3;
            this.lNBPlayers.Text = "Number of players";
            // 
            // cbNRPlayers
            // 
            this.cbNRPlayers.FormattingEnabled = true;
            this.cbNRPlayers.IntegralHeight = false;
            this.cbNRPlayers.Location = new System.Drawing.Point(12, 111);
            this.cbNRPlayers.Name = "cbNRPlayers";
            this.cbNRPlayers.Size = new System.Drawing.Size(121, 21);
            this.cbNRPlayers.TabIndex = 4;
            // 
            // cbEquil
            // 
            this.cbEquil.FormattingEnabled = true;
            this.cbEquil.Location = new System.Drawing.Point(12, 174);
            this.cbEquil.Name = "cbEquil";
            this.cbEquil.Size = new System.Drawing.Size(121, 21);
            this.cbEquil.TabIndex = 5;
            // 
            // lEquil
            // 
            this.lEquil.AutoSize = true;
            this.lEquil.Location = new System.Drawing.Point(12, 155);
            this.lEquil.Name = "lEquil";
            this.lEquil.Size = new System.Drawing.Size(57, 13);
            this.lEquil.TabIndex = 6;
            this.lEquil.Text = "Equilibrium";
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(12, 254);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(121, 23);
            this.bStart.TabIndex = 7;
            this.bStart.Text = "Find...";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // pParam
            // 
            this.pParam.Controls.Add(this.lConclusion);
            this.pParam.Controls.Add(this.tbPM);
            this.pParam.Controls.Add(this.lparam4);
            this.pParam.Controls.Add(this.tbSmax);
            this.pParam.Controls.Add(this.lparam3);
            this.pParam.Controls.Add(this.tbParC);
            this.pParam.Controls.Add(this.tbParA);
            this.pParam.Controls.Add(this.lparam2);
            this.pParam.Controls.Add(this.lparam1);
            this.pParam.Controls.Add(this.lParam);
            this.pParam.Location = new System.Drawing.Point(146, 17);
            this.pParam.Name = "pParam";
            this.pParam.Size = new System.Drawing.Size(163, 260);
            this.pParam.TabIndex = 8;
            this.pParam.Visible = false;
            // 
            // tbPM
            // 
            this.tbPM.Location = new System.Drawing.Point(93, 88);
            this.tbPM.Name = "tbPM";
            this.tbPM.Size = new System.Drawing.Size(50, 20);
            this.tbPM.TabIndex = 10;
            // 
            // lparam4
            // 
            this.lparam4.Location = new System.Drawing.Point(13, 88);
            this.lparam4.Name = "lparam4";
            this.lparam4.Size = new System.Drawing.Size(70, 20);
            this.lparam4.TabIndex = 9;
            this.lparam4.Text = "pm";
            this.lparam4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSmax
            // 
            this.tbSmax.Location = new System.Drawing.Point(93, 114);
            this.tbSmax.Name = "tbSmax";
            this.tbSmax.Size = new System.Drawing.Size(50, 20);
            this.tbSmax.TabIndex = 8;
            // 
            // lparam3
            // 
            this.lparam3.Location = new System.Drawing.Point(13, 114);
            this.lparam3.Name = "lparam3";
            this.lparam3.Size = new System.Drawing.Size(70, 20);
            this.lparam3.TabIndex = 5;
            this.lparam3.Text = "Max. strategy";
            this.lparam3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbParC
            // 
            this.tbParC.Location = new System.Drawing.Point(93, 62);
            this.tbParC.Name = "tbParC";
            this.tbParC.Size = new System.Drawing.Size(50, 20);
            this.tbParC.TabIndex = 4;
            // 
            // tbParA
            // 
            this.tbParA.Location = new System.Drawing.Point(93, 36);
            this.tbParA.Name = "tbParA";
            this.tbParA.Size = new System.Drawing.Size(50, 20);
            this.tbParA.TabIndex = 3;
            // 
            // lparam2
            // 
            this.lparam2.Location = new System.Drawing.Point(13, 62);
            this.lparam2.Name = "lparam2";
            this.lparam2.Size = new System.Drawing.Size(70, 20);
            this.lparam2.TabIndex = 2;
            this.lparam2.Text = "c = ";
            this.lparam2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lparam1
            // 
            this.lparam1.Location = new System.Drawing.Point(13, 36);
            this.lparam1.Name = "lparam1";
            this.lparam1.Size = new System.Drawing.Size(70, 20);
            this.lparam1.TabIndex = 1;
            this.lparam1.Text = "a =";
            this.lparam1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lParam
            // 
            this.lParam.AutoSize = true;
            this.lParam.Location = new System.Drawing.Point(3, 0);
            this.lParam.Name = "lParam";
            this.lParam.Size = new System.Drawing.Size(60, 13);
            this.lParam.TabIndex = 0;
            this.lParam.Text = "Parameters";
            // 
            // lvResult
            // 
            this.lvResult.Location = new System.Drawing.Point(339, 36);
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(383, 304);
            this.lvResult.TabIndex = 9;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            // 
            // lArchive
            // 
            this.lArchive.AutoSize = true;
            this.lArchive.Location = new System.Drawing.Point(336, 17);
            this.lArchive.Name = "lArchive";
            this.lArchive.Size = new System.Drawing.Size(43, 13);
            this.lArchive.TabIndex = 10;
            this.lArchive.Text = "Archive";
            // 
            // lConclusion
            // 
            this.lConclusion.AutoSize = true;
            this.lConclusion.Location = new System.Drawing.Point(3, 157);
            this.lConclusion.Name = "lConclusion";
            this.lConclusion.Size = new System.Drawing.Size(0, 13);
            this.lConclusion.TabIndex = 11;
            // 
            // NonCoopEquilForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 352);
            this.Controls.Add(this.lArchive);
            this.Controls.Add(this.lvResult);
            this.Controls.Add(this.pParam);
            this.Controls.Add(this.bStart);
            this.Controls.Add(this.lEquil);
            this.Controls.Add(this.cbEquil);
            this.Controls.Add(this.cbNRPlayers);
            this.Controls.Add(this.lNBPlayers);
            this.Controls.Add(this.lGame);
            this.Controls.Add(this.cbGame);
            this.Name = "NonCoopEquilForm";
            this.Text = "NonCoopEquilForm";
            this.Load += new System.EventHandler(this.NonCoopEquilForm_Load);
            this.pParam.ResumeLayout(false);
            this.pParam.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGame;
        private System.Windows.Forms.Label lGame;
        private System.Windows.Forms.Label lNBPlayers;
        private System.Windows.Forms.ComboBox cbNRPlayers;
        private System.Windows.Forms.ComboBox cbEquil;
        private System.Windows.Forms.Label lEquil;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Panel pParam;
        private System.Windows.Forms.TextBox tbParC;
        private System.Windows.Forms.TextBox tbParA;
        private System.Windows.Forms.Label lparam2;
        private System.Windows.Forms.Label lparam1;
        private System.Windows.Forms.Label lParam;
        private System.Windows.Forms.TextBox tbSmax;
        private System.Windows.Forms.Label lparam3;
        private System.Windows.Forms.Label lparam4;
        private System.Windows.Forms.TextBox tbPM;
        private System.Windows.Forms.ListView lvResult;
        private System.Windows.Forms.Label lArchive;
        public System.Windows.Forms.Label lConclusion;
    }
}