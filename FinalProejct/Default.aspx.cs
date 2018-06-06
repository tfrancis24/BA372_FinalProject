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
            GetSQL(@"
            SELECT Employee.EmployeeID,
                FirstName, 
                LastName, 
                Employee_Bureau.StartDate,
                Manager_Employee.ManagerID,
                Bureaus.BureauName,
                ReviewStatus.ReviewStatusID,
                Employee_Bureau.BureauID
            FROM Employee, Employee_Bureau, ReviewStatus, Reviews, Bureaus, Manager_Employee
            WHERE Employee.EmployeeID = Employee_Bureau.EmployeeID 
            AND Employee_Bureau.Employee_BureauID = Reviews.Employee_BureauID
            AND Reviews.ReviewStatusID = ReviewStatus.ReviewStatusID
            AND Bureaus.BureauID = Employee_Bureau.BureauID
            AND Manager_Employee.Manager_EmployeeID = Reviews.Manager_EmployeeID;
                ");
        }

        //When clicked, returns results from query based by the first name
        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstname = TextBox1.Text;
            string lastname = TextBox2.Text;
            string status = (Int32.Parse(DropDownList2.SelectedValue)-1).ToString();
            string bureau = (Int32.Parse(DropDownList1.SelectedValue) - 1).ToString();
            Results = new List<Result>();
            GetSQL(@"
            SELECT Employee.EmployeeID,
                FirstName, 
                LastName, 
                Employee_Bureau.StartDate,
                Manager_Employee.ManagerID,
                Bureaus.BureauName,
                ReviewStatus.ReviewStatusID,
                Employee_Bureau.BureauID
            FROM Employee, Employee_Bureau, ReviewStatus, Reviews, Bureaus, Manager_Employee
            WHERE Employee.EmployeeID = Employee_Bureau.EmployeeID 
            AND Employee_Bureau.Employee_BureauID = Reviews.Employee_BureauID
            AND Reviews.ReviewStatusID = ReviewStatus.ReviewStatusID
            AND Bureaus.BureauID = Employee_Bureau.BureauID
            AND Manager_Employee.Manager_EmployeeID = Reviews.Manager_EmployeeID;
                ");

            //post presentation, taking a shortcut to get the rest of the search working

            if (firstname != "")
                Results = Results.Where(review => review.Firstname.ToLower() == firstname.ToLower()).ToList();

            if (lastname != "")
                Results = Results.Where(review => review.Lastname.ToLower() == lastname.ToLower()).ToList();

            if (status != "0") 
                Results = Results.Where(review => review.progress == status).ToList();
            
            if (bureau != "0") 
                Results = Results.Where(review => review.bureauID == bureau).ToList();
            


        }

        //When clicked, runs a query that returns results w/ the last name
        protected void Button2_Click(object sender, EventArgs e)
        {
            GetSQL(@"
                SELECT Employee.EmployeeID,
                Firstname, 
                Lastname, 
                Employee_Bureau.StartDate,
                Manager_Employee.ManagerID,
                Bureaus.BureauName,
                Reviews.ReviewStatusID,
                ReviewStatus.ReviewStatus.
                Employee_Bureau.BureauID
                FROM Employee, Employee_Bureau, ReviewStatus, Reviews, Bureaus, Manager_Employee
                WHERE (Employee.LastName = '" + TextBox2.Text + @"')
                AND Employee.EmployeeID = Employee_Bureau.EmployeeID 
                AND Employee_Bureau.Employee_BureauID = Reviews.Employee_BureauID
                AND Reviews.ReviewStatusID = ReviewStatus.ReviewStatusID
                AND Bureaus.BureauID = Employee_Bureau.BureauID
                AND Manager_Employee.Manager_EmployeeID = Reviews.Manager_EmployeeID;
                ");
        }

        //Gets SQL query data & stores it in the list
        public void GetSQL(string query)
        {
            Results.Clear();
            //string query = "SELECT * FROM reviews";
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:/database/database._Complete.accdb";
            using (OleDbConnection con = new OleDbConnection(connectString)) {
                using (OleDbCommand cmd = new OleDbCommand(query, con)) {
                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    foreach (DataRow row in dt.Rows) {
                        Result r = new Result(row["EmployeeID"].ToString(), row["FirstName"].ToString(), row["LastName"].ToString(), row["StartDate"].ToString(), row["ManagerID"].ToString(), row["BureauName"].ToString(), row["BureauID"].ToString(), row["ReviewStatusID"].ToString());
                        Results.Add(r);
                    }
                }
                Results = Results.OrderBy(e => e.progress).ToList();
            }
        }

        //Code from https://www.dotnetperls.com/uppercase-first-letter
        //Converts first letter in string to upper case. Fixes issue with lower case names in db
        public string CapitalizeFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }

        public class Result
        {
            public string ID;
            public string Firstname;
            public string Lastname;
            public string ManagerID;
            public string bureauID;
            public string bureau;
            public string progress;
            public string startDate;
            public double percent;
            public bool late;

            public Result(string _ID, string _first, string _last, string _startDate, string _managerID, string _bureau,string _bureauID, string _progress)

            {
                ID = _ID;
                startDate = _startDate;
                Firstname = _first;
                Lastname = _last;
                ManagerID = _managerID;
                bureau = _bureau;
                progress =(Int32.Parse( _progress)+1).ToString();
                percent = (double.Parse(progress) / 3) * 100;
                late = (progress == "4");
                bureauID = _bureauID;
            }

        }


    }
}