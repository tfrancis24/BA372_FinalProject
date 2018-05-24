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
        public IList<Result> Results;

        protected void Page_Load(object sender, EventArgs e)
        {
            Results = new List<Result>();
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:/database/database._Complete.accdb";
            string query = "SELECT * FROM reviews";
            using (OleDbConnection con = new OleDbConnection(connectString)) {
                using (OleDbCommand cmd = new OleDbCommand(query, con)) {
                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);
                    Reviews.DataSource = dt;
                    Reviews.DataBind();
                }

                //test result please ignore

                Result result = new Result(
                     "ben",
                    "Beals",
                    "Tim",
                    "Francis",
                    "HR",
                    "2"
                );
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        public class Result
        {
            public string Firstname;
            public string Lastname;
            public string manager_first;
            public string manager_last;
            public string bureau;
            public string progress;

            public Result(string _first, string _last, string _manager_first, string _manager_last, string _bureau, string _progress)
            {
                Firstname = _first;
                Lastname = _last;
                manager_first = _manager_first;
                manager_last = _manager_last;
                bureau = _bureau;
                progress = _progress;
            }
        }
    }
}