namespace Dynamic_Games
{
    partial class CoopForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panelCoalition = new System.Windows.Forms.Panel();
            this.chartProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericPlayerNo = new System.Windows.Forms.NumericUpDown();
            this.numericNewPlayer = new System.Windows.Forms.NumericUpDown();
            this.numericPlayerLeft = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxMaterials = new System.Windows.Forms.RichTextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // panelCoalition
            // 
            this.panelCoalition.Location = new System.Drawing.Point(12, 13);
            this.panelCoalition.Name = "panelCoalition";
            this.panelCoalition.Size = new System.Drawing.Size(350, 207);
            this.panelCoalition.TabIndex = 0;
            // 
            // chartProfit
            // 
            chartArea2.Name = "ChartArea1";
            this.chartProfit.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartProfit.Legends.Add(legend2);
            this.chartProfit.Location = new System.Drawing.Point(12, 229);
            this.chartProfit.Name = "chartProfit";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartProfit.Series.Add(series2);
            this.chartProfit.Size = new System.Drawing.Size(350, 207);
            this.chartProfit.TabIndex = 0;
            this.chartProfit.Text = "Winning function";
            // 
            // numericPlayerNo
            // 
            this.numericPlayerNo.Location = new System.Drawing.Point(421, 29);
            this.numericPlayerNo.Name = "numericPlayerNo";
            this.numericPlayerNo.Size = new System.Drawing.Size(144, 20);
            this.numericPlayerNo.TabIndex = 1;
            // 
            // numericNewPlayer
            // 
            this.numericNewPlayer.Location = new System.Drawing.Point(377, 88);
            this.numericNewPlayer.Name = "numericNewPlayer";
            this.numericNewPlayer.Size = new System.Drawing.Size(101, 20);
            this.numericNewPlayer.TabIndex = 2;
            // 
            // numericPlayerLeft
            // 
            this.numericPlayerLeft.Location = new System.Drawing.Point(505, 88);
            this.numericPlayerLeft.Name = "numericPlayerLeft";
            this.numericPlayerLeft.Size = new System.Drawing.Size(101, 20);
            this.numericPlayerLeft.TabIndex = 3;
            // 
            // richTextBoxMaterials
            // 
            this.richTextBoxMaterials.Location = new System.Drawing.Point(377, 205);
            this.richTextBoxMaterials.Name = "richTextBoxMaterials";
            this.richTextBoxMaterials.Size = new System.Drawing.Size(229, 111);
            this.richTextBoxMaterials.TabIndex = 4;
            this.richTextBoxMaterials.Text = "";
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(377, 147);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(229, 20);
            this.textBoxProduct.TabIndex = 5;
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(377, 402);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 34);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(454, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Incoming players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(532, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Leavers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(470, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Product";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Materials";
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(498, 402);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(108, 34);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // CoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 448);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.richTextBoxMaterials);
            this.Controls.Add(this.numericPlayerLeft);
            this.Controls.Add(this.numericNewPlayer);
            this.Controls.Add(this.numericPlayerNo);
            this.Controls.Add(this.chartProfit);
            this.Controls.Add(this.panelCoalition);
            this.Name = "CoopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoopForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericNewPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayerLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelCoalition;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfit;
        private System.Windows.Forms.NumericUpDown numericPlayerNo;
        private System.Windows.Forms.NumericUpDown numericNewPlayer;
        private System.Windows.Forms.NumericUpDown numericPlayerLeft;
        private System.Windows.Forms.RichTextBox richTextBoxMaterials;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStop;
    }
}