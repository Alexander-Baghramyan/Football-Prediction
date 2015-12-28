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
        SqlCommand cm1, cm2, cm3, cm4, cm5, cm6, cm7, cm8;
        DataSet ds, ds4;
        SqlDataAdapter ap, ap1;



        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'standingDataSet1._BXH_' table. You can move, or remove it, as needed.
            this.bXH_TableAdapter1.Fill(this.standingDataSet1._BXH_);
            // TODO: This line of code loads data into the 'standingDataSet._BXH_' table. You can move, or remove it, as needed.
            this.bXH_TableAdapter.Fill(this.standingDataSet._BXH_);
            // TODO: This line of code loads data into the 'ePLDataSet._db_' table. You can move, or remove it, as needed.
            this.db_TableAdapter.Fill(this.ePLDataSet._db_);
            this.LoadDBComboBox();
            //this.LoadDBListBox();
            cmb1.Text = "Chọn vòng đấu";
            dataGridView1.DataSource = null;
            dataGridView2.DataSource = null;
            phongdodoinha.Text = phongdodoikhach.Text = "Vui lòng chọn 'Thông Tin Trận Đấu'";
        }

        public void LoadDBComboBox()
        {
            con = load.conDB();
            con.Open();
        }

        #region select round and match
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
        #endregion

        #region variales
        string Home = "", Away = "";
        int HomeWin = 0, AwayWin = 0, Draw = 0;//, Home_Pos = 0, Away_Pos = 0;
        int avg_goal =0 , l = 0 , m = 0, u = 0, v = 0; // u: home chap, v: khach chap
        int thangTB_home = 0, thuaTB_home = 0, thangTB_away = 0, thuaTB_away = 0;
        int FTHG = 0, FTAG = 0; // full time home goal, full time away goal
        int sum1 = 0, sum2 = 0, sum3 = 0, sum4 = 0;
        #endregion

        private void btn_info_Click(object sender, EventArgs e)
        {
            FTHG = FTAG = 0;
            avg_goal = 0; u = 0; v = 0; 
            thangTB_home = 0; thuaTB_home = 0; thangTB_away = 0; thuaTB_away = 0;
            HomeWin = 0; AwayWin = 0; Draw = 0; //Home_Pos = 0; Away_Pos = 0;
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            string match = this.cmb2.GetItemText(this.cmb2.SelectedItem);
            try
            {
                if (_select == "Chọn vòng đấu")
                    MessageBox.Show("Vui Lòng Chọn Vòng Đấu Và Trận Đấu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    #region get home name and away name
                    for (int i = 0; i < match.Length; i++)
                    {
                        if (match[i] == '-')
                        {
                            Home = match.Substring(0, i);
                            Away = match.Substring(i + 2, match.Length - i - 2);
                            break;
                        }
                    }
                    #endregion

                    this.label9.Text = "Phong Độ " + Home;
                    this.label8.Text = "Phong Độ " + Away;

                    this.label2.Text = "5 trận gần nhất";
                    this.label3.Text = "5 trận gần nhất";

                    #region thanh tich doi dau
                    cm2 = new SqlCommand("select * from [EPL].[dbo].[db$] where (HomeTeam=@hometeam and AwayTeam=@awayteam) or (HomeTeam=@awayteam and AwayTeam=@hometeam) ORDER BY Date DESC", con);
                    cm2.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm2.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm2.Parameters["@hometeam"].Value = Home;
                    cm2.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm2);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.AllowUserToAddRows = false;
                    DataTable dt = ds.Tables[0];
                    #endregion

                    #region trich database
                    double[] HomeGoals = new double[dt.Rows.Count];
                    double[] AwayGoals = new double[dt.Rows.Count];
                    double[] BetHome = new double[dt.Rows.Count];
                    double[] BetDraw = new double[dt.Rows.Count];
                    double[] BetAway = new double[dt.Rows.Count];
                    double[] _goalhome_1 = new double[dt.Rows.Count];
                    double[] _goalhome_2 = new double[dt.Rows.Count];
                    double[] _goalaway_1 = new double[dt.Rows.Count];
                    double[] _goalaway_2 = new double[dt.Rows.Count];
                    double[] home_chap = new double[dt.Rows.Count];
                    double[] away_chap = new double[dt.Rows.Count];

                    int index = 0;
                    foreach (DataRow row in dt.Rows)
                    {
                        HomeGoals[index] = (double)row["FTHG"];
                        AwayGoals[index] = (double)row["FTAG"];
                        BetHome[index] = (double)row["B365H"];
                        BetDraw[index] = (double)row["B365D"];
                        BetAway[index] = (double)row["B365A"];
                        _goalhome_1[index] = (double)row["BbMx2#5Home"];
                        _goalhome_2[index] = (double)row["BbAv2#5Home"];
                        _goalaway_1[index] = (double)row["BbMx2#5Away"];
                        _goalaway_2[index] = (double)row["BbAv2#5Away"];
                        home_chap[index] = (double)row["BbMxAHH"];
                        away_chap[index] = (double)row["BbMxAHA"];
                        index++;
                    }
                    #endregion

                    #region phongdodoinha

                    this.phongdodoinha.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdodoinha.ForeColor = System.Drawing.Color.Black;

                    cm3 = new SqlCommand("select TOP 5 * from [EPL].[dbo].[db$] where (HomeTeam=@hometeam or AwayTeam=@hometeam) ORDER BY Date DESC", con);
                    //cm3 = new SqlCommand("SELECT TOP 5 * FROM [EPL].[dbo].[db$] WHERE (HomeTeam=@hometeam) union all (SELECT TOP 5 * FROM [EPL].[dbo].[db$] WHERE AwayTeam=@hometeam) ORDER BY Date DESC");
                    cm3.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm3.Parameters["@hometeam"].Value = Home;
                    ap = new SqlDataAdapter(cm3);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdodoinha.DataSource = ds.Tables[0];
                    phongdodoinha.DisplayMember = "HomeResult";

                    DataTable dt2 = ds.Tables[0];

                    string[] phongdo_home = new string[dt2.Rows.Count];
                    int length_1 = 0;
                    foreach (DataRow row in dt2.Rows)
                    {
                        phongdo_home[length_1++] = (string)row["FTR"];
                    }
                    #endregion

                    #region phongdodoikhach
                    this.phongdodoikhach.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdodoikhach.ForeColor = System.Drawing.Color.Black;

                    cm4 = new SqlCommand("select TOP 5 * from [EPL].[dbo].[db$] where (HomeTeam=@awayteam or AwayTeam=@awayteam) ORDER BY Date DESC", con);
                    cm4.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm4.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm4);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdodoikhach.DataSource = ds.Tables[0];
                    phongdodoikhach.DisplayMember = "Result";

                    DataTable dt3 = ds.Tables[0];

                    string[] phongdo_away = new string[dt2.Rows.Count];
                    int length_2 = 0;
                    foreach (DataRow row in dt2.Rows)
                    {
                        phongdo_away[length_2++] = (string)row["FTR"];
                    }
                    #endregion


                    #region phong do doi nha san nha
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

                    /*DataTable dt4 = ds.Tables[0];

                    string[] sannha_home = new string[dt4.Rows.Count];
                    int length_3 = 0;
                    foreach (DataRow row in dt4.Rows)
                    {
                        sannha_home[length_3++] = (string)row["FTR"];
                    }*/
                    #endregion

                    #region phong do doi khach san khach
                    this.phongdosankhach.BackColor = System.Drawing.SystemColors.Window;
                    this.phongdosankhach.ForeColor = System.Drawing.Color.Black;
                    cm6 = new SqlCommand("select TOP 5 AwayResult from [EPL].[dbo].[db$] where AwayTeam=@awayteam ORDER BY Date DESC", con);
                    cm6.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm6.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm6);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[EPL].[dbo].[db$]");
                    phongdosankhach.DataSource = ds.Tables[0];
                    phongdosankhach.DisplayMember = "AwayResult";

                    /*DataTable dt5 = ds.Tables[0];

                    string[] sankhach_away = new string[dt5.Rows.Count];
                    int length_4 = 0;
                    foreach (DataRow row in dt5.Rows)
                    {
                        sankhach_away[length_4++] = (string)row["FTR"];
                    }*/
                    #endregion

                    #region vi tri bxh
                    cm7 = new SqlCommand("select * from [Standing].[dbo].[BXH$] where (CLB=@hometeam or CLB=@awayteam)", con);
                    cm7.Parameters.Add("@hometeam", SqlDbType.NVarChar, -1);
                    cm7.Parameters.Add("@awayteam", SqlDbType.NVarChar, -1);
                    cm7.Parameters["@hometeam"].Value = Home;
                    cm7.Parameters["@awayteam"].Value = Away;
                    ap = new SqlDataAdapter(cm7);
                    ds = new System.Data.DataSet();
                    ap.Fill(ds, "[Standing].[dbo].[BXH$]");
                    DataTable dt1 = ds.Tables[0];

                    int id = 0;
                    double[] Pos = new double[dt1.Rows.Count];
                    double[] banthangTB = new double[dt1.Rows.Count];
                    double[] banthuaTB = new double[dt1.Rows.Count];
                    double[] sotran = new double[dt1.Rows.Count];

                    foreach (DataRow row in dt1.Rows)
                    {
                        Pos[id] = (double)row["XepHang"];
                        banthangTB[id] = (double)row["BanThang"];
                        banthuaTB[id] = (double)row["BanThua"];
                        sotran[id] = (double)row["Tran"];
                        id++;
                    }
                    #endregion

                    #region du doan ket qua
                    #region tieu chi thanh tich doi dau
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
                    #endregion

                    #region tieu chi bang xep hang
                    if (Math.Abs(Pos[0] - Pos[1]) <= 2)
                    {
                        HomeWin++;
                        AwayWin++;
                        Draw++;
                    }
                    else
                    {
                        if (Pos[0] > Pos[1])
                        {
                            HomeWin++;
                        }
                        else
                            AwayWin++;
                    }
                    #endregion

                    #region tieu chi phong do 5 tran gan nhat
                    for (int i = 0; i < length_1; i++)
                    {
                        if (phongdo_home[i] == "H")
                        {
                            HomeWin++;
                        }
                        else
                        {
                            if (phongdo_home[i] == "D")
                                Draw++;
                            else
                                AwayWin++;
                        }
                    }

                    for (int i = 0; i < length_2; i++)
                    {
                        if (phongdo_away[i] == "A")
                        {
                            AwayWin++;
                        }
                        else
                        {
                            if (phongdo_home[i] == "D")
                                Draw++;
                            else
                                HomeWin++;
                        }
                    }
                    #endregion

                    #region tieu chi ty le nha cai
                    double _home = 0, _draw = 0, _away = 0;
                    for (int i = 0; i < index; i++)
                    {
                        _home += BetHome[i];
                        _draw += BetDraw[i];
                        _away += BetAway[i];
                    }

                    if (index != 0)
                    {
                        _home /= (double)index;
                        _draw /= (double)index;
                        _away /= (double)index;
                    }

                    int temp = Math.Max((int)_home, Math.Max((int)_draw, (int)_away));
                    if (temp == _home)
                        HomeWin++;
                    else
                        if (temp == _draw)
                            Draw++;
                        else
                            AwayWin++;
                    #endregion
                    #endregion

                    #region du doan ty so
                    #region tieu chi ty le ca cuoc ban thang
                    double sum_1 = 0, sum_2 = 0, sum_3 = 0, sum_4 = 0;
                    for (int i = 0; i < index; i++)
                    {
                        sum_1 += _goalhome_1[i];
                        sum_2 += _goalhome_2[i];
                        sum_3 += _goalaway_1[i];
                        sum_4 += _goalaway_2[i];
                    }

                    if (index != 0)
                    {
                        sum_1 /= (double)index;
                        sum1 = (int)Math.Round(sum_1, 0);
                        sum_2 /= (double)index;
                        sum2 = (int)Math.Round(sum_2, 0);
                        sum_3 /= (double)index;
                        sum3 = (int)Math.Round(sum_3, 0);
                        sum_4 /= (double)index;
                        sum4 = (int)Math.Round(sum_4, 0);
                    }

                    l = Math.Max(sum1, sum2);
                    m = Math.Max(sum3, sum4);
                    avg_goal = Math.Max(l, m)*2;
                    #endregion

                    #region tieu chi ty le chap
                    double chap_home = 0, chap_away = 0;
                    for (int i = 0; i < index; i++)
                    {
                        chap_home += home_chap[i];
                        chap_away += away_chap[i];
                    }

                    if (index != 0)
                    {
                        chap_home /= (double)index;
                        u = (int)Math.Round(chap_home, 0);

                        chap_away /= (double)index;
                        v = (int)Math.Round(chap_away, 0);
                    }
                    #endregion

                    #region tieu chi ban thang trung binh
                    thangTB_home = (int)Math.Round(banthangTB[0] / sotran[0]);
                    thuaTB_home = (int)Math.Round(banthuaTB[0] / sotran[0]);
                    
                    thangTB_away = (int)Math.Round(banthangTB[1] / sotran[1]);
                    thuaTB_away = (int)Math.Round(banthuaTB[1] / sotran[1]);

                    #endregion
                    
                    #endregion

                    #region reset
                    Array.Clear(HomeGoals, 0, index);
                    Array.Clear(AwayGoals, 0, index);
                    Array.Clear(BetHome, 0, index);
                    Array.Clear(BetAway, 0, index);
                    Array.Clear(BetDraw, 0, index);
                    Array.Clear(Pos, 0, id);
                    Array.Clear(phongdo_home, 0, length_1);
                    Array.Clear(phongdo_away, 0, length_2);
                    Array.Clear(_goalhome_1, 0, index);
                    Array.Clear(_goalhome_2, 0, index);
                    Array.Clear(_goalaway_1, 0, index);
                    Array.Clear(_goalaway_2, 0, index);
                    Array.Clear(home_chap, 0, index);
                    Array.Clear(away_chap, 0, index);
                    #endregion
                }
            }
            #region ex
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            #endregion
        }

        private void btnBXH_Click(object sender, EventArgs e)
        {
            cm8 = new SqlCommand("select * from [Standing].[dbo].[BXH$]", con);
            ap1 = new SqlDataAdapter(cm8);
            ds4 = new System.Data.DataSet();
            ap1.Fill(ds4, "[Standing].[dbo].[BXH$]");
            dataGridView2.DataSource = ds4.Tables[0];
            dataGridView2.AllowUserToAddRows = false;
        }

        private void btn_dudoan_Click(object sender, EventArgs e)
        {
            if (avg_goal == 0) avg_goal += 3;
            string _select = this.cmb1.GetItemText(this.cmb1.SelectedItem);
            try
            {
                if (_select == "Chọn vòng đấu")
                    MessageBox.Show("Vui Lòng Chọn Vòng Đấu Và Trận Đấu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (HomeWin > AwayWin)
                    {
                        do
                        {
                            Random rd = new Random();
                            FTHG = rd.Next(1, avg_goal + v);
                        }
                        while ((Math.Abs(FTHG-thangTB_home) >= 3) || (Math.Abs(FTHG-thuaTB_away) >= 3));

                        do
                        {
                            Random rd = new Random();
                            FTAG = rd.Next(0, avg_goal - FTHG + u);
                        }
                        while ((FTAG < 0) || (FTAG >= FTHG) || (Math.Abs(FTAG - thuaTB_home) >= 3) || (Math.Abs(FTAG - thangTB_away) >= 3));

                        MessageBox.Show(Home + "thắng " + Away + " " + FTHG.ToString() + " - " + FTAG.ToString());
                    }
                    else
                    {
                        if (AwayWin > HomeWin)
                        {
                            do
                            {
                                Random rd = new Random();
                                FTAG = rd.Next(1, avg_goal + u);
                            }
                            while ((Math.Abs(FTAG - thangTB_away) >= 3) || (Math.Abs(FTAG - thuaTB_home) >= 3));

                            do
                            {
                                Random rd = new Random();
                                FTHG = rd.Next(0, avg_goal - FTAG + v);
                            }
                            while ((FTHG < 0) || (FTAG <= FTHG) || (Math.Abs(FTHG - thuaTB_away) >= 3) || (Math.Abs(FTHG - thangTB_home) >= 3));
                            
                            MessageBox.Show(Home + "thua " + Away + " " + FTHG.ToString() + " - " + FTAG.ToString());
                        }
                        else
                        {
                            do
                            {
                                Random rd = new Random();
                                if (v == 0) v = 1;
                                FTHG = rd.Next(0, avg_goal + u / v);
                            }
                            while ((FTHG - thangTB_home >= 3) || (Math.Abs(FTHG - thuaTB_away) >= 3));
                            MessageBox.Show(Home + "hòa " + Away + " " + FTHG.ToString()+ " - " +FTHG.ToString());
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