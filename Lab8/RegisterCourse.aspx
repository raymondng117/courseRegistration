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
    }

    .form-group {
        margin-bottom: 20px;
    }
</style>

</head>
<body class="container mt-4">

    <h1 class="display-4 text-center">Algonquin College Course Registration</h1>

    <form id="form1" runat="server" visible="true" class="form-container">

        <div class="form-group">
            <label for="ddlStudent">Student Name:</label>    
            <asp:DropDownList ID="ddlStudent" runat="server" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlStudent_SelectedIndexChanged"></asp:DropDownList> 
                <asp:RequiredFieldValidator 
                    ID="rfvStudent" 
                    runat="server" 
                    ControlToValidate="ddlStudent"
                    Display="Dynamic"
                    EnableClientScript="true"
                    CssClass="text-danger">
                    Must select one!
                </asp:RequiredFieldValidator> <br />
            <asp:Label id="lblPrecheck" runat="server" Visible="false" CssClass="form-label fs-4 text-primary mb-2"></asp:Label> 

        </div>

        <asp:Panel ID="content" runat="server" Visible="true" CssClass="mb-4">
          
            <h3>Following courses are currently available for registration:</h3>

            <asp:Label id="lblError" runat="server" Visible="false" CssClass="form-label fs-5 text-danger mb-4 fw-bold"></asp:Label> 

            <div class="form-group">
                <asp:CheckBoxList ID="cblCourses" runat="server" CssClass="list-unstyled"></asp:CheckBoxList>
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Save" OnClick="SubmitButton_Clicked" CssClass="btn btn-primary" />
        </asp:Panel>

        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="./AddStudent.aspx" CssClass="mb-2 ">Add Student</asp:HyperLink>
    </form>

     

</body>
</html>
