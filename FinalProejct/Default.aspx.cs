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

                //test result please ignore
                Result result = new Result(
"102569",
"ben",
"Beals",
"Tim",
"Francis",
"HR",
"2",
"6/12/2017"
);

                Results.Add(result);
          
            //}
        }

        //When clicked, populates a table
        protected void Button1_Click(object sender, EventArgs e)
        {
            Result result = new Result(
"123456",
"Jim",
"Smith",
"Tim",
"Francis",
"HR",
"2",
"9/12/2013"
);

            Results.Add(result);
            GetSQL("SELECT FirstName, LastName, StartDate, EndDate FROM Employee INNER JOIN Manager_Employee ON Employee.EmployeeID = Manager_Employee.ManagerID;");
        }

        //Gets SQL query data & stores it in the list
        public void GetSQL(string query)
        {
            Results = new List<Result>();
            //string query = "SELECT * FROM reviews";
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:/database/database._Complete.accdb";
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

                    foreach (DataRow row in dt.Rows)
                    {
                        Result r = new Result(dr["FirstName"].ToString(), dr["LastName"].ToString(), dr["Bureau"].ToString(), dr["StartDate"].ToString(), dr["Progress"].ToString());
                    }
                }

            }
    }

        public class Result
        {
            public string ID;
            public string Firstname;
            public string Lastname;
            public string manager_first;
            public string manager_last;
            public string bureau;
            public string progress;
            public string startDate;

            public Result(string _ID,string _first, string _last, string _manager_first, string _manager_last, string _bureau,string _startDate, string _progress)

            {
                ID = _ID;
                startDate = _startDate;
                Firstname = _first;
                Lastname = _last;
                manager_first = _manager_first;
                manager_last = _manager_last;
                bureau = _bureau;
                progress = _progress;
            }

            public Result(string _ID, string _last, string _manager_last, string _bureau, string _startDate, string _progress)
            {
                ID = _ID;
                startDate = _startDate;
                Lastname = _last;
                manager_last = _manager_last;
                bureau = _bureau;
                progress = _progress;
            }

        }
    }
}