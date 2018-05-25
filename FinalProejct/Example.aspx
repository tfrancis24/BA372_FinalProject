<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Example.aspx.cs" Inherits="FinalProejct.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>City of Portland Performance Reviews</title>
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
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
<nav class="navbar navbar-dark bg-primary">
            <div class="input-group">

                <label for="example-text-input" class="col-2 col-form-label">Name</label>
                <input type="text" class="col-10 form-control" placeholder="Name" aria-label="Username" aria-describedby="basic-addon1" />
                <label for="example-text-input" class="col-2 col-form-label">Bureau</label>
                <select class="custom-select inline" id="BureauSelect">
                    <option value="0">Any</option>
                    <option value="1">HR</option>
                    <option value="2">Transportation</option>
                    <option value="3">Housing</option>
                    <option value="3">Budget</option>
                    <option value="3">Technology</option>
                </select>
            </div>
        <button class="btn btn-dark my-2 my-sm-1" type="submit">Search</button>
    </nav>
    <!-- Reviews-->
    
</body>
</html>
