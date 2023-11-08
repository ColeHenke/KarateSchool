<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Administrator.aspx.cs" Inherits="KarateSchool.Administrator" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            height: 246px;
        }
        .auto-style2 {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Hi,
            <asp:LoginName ID="LoginName1" runat="server" />
            <br />
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style1">
                        <asp:GridView ID="memberGridView" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="addMemberButton" runat="server" Text="Add " />
                        <asp:Button ID="deleteMemberButton" runat="server" Text="Delete" />
                    </td>
                    <td class="auto-style1">
                        <asp:GridView ID="instructorGridView" runat="server">
                        </asp:GridView>
                        <br />
                        <asp:Button ID="addInstructorButton" runat="server" Text="Add" />
                        <asp:Button ID="deleteInstructorButton" runat="server" Text="Delete" />
                    </td>
                </tr>
            </table>
            <br />
            <div class="auto-style2">
                <asp:GridView ID="sectionGridView" runat="server">
                </asp:GridView>
                <div class="auto-style2">
                    <br />
                    <asp:Button ID="addSectionButton" runat="server" Text="Add" />
                    <asp:Button ID="deleteSectionButton" runat="server" Text="Delete" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>
