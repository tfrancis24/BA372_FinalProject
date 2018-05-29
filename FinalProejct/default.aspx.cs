﻿using System;
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
                ReviewStatus.ReviewStatusID
            FROM Employee, Employee_Bureau, ReviewStatus, Reviews, Bureaus, Manager_Employee
            WHERE Employee.EmployeeID = Employee_Bureau.EmployeeID 
            AND Employee_Bureau.Employee_BureauID = Reviews.Employee_BureauID
            AND Reviews.ReviewStatusID = ReviewStatus.ReviewStatusID
            AND Bureaus.BureauID = Employee_Bureau.BureauID
            AND Manager_Employee.Manager_EmployeeID = Reviews.Manager_EmployeeID;
");
        }

        //When clicked, populates a table
        protected void Button1_Click(object sender, EventArgs e)
        {
            //search stuff here
        }

        //Gets SQL query data & stores it in the list
        public void GetSQL(string query)
        {
            Results = new List<Result>();
            //string query = "SELECT * FROM reviews";
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=C:/database/database._Complete.accdb";
            using (OleDbConnection con = new OleDbConnection(connectString)) {
                using (OleDbCommand cmd = new OleDbCommand(query, con)) {
                    con.Open();
                    OleDbDataReader dr = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(dr);

                    foreach (DataRow row in dt.Rows) {
                        Result r = new Result(row["EmployeeID"].ToString(), row["FirstName"].ToString(), row["LastName"].ToString(), row["StartDate"].ToString(), row["ManagerID"].ToString(), row["BureauName"].ToString(), row["ReviewStatusID"].ToString());
                        Results.Add(r);
                    }
                }

            }
        }

        public class Result
        {
            public string ID;
            public string Firstname;
            public string Lastname;
            public string ManagerID;
            public string bureau;
            public string progress;
            public string startDate;
            public double percent;

            public Result(string _ID, string _first, string _last, string _startDate, string _managerID, string _bureau, string _progress)

            {
                ID = _ID;
                startDate = _startDate;
                Firstname = _first;
                Lastname = _last;
                ManagerID = _managerID;
                bureau = _bureau;
                progress =(Int32.Parse( _progress)+1).ToString();
                percent = (double.Parse(progress) / 4) * 100;
            }

        }
    }
}