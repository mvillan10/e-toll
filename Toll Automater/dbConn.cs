using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;


namespace Toll_Automater
{
    class dbConn
    {
        public SqlCommand OSC;
        public DataSet DS = new DataSet();
        public static string SCS = ConfigurationManager.ConnectionStrings["dbconn"].ConnectionString;
        public SqlConnection OCN = new SqlConnection(SCS);
        public SqlDataAdapter ODA;
        //    public SqlDataReader ODR;
        public DataTable DT = new DataTable();

        public void OpenConnection()
        {
            try
            {
                OCN.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed!! " + ex.Message.ToString(), "Class DB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

       


        public void ExcecuteQuery(string strquery)
        {
            SqlCommand OSC = new SqlCommand(strquery, OCN);
            SqlDataAdapter ODA = new SqlDataAdapter(OSC);
            ODA.Fill(DS);
            ODA.Fill(DT);
            OCN.Close(); 

        }

        public void ExcecuteNonQuery(string strquery)
        {
            try
            {
                OCN.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed!!", "Class DB", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            SqlCommand OSC = new SqlCommand(strquery, OCN);
            OSC.ExecuteNonQuery();
            OCN.Close();

        }

    }
}
