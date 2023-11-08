<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Instructor.aspx.cs" Inherits="KarateSchool.Instructor1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hi,
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
        </div>
    </form>
</body>
</html>
