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
        SqlConnection con;
        SqlCommand cm1;
        DataSet ds;
        SqlDataAdapter ap;



        private void Form2_Load(object sender, EventArgs e)
        {
            this.LoadDBComboBox();
            cmb1.Text = "Chọn vòng đấu";
            cmb2.Text = "Vui lòng chọn vòng đấu";
        }

        public void LoadDBComboBox()
        {
            con = load.conDB();
            con.Open();
        }

        private void cmb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string select = this.cmb1.GetItemText(this.cmb1.SelectedItem);

            cm1 = new SqlCommand("select VS from [Fixtures].[dbo].[lichthidau$] where ROUND=@round", con);
            cm1.Parameters.Add("@round", SqlDbType.NVarChar, -1);
            cm1.Parameters["@round"].Value = select;
            
            
            ap = new SqlDataAdapter(cm1);
            ds = new System.Data.DataSet();
            ap.Fill(ds, "[Fixtures].[dbo].[lichthidau$]");
            cmb2.DataSource = ds.Tables[0];
            cmb2.DisplayMember = "VS";
        }
    }
}