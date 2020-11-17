using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace dashNew1
{
    class Connect_DB
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public Connect_DB()
        {
            con = new SqlConnection("Data Source=DESKTOP-7EJV26G;Initial Catalog=insertpic;Integrated Security=True");
        }
        public int save_update_delete(string q)
        {

            opencon();
            cmd = new SqlCommand(q, con);
            int i = cmd.ExecuteNonQuery();
            closecon();
            return i;
        }
        public DataTable getData(string a)
        {
            opencon();
            SqlDataAdapter da = new SqlDataAdapter(a, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            closecon();
            return dt;
        }



    }
}
