<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddStudent.aspx.cs" Inherits="lab7.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Registration</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container p-5">
            <h2 class="mb-4">Student</h2>
            <div class="mb-3">
                <label for="stdName" class="form-label">Student Name:</label>
                <asp:TextBox ID="stdName" runat="server" CssClass="form-control"></asp:TextBox>
            </div>

            
            <div class="mb-3">
                <label for="ddlType" class="form-label">Student Type:</label>
                <asp:DropDownList ID="ddlType" runat="server" CssClass="form-select" >
                    <asp:ListItem Value="">Select...</asp:ListItem>
                    <asp:ListItem Value="fulltime">Full time</asp:ListItem>
                    <asp:ListItem Value="parttime">Part time</asp:ListItem>
                    <asp:ListItem Value="coop">Coop</asp:ListItem>
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnNewStudent" runat="server" Text="Add" CssClass="btn btn-primary mb-3" OnClick="Add_Student" />
            <asp:Button ID="bthDelete" runat="server" Text="Delete" CssClass="btn btn-warning mb-3" OnClick="Delete_Student"/>


            <div class="table-responsive">
                <asp:Table ID="tblStudents" runat="server" CssClass="table">
                    
                </asp:Table>
            </div>
        </div>
    </form>
</body>
</html>
