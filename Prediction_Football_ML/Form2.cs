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
        SqlConnection con;
        SqlCommand cm1,cm2,cm3,cm4,cm5,cm6;
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
            phongdodoinha.Text = phongdodoikhach.Text = "Vui lòng chọn 'Thông Tin Trận Đấu'";
        }

        public void LoadDBComboBox()
        {
            con = load.conDB();
            con.Open();
        }

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
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            try
            {
                if (_select == "Chọn vòng đấu")
                    MessageBox.Show("Vui Lòng Chọn Vòng Đấu Và Trận Đấu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (HomeWin > AwayWin) MessageBox.Show(Home + " thắng");
                    else
                    {
                        if (AwayWin > HomeWin) MessageBox.Show(Away + " thắng");
                        else
                            MessageBox.Show("Hai đội hòa nhau");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


        string Home = "", Away = "";
        int HomeWin = 0, AwayWin = 0, Draw = 0;

        private void btn_info_Click(object sender, EventArgs e)
        {
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            string match = this.cmb2.GetItemText(this.cmb2.SelectedItem);
            try
            {
                if (_select == "Chọn vòng đấu")
                    MessageBox.Show("Vui Lòng Chọn Vòng Đấu Và Trận Đấu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    this.label9.Text += Home;
                    this.label8.Text += Away;

                    this.label2.Text = "5 trận gần nhất";
                    this.label3.Text = "5 trận gần nhất";

                    //MessageBox.Show(Away);
                    cm2 = new SqlCommand("select * from [EPL].[dbo].[db$] where (HomeTeam=@hometeam and AwayTeam=@awayteam) or (HomeTeam=@awayteam and AwayTeam=@hometeam) ORDER BY Date DESC", con);
                    cm2.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm2.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm2.Parameters["@hometeam"].Value = Home;
                    cm2.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm2);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    dataGridView1.DataSource = ds.Tables[0];
                    DataTable dt = ds.Tables[0];
                    double[] HomeGoals = new double[dt.Rows.Count];
                    double[] AwayGoals = new double[dt.Rows.Count];
                    

                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        HomeGoals[index] = (double)row["FTHG"];
                        AwayGoals[index] = (double)row["FTAG"];
                        index++;
                    }

                    this.phongdodoinha.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdodoinha.ForeColor = System.Drawing.Color.Black;
                    cm3 = new SqlCommand("select TOP 5 Result from [EPL].[dbo].[db$] where (HomeTeam=@hometeam or AwayTeam=@hometeam) ORDER BY Date DESC", con);
                    cm3.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm3.Parameters["@hometeam"].Value = Home;
                    ap = new SqlDataAdapter(cm3);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdodoinha.DataSource = ds.Tables[0];
                    phongdodoinha.DisplayMember = "Result";

                    this.phongdodoikhach.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdodoikhach.ForeColor = System.Drawing.Color.Black;
                    cm4 = new SqlCommand("select TOP 5 Result from [EPL].[dbo].[db$] where (HomeTeam=@awayteam or AwayTeam=@awayteam) ORDER BY Date DESC", con);
                    cm4.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm4.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm4);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdodoikhach.DataSource = ds.Tables[0];
                    phongdodoikhach.DisplayMember = "Result";


                    this.phongdosannha.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdosannha.ForeColor = System.Drawing.Color.Black;
                    cm5 = new SqlCommand("select TOP 5 Result from [EPL].[dbo].[db$] where HomeTeam=@hometeam ORDER BY Date DESC", con);
                    cm5.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm5.Parameters["@hometeam"].Value = Home;
                    ap = new SqlDataAdapter(cm5);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdosannha.DataSource = ds.Tables[0];
                    phongdosannha.DisplayMember = "Result";

                    this.phongdosankhach.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdosankhach.ForeColor = System.Drawing.Color.Black;
                    cm6 = new SqlCommand("select TOP 5 Result from [EPL].[dbo].[db$] where AwayTeam=@awayteam ORDER BY Date DESC", con);
                    cm6.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm6.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm6);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdosankhach.DataSource = ds.Tables[0];
                    phongdosankhach.DisplayMember = "Result";


                    for (int i = 0; i < index; i++)
                    {
                        if (HomeGoals[i] > AwayGoals[i]) HomeWin++;
                        else
                        {
                            if (HomeGoals[i] < AwayGoals[i]) AwayWin++;
                            else
                                Draw++;
                        }
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