<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebShow.aspx.cs" Inherits="TrafficViolationHost.WebShow" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        车牌号：<asp:TextBox ID="txtCarNumber" runat="server"></asp:TextBox>
        车架号：<asp:TextBox ID="txtCarFrame" runat="server"></asp:TextBox><font color="white">sdl</font>
        <asp:Button ID="Button1" runat="server" Text="查询" OnClick="Button1_Click" />
        <br />
        <asp:Label ID="lblResultU" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblResultC" runat="server" Text=""></asp:Label>
    </div>
    </form>
</body>
</html>
