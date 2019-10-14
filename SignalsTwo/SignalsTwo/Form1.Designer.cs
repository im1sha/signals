namespace SignalsTwo
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.amplitudesDeltaChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selectN2 = new System.Windows.Forms.ComboBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.rootMeanSquareDeltaChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.rootMeanSquareDeltaChart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.selectPhi = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.selectN1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.amplitudesDeltaChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootMeanSquareDeltaChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootMeanSquareDeltaChart2)).BeginInit();
            this.SuspendLayout();
            // 
            // amplitudesDeltaChart
            // 
            chartArea1.Name = "ChartArea1";
            this.amplitudesDeltaChart.ChartAreas.Add(chartArea1);
            this.amplitudesDeltaChart.Location = new System.Drawing.Point(58, 135);
            this.amplitudesDeltaChart.Margin = new System.Windows.Forms.Padding(4);
            this.amplitudesDeltaChart.Name = "amplitudesDeltaChart";
            this.amplitudesDeltaChart.Size = new System.Drawing.Size(500, 500);
            this.amplitudesDeltaChart.TabIndex = 0;
            this.amplitudesDeltaChart.Text = "chart1";
            // 
            // selectN2
            // 
            this.selectN2.FormattingEnabled = true;
            this.selectN2.Items.AddRange(new object[] {
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.selectN2.Location = new System.Drawing.Point(261, 59);
            this.selectN2.Margin = new System.Windows.Forms.Padding(4);
            this.selectN2.Name = "selectN2";
            this.selectN2.Size = new System.Drawing.Size(160, 24);
            this.selectN2.TabIndex = 3;
            this.selectN2.Text = "2048";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.Location = new System.Drawing.Point(650, 56);
            this.buttonCalculate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 28);
            this.buttonCalculate.TabIndex = 4;
            this.buttonCalculate.Text = "Calculate";
            this.buttonCalculate.UseVisualStyleBackColor = true;
            this.buttonCalculate.Click += new System.EventHandler(this.Execute);
            // 
            // rootMeanSquareDeltaChart1
            // 
            chartArea2.Name = "ChartArea1";
            this.rootMeanSquareDeltaChart1.ChartAreas.Add(chartArea2);
            this.rootMeanSquareDeltaChart1.Location = new System.Drawing.Point(566, 135);
            this.rootMeanSquareDeltaChart1.Margin = new System.Windows.Forms.Padding(4);
            this.rootMeanSquareDeltaChart1.Name = "rootMeanSquareDeltaChart1";
            this.rootMeanSquareDeltaChart1.Size = new System.Drawing.Size(500, 500);
            this.rootMeanSquareDeltaChart1.TabIndex = 5;
            this.rootMeanSquareDeltaChart1.Text = "chart2";
            // 
            // rootMeanSquareDeltaChart2
            // 
            chartArea3.Name = "ChartArea1";
            this.rootMeanSquareDeltaChart2.ChartAreas.Add(chartArea3);
            this.rootMeanSquareDeltaChart2.Location = new System.Drawing.Point(1045, 135);
            this.rootMeanSquareDeltaChart2.Margin = new System.Windows.Forms.Padding(4);
            this.rootMeanSquareDeltaChart2.Name = "rootMeanSquareDeltaChart2";
            this.rootMeanSquareDeltaChart2.Size = new System.Drawing.Size(500, 500);
            this.rootMeanSquareDeltaChart2.TabIndex = 6;
            this.rootMeanSquareDeltaChart2.Text = "chart3";
            // 
            // selectPhi
            // 
            this.selectPhi.FormattingEnabled = true;
            this.selectPhi.Items.AddRange(new object[] {
            "0",
            "7.5",
            "15",
            "22.5",
            "30",
            "37.5",
            "45",
            "52.5",
            "60",
            "67.5",
            "75",
            "82.5",
            "90",
            "105",
            "120",
            "135",
            "150",
            "165",
            "180",
            "210",
            "240",
            "270",
            "315"});
            this.selectPhi.Location = new System.Drawing.Point(453, 59);
            this.selectPhi.Margin = new System.Windows.Forms.Padding(4);
            this.selectPhi.Name = "selectPhi";
            this.selectPhi.Size = new System.Drawing.Size(160, 24);
            this.selectPhi.TabIndex = 8;
            this.selectPhi.Text = "22.5";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(258, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "N2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(450, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Phi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "N1";
            // 
            // selectN1
            // 
            this.selectN1.FormattingEnabled = true;
            this.selectN1.Items.AddRange(new object[] {
            "64",
            "128",
            "256",
            "512",
            "1024",
            "2048"});
            this.selectN1.Location = new System.Drawing.Point(69, 59);
            this.selectN1.Margin = new System.Windows.Forms.Padding(4);
            this.selectN1.Name = "selectN1";
            this.selectN1.Size = new System.Drawing.Size(160, 24);
            this.selectN1.TabIndex = 11;
            this.selectN1.Text = "64";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1644, 664);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.selectN1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.selectPhi);
            this.Controls.Add(this.rootMeanSquareDeltaChart2);
            this.Controls.Add(this.rootMeanSquareDeltaChart1);
            this.Controls.Add(this.buttonCalculate);
            this.Controls.Add(this.selectN2);
            this.Controls.Add(this.amplitudesDeltaChart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "SignalsTwo";
            ((System.ComponentModel.ISupportInitialize)(this.amplitudesDeltaChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootMeanSquareDeltaChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rootMeanSquareDeltaChart2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart amplitudesDeltaChart;
        private System.Windows.Forms.ComboBox selectN2;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.DataVisualization.Charting.Chart rootMeanSquareDeltaChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart rootMeanSquareDeltaChart2;
        private System.Windows.Forms.ComboBox selectPhi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectN1;
    }
}

