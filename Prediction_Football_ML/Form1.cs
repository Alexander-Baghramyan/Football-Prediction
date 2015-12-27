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

        private void pictureBox2_Click_1(object sender, EventArgs e) // main window
        {
            Form2 giaodien = new Form2();
            giaodien.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e) // exit
        {
            Application.Exit();
        }

        private void pictureBox4_Click(object sender, EventArgs e) // information
        {
            MessageBox.Show("Đồ án môn học: Nhập môn Công Nghệ Tri Thức và Máy Học\nNhóm sinh viên thực hiện:\n- Nguyễn Thành Long - 13520469\n- Nguyễn Duy Hùng - 13520324\n- Lê Trọng Đức - 13520216\n- Nguyễn Văn Trí - 13520924\n- Trần Trung Hiếu - 13520279\n- Trần Văn Thiệt - 13520826\nGVHD: ThS. Nguyễn Đình Hiển", "Thông Tin Sản Phẩm");
        }

        private void pictureBox3_Click(object sender, EventArgs e) // huong dan su dung
        {
            MessageBox.Show("Chọn 'Dự Đoán Tỉ Số' để vào chương trình chính\n\n"
            + "Trong giao diện chương trình, bạn chọn vòng đấu và trận đấu cần dự đoán\n\n"
            + "Để thuật toán máy học có thể dự đoán chính xác nhất có thể, bạn cần phải xem qua các thống kê bằng cách chọn 'Thông Tin Trận Đấu'\n\n"
            + "Chọn 'Dự Đoán Tỉ Số' để dự đoán kết quả trận đâu\n\n"
            + "Bạn cũng có thể xem bảng xếp hạng hiện tại bằng cách chọn 'Bảng Xếp Hạng'\n\n"
            + "Mọi ý kiến đóng góp vui lòng gửi về địa chỉ email 13520469@gm.uit.edu.vn", "Hướng Dẫn Sử Dụng");
        }
    }
}
