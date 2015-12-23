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
    class LoadFixture
    {
        public static SqlConnection con = null;
        public SqlConnection conDB()
        {
            string connect = @"Data Source=.\SQLEXPRESS;Initial Catalog=Fixtures;Integrated Security=True";
            SqlConnection con = new SqlConnection(connect);
            return con;
        }

    }
}
