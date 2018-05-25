<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City of Portland Performance Reviews</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Name" />
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:GridView ID="Reviews" runat="server"></asp:GridView>
            <asp:Calendar ID="StartDateCalendar" runat="server"></asp:Calendar>
            <asp:Calendar ID="EndDateCalendar" runat="server"></asp:Calendar>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            </asp:UpdatePanel>
            <div class="container" style="margin-top: 20px">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Employee ID</th>
                    <th>Employee_Name</th>
                    <th>Manager_Name</th>
                    <th>Bureau</th>
                    <th>Start Date</th>
                    <th>Progress</th>
                </tr>
            </thead>
            <tbody>
                <%
                    foreach(Result result in Results) {

                        Response.Write(
                         "<tr>" +
                        $"<td>{result.ID}</td>" +
                        $"<td>{result.Firstname} {result.Lastname}</td>" +
                        $"<td>{result.manager_first} {result.manager_last}</td>" +
                        $"<td>{result.bureau}</td>" +
                        $"<td>{result.startDate}</td>" +
                        "<td>" +
                            "<div class=\"progress\">" +
                                $"<div class=\"progress-bar\" role=\"progressbar\" aria-valuenow=\"50\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width:{Math.Round(result.percent)}%;\">"+
                                    $"{result.progress}/4" +
                                "</div>" +
                            "</div>" +
                        "</td>" +
                    "</tr>");
                    }
            %>
            </tbody>
        </table>
    </div>
           
        </div>
        </form>
</body>
</html>
