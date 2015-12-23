namespace Prediction_Football_ML
{
    partial class Form2
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
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.btn_dudoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmb1
            // 
            this.cmb1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb1.FormattingEnabled = true;
            this.cmb1.Items.AddRange(new object[] {
            "Chọn vòng đấu",
            "Vòng 1",
            "Vòng 2",
            "Vòng 3",
            "Vòng 4",
            "Vòng 5",
            "Vòng 6",
            "Vòng 7",
            "Vòng 8",
            "Vòng 9",
            "Vòng 10",
            "Vòng 11",
            "Vòng 12",
            "Vòng 13",
            "Vòng 14",
            "Vòng 15",
            "Vòng 16",
            "Vòng 17",
            "Vòng 18",
            "Vòng 19",
            "Vòng 20",
            "Vòng 21",
            "Vòng 22",
            "Vòng 23",
            "Vòng 24",
            "Vòng 25",
            "Vòng 26",
            "Vòng 27",
            "Vòng 28",
            "Vòng 29",
            "Vòng 30",
            "Vòng 31",
            "Vòng 32",
            "Vòng 33",
            "Vòng 34",
            "Vòng 35",
            "Vòng 36",
            "Vòng 37",
            "Vòng 38"});
            this.cmb1.Location = new System.Drawing.Point(27, 133);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(146, 21);
            this.cmb1.TabIndex = 0;
            this.cmb1.SelectedIndexChanged += new System.EventHandler(this.cmb1_SelectedIndexChanged);
            // 
            // cmb2
            // 
            this.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(198, 133);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(519, 21);
            this.cmb2.TabIndex = 1;
            // 
            // btn_dudoan
            // 
            this.btn_dudoan.Location = new System.Drawing.Point(581, 172);
            this.btn_dudoan.Name = "btn_dudoan";
            this.btn_dudoan.Size = new System.Drawing.Size(104, 38);
            this.btn_dudoan.TabIndex = 2;
            this.btn_dudoan.Text = "Dự Đoán";
            this.btn_dudoan.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(729, 562);
            this.Controls.Add(this.btn_dudoan);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.cmb1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.ComboBox cmb2;
        private System.Windows.Forms.Button btn_dudoan;
    }
}