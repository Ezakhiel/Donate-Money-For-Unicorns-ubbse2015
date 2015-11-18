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
            this.panelCoalition = new System.Windows.Forms.Panel();
            this.numericUDPayersNo = new System.Windows.Forms.NumericUpDown();
            this.numericUDNewPlayer = new System.Windows.Forms.NumericUpDown();
            this.numericUDPlayerLeft = new System.Windows.Forms.NumericUpDown();
            this.textBoxMaterials = new System.Windows.Forms.TextBox();
            this.textBoxProduct = new System.Windows.Forms.TextBox();
            this.buttonShow = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDPayersNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDNewPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDPlayerLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProfit
            // 
            this.chartProfit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            chartArea2.Name = "ChartArea1";
            this.chartProfit.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.chartProfit.Legends.Add(legend2);
            this.chartProfit.Location = new System.Drawing.Point(12, 266);
            this.chartProfit.Name = "chartProfit";
            this.chartProfit.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.chartProfit.Series.Add(series2);
            this.chartProfit.Size = new System.Drawing.Size(356, 250);
            this.chartProfit.TabIndex = 0;
            this.chartProfit.Text = "Profit";
            // 
            // panelCoalition
            // 
            this.panelCoalition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCoalition.Location = new System.Drawing.Point(12, 12);
            this.panelCoalition.Name = "panelCoalition";
            this.panelCoalition.Size = new System.Drawing.Size(356, 248);
            this.panelCoalition.TabIndex = 1;
            // 
            // numericUDPayersNo
            // 
            this.numericUDPayersNo.Location = new System.Drawing.Point(418, 31);
            this.numericUDPayersNo.Name = "numericUDPayersNo";
            this.numericUDPayersNo.Size = new System.Drawing.Size(155, 20);
            this.numericUDPayersNo.TabIndex = 0;
            // 
            // numericUDNewPlayer
            // 
            this.numericUDNewPlayer.Location = new System.Drawing.Point(387, 98);
            this.numericUDNewPlayer.Name = "numericUDNewPlayer";
            this.numericUDNewPlayer.Size = new System.Drawing.Size(97, 20);
            this.numericUDNewPlayer.TabIndex = 2;
            // 
            // numericUDPlayerLeft
            // 
            this.numericUDPlayerLeft.Location = new System.Drawing.Point(512, 98);
            this.numericUDPlayerLeft.Name = "numericUDPlayerLeft";
            this.numericUDPlayerLeft.Size = new System.Drawing.Size(97, 20);
            this.numericUDPlayerLeft.TabIndex = 3;
            // 
            // textBoxMaterials
            // 
            this.textBoxMaterials.Location = new System.Drawing.Point(387, 160);
            this.textBoxMaterials.Multiline = true;
            this.textBoxMaterials.Name = "textBoxMaterials";
            this.textBoxMaterials.Size = new System.Drawing.Size(222, 75);
            this.textBoxMaterials.TabIndex = 4;
            // 
            // textBoxProduct
            // 
            this.textBoxProduct.Location = new System.Drawing.Point(387, 281);
            this.textBoxProduct.Name = "textBoxProduct";
            this.textBoxProduct.Size = new System.Drawing.Size(222, 20);
            this.textBoxProduct.TabIndex = 5;
            // 
            // buttonShow
            // 
            this.buttonShow.Location = new System.Drawing.Point(388, 493);
            this.buttonShow.Name = "buttonShow";
            this.buttonShow.Size = new System.Drawing.Size(97, 23);
            this.buttonShow.TabIndex = 6;
            this.buttonShow.Text = "Show";
            this.buttonShow.UseVisualStyleBackColor = true;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(513, 493);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(97, 23);
            this.buttonReset.TabIndex = 7;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(449, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Number of players";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(392, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Incoming players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(534, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Leavers";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(471, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Materials";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(473, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Product";
            // 
            // CoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 528);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonShow);
            this.Controls.Add(this.textBoxProduct);
            this.Controls.Add(this.textBoxMaterials);
            this.Controls.Add(this.numericUDPlayerLeft);
            this.Controls.Add(this.numericUDNewPlayer);
            this.Controls.Add(this.numericUDPayersNo);
            this.Controls.Add(this.panelCoalition);
            this.Controls.Add(this.chartProfit);
            this.Name = "CoopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoopForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDPayersNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDNewPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUDPlayerLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfit;
        private System.Windows.Forms.Panel panelCoalition;
        private System.Windows.Forms.NumericUpDown numericUDPayersNo;
        private System.Windows.Forms.NumericUpDown numericUDNewPlayer;
        private System.Windows.Forms.NumericUpDown numericUDPlayerLeft;
        private System.Windows.Forms.TextBox textBoxMaterials;
        private System.Windows.Forms.TextBox textBoxProduct;
        private System.Windows.Forms.Button buttonShow;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}