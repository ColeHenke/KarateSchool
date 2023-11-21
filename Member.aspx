<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="KarateSchool.Member1" %>

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
            <p style="display: inline;"> -- Your running total is: </p>
            <asp:Label ID="totalLabel" runat="server"></asp:Label>
            <br />

            <p style="display: inline";>Info for </p>
            <asp:Label ID="firstNameLabel" runat="server"></asp:Label>
            <asp:Label ID="lastNameLabel" runat="server"></asp:Label>
            <asp:GridView ID="memberGridView" runat="server">
            </asp:GridView>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
