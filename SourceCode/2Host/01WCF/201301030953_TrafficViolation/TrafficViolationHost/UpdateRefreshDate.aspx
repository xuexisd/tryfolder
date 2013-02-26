<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateRefreshDate.aspx.cs" Inherits="TrafficViolationHost.UpdateRefreshDate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        车牌号：<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="更新" />
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </div>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="更新所有时间" />
    </form>
</body>
</html>
