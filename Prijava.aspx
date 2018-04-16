<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Prijava.aspx.cs" Inherits="Prijava" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
    <div class="auto-style1">
        
    
        <br />
        <strong>
        <br />
        <span class="auto-style2">Prijava<br />
        </span>
        <br />
        <br />
        </strong>
    
    </div>
        <p class="auto-style1">
            Korisnicko ime&nbsp; <asp:TextBox ID="txtKorisnickoIme" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Lozinka&nbsp;
            <asp:TextBox ID="txtLozinka" runat="server" TextMode="Password"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnPrijavi" runat="server" Text="Prijava" OnClick="btnPrijavi_Click" />
        </p>
        <p class="auto-style1">
            <asp:Label ID="lblError" runat="server"></asp:Label>
        </p>
        <p class="auto-style1">
            &nbsp;</p>
        <p class="auto-style1">
            &nbsp;</p>
        <p class="auto-style1">
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Predbiljezba.aspx">Povratak</asp:HyperLink>
        </p>
    </form>
</body>
</html>
