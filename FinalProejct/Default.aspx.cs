using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProejct
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Code for connecting to DB
            //Need to modify path for our project
            string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;" + @"Data Source=c:\\temp\\foo.accdb";
            OleDbConnection connection = new OleDbConnection(connectString);
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = connection;

            //Open DB
            try { connection.Open(); }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }

            //Close DB
            try { connection.Close(); }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + ex.Message + "');", true);
            }
        }

        //When click, prints a message regarding and email
        protected void Email_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "Notificaiton email sent to selected employees"+ "');", true);
        }
    }
}