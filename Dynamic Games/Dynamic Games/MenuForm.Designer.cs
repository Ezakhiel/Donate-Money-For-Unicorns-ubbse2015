namespace Dynamic_Games
{
    partial class MenuForm
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
            this.buttonNonCoop = new System.Windows.Forms.Button();
            this.buttonCoop = new System.Windows.Forms.Button();
            this.buttonIncompInf = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonNonCoop
            // 
            this.buttonNonCoop.Location = new System.Drawing.Point(65, 97);
            this.buttonNonCoop.Name = "buttonNonCoop";
            this.buttonNonCoop.Size = new System.Drawing.Size(256, 58);
            this.buttonNonCoop.TabIndex = 0;
            this.buttonNonCoop.Text = "Non Co-op ";
            this.buttonNonCoop.UseVisualStyleBackColor = true;
            this.buttonNonCoop.Click += new System.EventHandler(this.buttonNonCoop_Click);
            // 
            // buttonCoop
            // 
            this.buttonCoop.Location = new System.Drawing.Point(65, 187);
            this.buttonCoop.Name = "buttonCoop";
            this.buttonCoop.Size = new System.Drawing.Size(256, 58);
            this.buttonCoop.TabIndex = 1;
            this.buttonCoop.Text = "Co-op";
            this.buttonCoop.UseVisualStyleBackColor = true;
            this.buttonCoop.Click += new System.EventHandler(this.buttonCoop_Click);
            // 
            // buttonIncompInf
            // 
            this.buttonIncompInf.Location = new System.Drawing.Point(65, 276);
            this.buttonIncompInf.Name = "buttonIncompInf";
            this.buttonIncompInf.Size = new System.Drawing.Size(256, 58);
            this.buttonIncompInf.TabIndex = 2;
            this.buttonIncompInf.Text = "Incomplete Information";
            this.buttonIncompInf.UseVisualStyleBackColor = true;
            this.buttonIncompInf.Click += new System.EventHandler(this.buttonIncompInf_Click);
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 396);
            this.Controls.Add(this.buttonIncompInf);
            this.Controls.Add(this.buttonCoop);
            this.Controls.Add(this.buttonNonCoop);
            this.Name = "FormMenu";
            this.Text = "Dynamic Games";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNonCoop;
        private System.Windows.Forms.Button buttonCoop;
        private System.Windows.Forms.Button buttonIncompInf;
    }
}

