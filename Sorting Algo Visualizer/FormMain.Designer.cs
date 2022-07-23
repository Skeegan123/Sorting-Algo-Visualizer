namespace Sorting_Algo_Visualizer
{
    partial class FormMain
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
            this.pbSort = new System.Windows.Forms.PictureBox();
            this.cbAlgo = new System.Windows.Forms.ComboBox();
            this.tbSamples = new System.Windows.Forms.TrackBar();
            this.tbSpeed = new System.Windows.Forms.TrackBar();
            this.cbArr = new System.Windows.Forms.ComboBox();
            this.bSort = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // pbSort
            // 
            this.pbSort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbSort.Location = new System.Drawing.Point(13, 13);
            this.pbSort.Name = "pbSort";
            this.pbSort.Size = new System.Drawing.Size(775, 370);
            this.pbSort.TabIndex = 0;
            this.pbSort.TabStop = false;
            // 
            // cbAlgo
            // 
            this.cbAlgo.FormattingEnabled = true;
            this.cbAlgo.Items.AddRange(new object[] {
            "Bubble Sort",
            "Selection Sort",
            "Merge Sort",
            "QuickSort",
            "Built-In Sort"});
            this.cbAlgo.Location = new System.Drawing.Point(11, 409);
            this.cbAlgo.Name = "cbAlgo";
            this.cbAlgo.Size = new System.Drawing.Size(775, 28);
            this.cbAlgo.TabIndex = 1;
            // 
            // tbSamples
            // 
            this.tbSamples.LargeChange = 10;
            this.tbSamples.Location = new System.Drawing.Point(13, 475);
            this.tbSamples.Maximum = 1000;
            this.tbSamples.Minimum = 10;
            this.tbSamples.Name = "tbSamples";
            this.tbSamples.Size = new System.Drawing.Size(235, 69);
            this.tbSamples.TabIndex = 8;
            this.tbSamples.Value = 100;
            this.tbSamples.Scroll += new System.EventHandler(this.tbSamples_Scroll);
            // 
            // tbSpeed
            // 
            this.tbSpeed.Location = new System.Drawing.Point(273, 475);
            this.tbSpeed.Maximum = 20;
            this.tbSpeed.Minimum = 1;
            this.tbSpeed.Name = "tbSpeed";
            this.tbSpeed.Size = new System.Drawing.Size(235, 69);
            this.tbSpeed.TabIndex = 11;
            this.tbSpeed.Value = 7;
            // 
            // cbArr
            // 
            this.cbArr.FormattingEnabled = true;
            this.cbArr.Items.AddRange(new object[] {
            "Random Sample",
            "Reversed"});
            this.cbArr.Location = new System.Drawing.Point(541, 475);
            this.cbArr.Name = "cbArr";
            this.cbArr.Size = new System.Drawing.Size(246, 28);
            this.cbArr.TabIndex = 4;
            // 
            // bSort
            // 
            this.bSort.Location = new System.Drawing.Point(11, 524);
            this.bSort.Name = "bSort";
            this.bSort.Size = new System.Drawing.Size(776, 46);
            this.bSort.TabIndex = 5;
            this.bSort.Text = "Sort";
            this.bSort.UseVisualStyleBackColor = true;
            this.bSort.Click += new System.EventHandler(this.bSort_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 449);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "# of Samples: 100";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 449);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Sorting Speed:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(537, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Random or Reverse?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 386);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Sorting Algorithm:";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 582);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bSort);
            this.Controls.Add(this.cbArr);
            this.Controls.Add(this.tbSpeed);
            this.Controls.Add(this.tbSamples);
            this.Controls.Add(this.cbAlgo);
            this.Controls.Add(this.pbSort);
            this.Name = "FormMain";
            this.Text = "Sorting Algorithm Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSamples)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSort;
        private System.Windows.Forms.ComboBox cbAlgo;
        private System.Windows.Forms.TrackBar tbSamples;
        private System.Windows.Forms.TrackBar tbSpeed;
        private System.Windows.Forms.ComboBox cbArr;
        private System.Windows.Forms.Button bSort;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

