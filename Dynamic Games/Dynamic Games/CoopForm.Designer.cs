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
            this.chartProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericPlayer = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxMaterials = new System.Windows.Forms.RichTextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonNewPlayer = new System.Windows.Forms.Button();
            this.buttonLeaver = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
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
            // numericPlayer
            // 
            this.numericPlayer.Location = new System.Drawing.Point(421, 29);
            this.numericPlayer.Name = "numericPlayer";
            this.numericPlayer.Size = new System.Drawing.Size(144, 20);
            this.numericPlayer.TabIndex = 1;
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
            // buttonNewPlayer
            // 
            this.buttonNewPlayer.Location = new System.Drawing.Point(377, 88);
            this.buttonNewPlayer.Name = "buttonNewPlayer";
            this.buttonNewPlayer.Size = new System.Drawing.Size(108, 23);
            this.buttonNewPlayer.TabIndex = 13;
            this.buttonNewPlayer.Text = "+1 player";
            this.buttonNewPlayer.UseVisualStyleBackColor = true;
            // 
            // buttonLeaver
            // 
            this.buttonLeaver.Location = new System.Drawing.Point(502, 88);
            this.buttonLeaver.Name = "buttonLeaver";
            this.buttonLeaver.Size = new System.Drawing.Size(108, 23);
            this.buttonLeaver.TabIndex = 14;
            this.buttonLeaver.Text = "-1 player";
            this.buttonLeaver.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(350, 211);
            this.dataGridView1.TabIndex = 15;
            // 
            // CoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 448);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonLeaver);
            this.Controls.Add(this.buttonNewPlayer);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.richTextBoxMaterials);
            this.Controls.Add(this.numericPlayer);
            this.Controls.Add(this.chartProfit);
            this.Name = "CoopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoopForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonNewPlayer;
        private System.Windows.Forms.Button buttonLeaver;
        private System.Windows.Forms.DataGridView dataGridView1;
        public System.Windows.Forms.NumericUpDown numericPlayer;
        public System.Windows.Forms.RichTextBox richTextBoxMaterials;
        public System.Windows.Forms.TextBox textBoxProduct;
    }
}