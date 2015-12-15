using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prediction_Football_ML
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Đồ án môn học: Nhập môn Công Nghệ Tri Thức và Máy Học\nNhóm sinh viên thực hiện:\n- Nguyễn Thành Long - 13520469\n- Nguyễn Duy Hùng - 13520...\n- Lê Trọng Đức - 13520...\n- Trần Văn Trí - 13520...\n- Trần Trung Hiếu - 13520...\n- Trần Văn Thiệt - 13520...\nGVHD: ThS. Nguyễn Đình Hiển", "Thông Tin Sản Phẩm");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Main = new Form2();
            Main.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
