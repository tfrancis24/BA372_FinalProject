using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;

namespace WebApplication2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:/database/database._Complete.accdb";
            string query = "SELECT * FROM reviews";
            using (OleDbConnection con = new OleDbConnection(connectString))
            {
                using (OleDbCommand cmd = new OleDbCommand(query, con))
                {
                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    Reviews.DataSource = dt;
                    Reviews.DataBind();
                }
            }
        }
    }
}