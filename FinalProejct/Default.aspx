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
            <div class="container" style="margin-top: 20px">
        <table class="table table-hover">
            <thead>
                <tr>
                    <th>Employee_Name</th>
                    <th>Manager_Name</th>
                    <th>Bureau</th>
                    <th>Progress</th>
                </tr>
            </thead>
            <tbody>
                <%
                foreach(Result result in Results) {
                    Response.Write(
                     "<tr>" +
                    $"<td>{result.Firstname} {result.Lastname}</td>" +
                    $"<td>{result.manager_first} {result.manager_last}</td>" +
                    $"<td>{result.bureau}</td>" +
                    "<td>" +
                        "<div class=\"progress\">" +
                            "<div class=\"progress-bar\" role=\"progressbar\" aria-valuenow=\"75\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width: 75%;\">"+
                                $"{result.progress}%" +
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
