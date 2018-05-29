<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplication2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City of Portland Performance Reviews</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/css/bootstrap.min.css" />
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.0/umd/popper.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.1.0/js/bootstrap.min.js"></script>
    <script language="javascript">
        var groupId = "THE_BEST"; //Insert your groupid-MAX 30 CHARS
        var Url = "http://people.oregonstate.edu/~laty/record.php?username=" + groupId;
        xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", Url, true);
        xmlHttp.send(null);
    </script>
</head>
<body>

    <form id="form1" runat="server">


        <div class="jumbotron jumbotron-fluid" style="padding: 20px;">
            <div class="container">
                <div class="row">
                    <div class="col-sm">
                        <div class="row">
                            <img src="https://i.imgur.com/PPyw1Yg.png" class="pull-left gap-right" height="100" width="100" />
                            <div class="col-sm-1">
                            </div>
                            <div class="col-md-auto">
                                <br />
                                <h4>City of Portland Oregon</h4>
                                <p>Bureau of Human Resources</p>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Button trigger modal -->

        <!-- Email Box -->
        <div class="modal fade" id="exampleModalLong" tabindex="-1" role="dialog" aria-labelledby="exampleModalLongTitle" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Send Message</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                          <textarea class="form-control" rows="5" id="comment"></textarea>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary" data-dismiss="modal">Send Message</button>
                    </div>
                </div>
            </div>
        </div>

        <!-- Search Box -->
        <div class="modal fade" id="myModal">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">

                    <!-- Modal Header -->
                    <div class="modal-header">
                        <h4 class="modal-title">Search</h4>
                        <button type="button" class="close" data-dismiss="modal">&times;</button>
                    </div>

                    <!-- Modal body -->
                    <div class="modal-body">

                        <div class="row">
                            <div class="col-sm">
                                <h4>First Name</h4>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-sm">
                                <h4>Last Name</h4>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm">
                               <!-- <h4>Start Date</h4>
                                <!-- <asp:Calendar ID="StartDateCalendar" runat="server"></asp:Calendar> -->
                            </div>
                            <div class="col-sm">
                               <!-- <h4>End Date</h4>
                                <!--  <asp:Calendar ID="EndDateCalendar" runat="server"></asp:Calendar> -->
                            </div>
                        </div>
                    </div>

                    <!-- Modal footer -->
                    <div class="modal-footer">
                        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" class="btn btn-dark" />
                    </div>

                </div>
            </div>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-sm">

                    <h4>In progress reviews</h4>

                </div>
                <div class="col-sm">
                    <!-- Button to Open the Modal -->
                    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#myModal">
                        Filters
                    </button>

                </div>
            </div>
            <table class="table table-hover" style="margin-top: 20px;">
                <thead>
                    <tr>
                        <th>Employee ID</th>
                        <th>Employee Name</th>
                        <th>Manager ID</th>
                        <th>Bureau</th>
                        <th>Start Date</th>
                        <th>Progress</th>
                        <th>Message</th>
                    </tr>
                </thead>
                <tbody>
                    <%
                        foreach (Result result in Results) {

                            Response.Write(
                             "<tr>" +
                            $"<td>{result.ID}</td>" +
                            $"<td>{result.Firstname} {result.Lastname}</td>" +
                            $"<td>{result.ManagerID}</td>" +
                            $"<td>{result.bureau}</td>" +
                            $"<td>{result.startDate}</td>" +
                            "<td>" +
                                "<div class=\"progress\">" +
                                    $"<div class=\"progress-bar\" role=\"progressbar\" aria-valuenow=\"50\" aria-valuemin=\"0\" aria-valuemax=\"100\" style=\"width:{Math.Round(result.percent)}%;\">" +
                                        $"{result.progress}/4" +
                                    "</div>" +
                                "</div>" +
                            "</td>" +
                           "<td><button type=\"button\" class=\"btn btn-primary btn-sm\" data-toggle=\"modal\" data-target=\"#exampleModalLong\"> Email</button> </td>"
                        +"</tr>");
                        }
                    %>
            
                </tbody>
            </table>
        </div>
    </form>
</body>
</html>
