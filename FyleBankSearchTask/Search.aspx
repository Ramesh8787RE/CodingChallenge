<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Serach.aspx.cs" Inherits="FyleTask.Serach" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="Content/DataTables/css/jquery.dataTables.min.css" rel="stylesheet" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/DataTables/jquery.dataTables.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <title></title>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#gvdisplay').dataTable();
        })
    </script>
    <style type="text/css">
       #form1{
           background-image: url("Images/pexels-photo-1445416.jpeg");
           background-repeat:no-repeat;
           background-size:cover;
           background-attachment:fixed;
       }
     
       #gvdisplay{
           background-color:gainsboro;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <br />
            <strong>Select Bank</strong><asp:DropDownList ID="ddlselectbank" runat="server" CssClass="form-control col-md-3" AutoPostBack="true" OnSelectedIndexChanged="ddlcity_SelectedIndexChanged"></asp:DropDownList><br />
            <asp:GridView ID="gvdisplay" CssClass="table table-bordered" runat="server"  ></asp:GridView>
        </div>
    </form>
</body>
</html>
