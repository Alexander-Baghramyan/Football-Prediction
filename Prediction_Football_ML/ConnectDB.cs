using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Prediction_Football_ML
{
    class ConnectDB
    {
        public static SqlConnection con = null;
        public static void OpenConnect()
        {
            try
            {
                string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=EPL;Integrated Security=True";
                con = new SqlConnection(connect);
                con.Open();
            }
            catch
            {
                MessageBox.Show("Không thể kết nối cơ sở dữ liệu");
            }
        }

        public static void CloseConnect()
        {
            try
            {
                string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=EPL;Integrated Security=True";
                con = new SqlConnection(connect);
                con.Close();
            }
            catch
            {
            }
        }

        public static DataTable ex(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static void exc(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public static DataTable LayBang(string TenBang)
        {
            string sql = ("select * from") + TenBang;
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmb = new SqlCommandBuilder(da);
            DataSet ds = new DataSet();
            da.Fill(ds, TenBang);
            return ds.Tables[0];
        }
    }
}
