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
            this.components = new System.ComponentModel.Container();
            this.cmb1 = new System.Windows.Forms.ComboBox();
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.btn_dudoan = new System.Windows.Forms.Button();
            this.phongdodoikhach = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_info = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.matchDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dbBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.ePLDataSet = new Prediction_Football_ML.EPLDataSet();
            this.db_TableAdapter = new Prediction_Football_ML.EPLDataSetTableAdapters.db_TableAdapter();
            this.phongdodoinha = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePLDataSet)).BeginInit();
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
            this.cmb1.Location = new System.Drawing.Point(129, 66);
            this.cmb1.Name = "cmb1";
            this.cmb1.Size = new System.Drawing.Size(113, 21);
            this.cmb1.TabIndex = 0;
            this.cmb1.SelectedIndexChanged += new System.EventHandler(this.cmb1_SelectedIndexChanged);
            // 
            // cmb2
            // 
            this.cmb2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(377, 67);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(371, 21);
            this.cmb2.TabIndex = 1;
            // 
            // btn_dudoan
            // 
            this.btn_dudoan.Location = new System.Drawing.Point(598, 99);
            this.btn_dudoan.Name = "btn_dudoan";
            this.btn_dudoan.Size = new System.Drawing.Size(126, 33);
            this.btn_dudoan.TabIndex = 2;
            this.btn_dudoan.Text = "Dự Đoán Tỉ Số";
            this.btn_dudoan.UseVisualStyleBackColor = true;
            this.btn_dudoan.Click += new System.EventHandler(this.btn_dudoan_Click);
            // 
            // phongdodoikhach
            // 
            this.phongdodoikhach.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.phongdodoikhach.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phongdodoikhach.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongdodoikhach.ForeColor = System.Drawing.Color.White;
            this.phongdodoikhach.FormattingEnabled = true;
            this.phongdodoikhach.ItemHeight = 20;
            this.phongdodoikhach.Location = new System.Drawing.Point(376, 444);
            this.phongdodoikhach.Name = "phongdodoikhach";
            this.phongdodoikhach.Size = new System.Drawing.Size(372, 220);
            this.phongdodoikhach.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(258, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thành Tích Đối Đầu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(79, 414);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(190, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Phong Độ Đội Nhà";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Yellow;
            this.label3.Location = new System.Drawing.Point(472, 414);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phong Độ Đội Khách";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label4.Location = new System.Drawing.Point(6, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chọn vòng đấu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(260, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Chọn trận đấu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(42, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(654, 36);
            this.label6.TabIndex = 11;
            this.label6.Text = "THÔNG TIN TRẬN ĐẤU VÀ DỰ ĐOÁN TỈ SỐ";
            // 
            // btn_info
            // 
            this.btn_info.Location = new System.Drawing.Point(466, 99);
            this.btn_info.Name = "btn_info";
            this.btn_info.Size = new System.Drawing.Size(117, 33);
            this.btn_info.TabIndex = 12;
            this.btn_info.Text = "Thông Tin Trận Đấu";
            this.btn_info.UseVisualStyleBackColor = true;
            this.btn_info.Click += new System.EventHandler(this.btn_info_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.matchDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.dataGridView1.DataSource = this.dbBindingSource1;
            this.dataGridView1.Location = new System.Drawing.Point(0, 174);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(748, 221);
            this.dataGridView1.TabIndex = 13;
            // 
            // matchDataGridViewTextBoxColumn
            // 
            this.matchDataGridViewTextBoxColumn.DataPropertyName = "Match";
            this.matchDataGridViewTextBoxColumn.HeaderText = "Trận Đấu";
            this.matchDataGridViewTextBoxColumn.Name = "matchDataGridViewTextBoxColumn";
            this.matchDataGridViewTextBoxColumn.Width = 240;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dataGridViewTextBoxColumn1.HeaderText = "Ngày Diễn Ra";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Referee";
            this.dataGridViewTextBoxColumn2.HeaderText = "Trọng Tài";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Result";
            this.dataGridViewTextBoxColumn3.HeaderText = "Kết Quả Chung Cuộc";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 260;
            // 
            // dbBindingSource1
            // 
            this.dbBindingSource1.DataMember = "db$";
            this.dbBindingSource1.DataSource = this.ePLDataSet;
            // 
            // ePLDataSet
            // 
            this.ePLDataSet.DataSetName = "EPLDataSet";
            this.ePLDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // db_TableAdapter
            // 
            this.db_TableAdapter.ClearBeforeFill = true;
            // 
            // phongdodoinha
            // 
            this.phongdodoinha.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.phongdodoinha.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.phongdodoinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phongdodoinha.ForeColor = System.Drawing.Color.White;
            this.phongdodoinha.FormattingEnabled = true;
            this.phongdodoinha.ItemHeight = 20;
            this.phongdodoinha.Location = new System.Drawing.Point(-1, 443);
            this.phongdodoinha.Name = "phongdodoinha";
            this.phongdodoinha.Size = new System.Drawing.Size(372, 220);
            this.phongdodoinha.TabIndex = 14;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(752, 667);
            this.Controls.Add(this.phongdodoinha);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btn_info);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.phongdodoikhach);
            this.Controls.Add(this.btn_dudoan);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.cmb1);
            this.MaximizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.Text = "Dự đoán tỉ số";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dbBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ePLDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb1;
        private System.Windows.Forms.ComboBox cmb2;
        private System.Windows.Forms.Button btn_dudoan;
        private System.Windows.Forms.ListBox phongdodoikhach;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_info;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn refereeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultDataGridViewTextBoxColumn;
        private EPLDataSet ePLDataSet;
        private System.Windows.Forms.BindingSource dbBindingSource1;
        private EPLDataSetTableAdapters.db_TableAdapter db_TableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn matchDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.ListBox phongdodoinha;
    }
}