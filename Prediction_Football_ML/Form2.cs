using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Prediction_Football_ML
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        LoadFixture load = new LoadFixture();
        LoadFixture DB = new LoadFixture();
        SqlConnection con,con1;
        SqlCommand cm1,cm2;
        DataSet ds, ds1;
        SqlDataAdapter ap,ap1;



        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'ePLDataSet._db_' table. You can move, or remove it, as needed.
            this.db_TableAdapter.Fill(this.ePLDataSet._db_);
            this.LoadDBComboBox();
            //this.LoadDBListBox();
            cmb1.Text = "Chọn vòng đấu";
            dataGridView1.DataSource = null;
            phongdodoikhach.Text = phongdodoikhach.Text = "Vui lòng chọn vòng đấu và cặp đấu";
            phongdodoikhach.Items.Add("Vui lòng nhấn nút 'Thông Tin Trận Đấu'");
            phongdodoinha.Items.Add("Vui lòng nhấn nút 'Thông Tin Trận Đấu'");
        }

        public void LoadDBComboBox()
        {
            con = load.conDB();
            con.Open();
        }

        /*public void LoadDBListBox()
        {
            con1 = DB.conDB();
            con1.Open();
        }*/

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            cm1 = new SqlCommand("select VS from [Fixtures].[dbo].[lichthidau$] where ROUND=@round", con);
            cm1.Parameters.Add("@round", SqlDbType.NVarChar, -1);
            cm1.Parameters["@round"].Value = _select;
            
            
            ap = new SqlDataAdapter(cm1);
            ds = new System.Data.DataSet();
            ap.Fill(ds, "[Fixtures].[dbo].[lichthidau$]");
            cmb2.DataSource = ds.Tables[0];
            cmb2.DisplayMember = "VS";
        }

        
        private void btn_dudoan_Click(object sender, EventArgs e)
        {
        }


        string Home = "", Away = "";
        private void btn_info_Click(object sender, EventArgs e)
        {
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            string match = this.cmb2.GetItemText(this.cmb2.SelectedItem);
            try
            {
                if (_select == "Chọn vòng đấu")
                    MessageBox.Show("Vui Lòng Chọn Vòng Đấu Và Cặp đấu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    for (int i = 0; i < match.Length; i++)
                    {
                        if (match[i] == '-')
                        {
                            Home = match.Substring(0, i );
                            Away = match.Substring(i + 2, match.Length - i - 2);
                        }
                    }

                    //MessageBox.Show(Away);
                    cm2 = new SqlCommand("select * from [EPL].[dbo].[db$] where HomeTeam=@hometeam and AwayTeam=@awayteam", con);
                    cm2.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm2.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm2.Parameters["@hometeam"].Value = Home;
                    cm2.Parameters["@awayteam"].Value = Away;

                    ap = new SqlDataAdapter(cm2);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    dataGridView1.DataSource = ds.Tables[0];
                    DataTable dt = ds.Tables[0];
                    double[] Values = new double[dt.Rows.Count];
                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        Values[index++] = (double)row["FTHG"];
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}