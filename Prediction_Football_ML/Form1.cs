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

        private void pictureBox2_Click_1(object sender, EventArgs e) // main window
        {
            Form2 giaodien = new Form2();
            giaodien.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e) // exit
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e) // information
        {
            MessageBox.Show("Đồ Án Nhập Môn Công Nghệ Tri Thức và Máy Học\nNhóm sinh viên thực hiện:\n- Nguyễn Thành Long - 13520469\n- Nguyễn Duy Hùng - 13520...\n- Lê Trọng Đức - 13520...\n- Trần Trung Hiếu - 13520...\n- Trần Văn Thiệt - 13520...\n- Nguyễn Văn Trí - 13520...\n- Giảng viên hướng dẫn: ThS Nguyễn Đình Hiển","Thông Tin Sản Phẩm");
        }

        private void pictureBox3_Click(object sender, EventArgs e) // huong dan su dung
        {
            MessageBox.Show("Chương trình rất dễ sử dụng, mọi thông tin góp ý vui lòng gửi qua email 13520469@gm.uit.edu.vn", "Hướng Dẫn Sử Dụng");
        }
    }
}
