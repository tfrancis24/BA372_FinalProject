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
        public IList<Results> Results;

        protected void Page_Load(object sender, EventArgs e)
        {
            Results = new List<Results>();
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

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }

    public class Results
    {
        string first { get; set; }
        string last { get; set; }
        string manager_first { get; set; }
        string manager_last { get; set; }
        string bureau { get; set; }
        string progress { get; set; }

        public Results(string frist,string last,string manager_first,string manager_last,string bureau,string progress)
        {
            this.first = first;
            this.last = last;
            this.manager_first = manager_first;
            this.manager_last = manager_last;
            this.bureau = bureau;
            this.progress = progress;
        }
    }
}