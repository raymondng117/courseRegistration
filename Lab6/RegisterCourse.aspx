<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterCourse.aspx.cs" Inherits="Lab6.RegisterCourse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

    <style>
        
        body {
            background-color: #f8f9fa; 
        }

        .form-container {
            margin-top: 20px;
            padding: 20px;
            background-color: #fff; 
            border-radius: 5px;
            box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1); 

        .form-group {
            margin-bottom: 20px;
        }

    </style>

</head>
<body class="container mt-4">

    <h1 class="display-4 text-center">Algonquin College Course Registration</h1>

    <form id="form1" runat="server" visible="true" class="form-container">
        <div class="form-group">
            <label for="stdName">Student Name:</label>
            <asp:TextBox ID="stdName" runat="server" class="form-control"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Student Type:</label>
            <asp:RadioButtonList ID="stdType" runat="server" CssClass="form-check">
                <asp:ListItem Text="Fulltime" Value="fulltime" />
                <asp:ListItem Text="Part time" Value="parttime" />
                <asp:ListItem Text="Co-op" Value="coop" />
            </asp:RadioButtonList>
        </div>

        <asp:Panel ID="content" runat="server" Visible="true">
            <asp:Label class="alert alert-danger" id="lblError" runat="server" visible="false"></asp:Label> <br />

            <br />
          
            <h3>Following courses are currently available for registration:</h3>

            <div class="form-group">
                <asp:CheckBoxList ID="cblCourses" runat="server" CssClass="list-unstyled"></asp:CheckBoxList>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="SubmitButton_Clicked" CssClass="btn btn-primary" />
        </asp:Panel>
    </form>

    <asp:Table ID="contentTable" runat="server" Visible="false" CssClass="table mt-4 table-bordered"></asp:Table>
</body>
</html>
