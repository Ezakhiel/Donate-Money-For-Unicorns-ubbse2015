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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CoopForm));
            this.chartProfit = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.numericPlayer = new System.Windows.Forms.NumericUpDown();
            this.richTextBoxMaterials = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonNewPlayer = new System.Windows.Forms.Button();
            this.buttonLeaver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.richTextBoxPlayerFunc = new System.Windows.Forms.RichTextBox();
            this.dgvCoalition = new System.Windows.Forms.DataGridView();
            this.Coalitions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoalition)).BeginInit();
            this.SuspendLayout();
            // 
            // chartProfit
            // 
            this.chartProfit.BackColor = System.Drawing.Color.WhiteSmoke;
            chartArea1.AxisX.Title = "Coalitions";
            chartArea1.AxisY.Title = "Winning rate";
            chartArea1.Name = "ChartArea1";
            this.chartProfit.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartProfit.Legends.Add(legend1);
            this.chartProfit.Location = new System.Drawing.Point(12, 248);
            this.chartProfit.Name = "chartProfit";
            this.chartProfit.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.MediumSeaGreen;
            series1.Legend = "Legend1";
            series1.Name = "Coalitions";
            series1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series1.YValuesPerPoint = 3;
            this.chartProfit.Series.Add(series1);
            this.chartProfit.Size = new System.Drawing.Size(407, 243);
            this.chartProfit.TabIndex = 0;
            this.chartProfit.Text = "Winning function";
            // 
            // numericPlayer
            // 
            this.numericPlayer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.numericPlayer.Location = new System.Drawing.Point(645, 63);
            this.numericPlayer.Name = "numericPlayer";
            this.numericPlayer.Size = new System.Drawing.Size(144, 20);
            this.numericPlayer.TabIndex = 1;
            // 
            // richTextBoxMaterials
            // 
            this.richTextBoxMaterials.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxMaterials.Location = new System.Drawing.Point(602, 174);
            this.richTextBoxMaterials.Name = "richTextBoxMaterials";
            this.richTextBoxMaterials.Size = new System.Drawing.Size(229, 111);
            this.richTextBoxMaterials.TabIndex = 4;
            this.richTextBoxMaterials.Text = "";
            this.richTextBoxMaterials.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxMaterials_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(678, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Player number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(609, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Incoming players";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(756, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Leavers";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(693, 158);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Materials";
            // 
            // buttonNewPlayer
            // 
            this.buttonNewPlayer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonNewPlayer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonNewPlayer.Location = new System.Drawing.Point(601, 122);
            this.buttonNewPlayer.Name = "buttonNewPlayer";
            this.buttonNewPlayer.Size = new System.Drawing.Size(108, 23);
            this.buttonNewPlayer.TabIndex = 13;
            this.buttonNewPlayer.Text = "+1 player";
            this.buttonNewPlayer.UseVisualStyleBackColor = false;
            this.buttonNewPlayer.Click += new System.EventHandler(this.buttonNewPlayer_Click);
            // 
            // buttonLeaver
            // 
            this.buttonLeaver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.buttonLeaver.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonLeaver.Location = new System.Drawing.Point(726, 122);
            this.buttonLeaver.Name = "buttonLeaver";
            this.buttonLeaver.Size = new System.Drawing.Size(108, 23);
            this.buttonLeaver.TabIndex = 14;
            this.buttonLeaver.Text = "-1 player";
            this.buttonLeaver.UseVisualStyleBackColor = false;
            this.buttonLeaver.Click += new System.EventHandler(this.buttonLeaver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(669, 295);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Player\'s function";
            // 
            // richTextBoxPlayerFunc
            // 
            this.richTextBoxPlayerFunc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.richTextBoxPlayerFunc.Location = new System.Drawing.Point(602, 311);
            this.richTextBoxPlayerFunc.Name = "richTextBoxPlayerFunc";
            this.richTextBoxPlayerFunc.Size = new System.Drawing.Size(229, 111);
            this.richTextBoxPlayerFunc.TabIndex = 16;
            this.richTextBoxPlayerFunc.Text = "";
            this.richTextBoxPlayerFunc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxPlayerFunc_KeyPress);
            // 
            // dgvCoalition
            // 
            this.dgvCoalition.AllowUserToAddRows = false;
            this.dgvCoalition.AllowUserToDeleteRows = false;
            this.dgvCoalition.AllowUserToResizeColumns = false;
            this.dgvCoalition.AllowUserToResizeRows = false;
            this.dgvCoalition.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvCoalition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvCoalition.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
            this.dgvCoalition.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgvCoalition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoalition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Coalitions});
            this.dgvCoalition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgvCoalition.GridColor = System.Drawing.SystemColors.Window;
            this.dgvCoalition.Location = new System.Drawing.Point(12, 12);
            this.dgvCoalition.MultiSelect = false;
            this.dgvCoalition.Name = "dgvCoalition";
            this.dgvCoalition.ReadOnly = true;
            this.dgvCoalition.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvCoalition.RowHeadersVisible = false;
            this.dgvCoalition.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvCoalition.RowTemplate.DefaultCellStyle.Format = "N0";
            this.dgvCoalition.RowTemplate.DefaultCellStyle.NullValue = null;
            this.dgvCoalition.RowTemplate.ReadOnly = true;
            this.dgvCoalition.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCoalition.Size = new System.Drawing.Size(544, 230);
            this.dgvCoalition.TabIndex = 15;
            this.dgvCoalition.SelectionChanged += new System.EventHandler(this.dataGridViewCoalition_SelectionChanged);
            // 
            // Coalitions
            // 
            this.Coalitions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Coalitions.DefaultCellStyle = dataGridViewCellStyle1;
            this.Coalitions.FillWeight = 300F;
            this.Coalitions.HeaderText = "Coalitions";
            this.Coalitions.MinimumWidth = 542;
            this.Coalitions.Name = "Coalitions";
            this.Coalitions.ReadOnly = true;
            this.Coalitions.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Coalitions.Width = 542;
            // 
            // buttonClear
            // 
            this.buttonClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonClear.Location = new System.Drawing.Point(660, 456);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(108, 34);
            this.buttonClear.TabIndex = 18;
            this.buttonClear.Text = "Clear";
            this.buttonClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonStop
            // 
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonStop.Image = global::Dynamic_Games.Properties.Resources.stop;
            this.buttonStop.Location = new System.Drawing.Point(459, 389);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(108, 34);
            this.buttonStop.TabIndex = 12;
            this.buttonStop.Text = "   Stop";
            this.buttonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonStart.Image = ((System.Drawing.Image)(resources.GetObject("buttonStart.Image")));
            this.buttonStart.Location = new System.Drawing.Point(459, 322);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(108, 34);
            this.buttonStart.TabIndex = 6;
            this.buttonStart.Text = "   Start";
            this.buttonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CoopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(878, 502);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.richTextBoxPlayerFunc);
            this.Controls.Add(this.dgvCoalition);
            this.Controls.Add(this.buttonLeaver);
            this.Controls.Add(this.buttonNewPlayer);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.richTextBoxMaterials);
            this.Controls.Add(this.numericPlayer);
            this.Controls.Add(this.chartProfit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CoopForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CoopForm";
            ((System.ComponentModel.ISupportInitialize)(this.chartProfit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericPlayer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoalition)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartProfit;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonNewPlayer;
        private System.Windows.Forms.Button buttonLeaver;
        public System.Windows.Forms.NumericUpDown numericPlayer;
        public System.Windows.Forms.RichTextBox richTextBoxMaterials;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.RichTextBox richTextBoxPlayerFunc;
        private System.Windows.Forms.DataGridView dgvCoalition;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Coalitions;
    }
}