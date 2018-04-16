<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Predbiljezba.aspx.cs" Inherits="Predbiljezba" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
        }
        .auto-style3 {
            text-align: left;
        }
        .auto-style4 {
            text-align: center;
            font-size: x-large;
            width: 763px;
        }
        .auto-style6 {
            height: 23px;
            width: 496px;
        }
        .auto-style7 {
            width: 56%;
        }
        .auto-style8 {
            text-align: left;
            height: 61px;
            width: 496px;
        }
        .auto-style9 {
            width: 496px;
        }
        .auto-style10 {
            width: 496px;
            text-align: left;
        }
    .auto-style11 {
        width: 683px;
    }
        .auto-style5 {
            font-size: large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="auto-style1">
    
        <br />
    
    </div>
        <p class="auto-style4" style="background-color: #5D7B9D; color: #FFFFFF">
            <strong aria-selected="false">Predbilježite se</strong></p>
        <p>
            <br />
            <table style="width:100%;">
                <tr>
                    <td class="auto-style11">Pretraga&nbsp;
                        <asp:TextBox ID="txtPretraga" runat="server"></asp:TextBox>
                        &nbsp;&nbsp;
                        <asp:Button ID="btnPretraga" runat="server" CausesValidation="False" OnClick="btnPretraga_Click" Text="Pretraga" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnSviSeminari" runat="server" CausesValidation="False" OnClick="btnSviSeminari_Click" Text="Svi seminari" />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                    <td><a href="Prijava.aspx"><span class="auto-style5">&nbsp;</span><strong><span class="auto-style5">Prijava</span></strong></a></td>
                </tr>
            </table>
        </p>
        <div class="auto-style3">
            <br />
            <asp:GridView ID="gvPonudaSeminara" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Width="763px" OnSelectedIndexChanged="gvPonudaSeminara_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                 
                    <asp:BoundField DataField="IdSeminar" />
                 
                    <asp:BoundField DataField="Naziv" HeaderText="Naziv" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Opis" HeaderText="Opis" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Datum" HeaderText="Datum" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Predavac" HeaderText="Predavač" >
                    <HeaderStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:CommandField ShowSelectButton="True" SelectText="Prijavi seminar" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
            <br />
            <br />
        </div>
        <table id="tbl1" class="auto-style7">
            <tr>
                <td class="auto-style8">
                    <asp:Label ID="lblPrijavaSeminara" runat="server" Text="Prijava seminara" Visible="False"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="lblPotvrda" runat="server" Text="Uspješno ste prijavili seminar!" Visible="False"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblIme" runat="server" Text="Ime*" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtIme" runat="server" Visible="False" AutoPostBack="True"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIme" ErrorMessage="Obavezno polje!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style6">
                    <asp:Label ID="lblPrezime" runat="server" Text="Prezime*" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPrezime" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrezime" ErrorMessage="Obavezno polje!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblAdresa" runat="server" Text="Adresa*" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
                    <asp:TextBox ID="txtAdresa" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtAdresa" ErrorMessage="Obavezno polje!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblNazivSeminara" runat="server" Text="Naziv seminara" Visible="False"></asp:Label>
                    &nbsp;&nbsp;
                    <asp:TextBox ID="txtNazivSeminara" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblDatumSeminara" runat="server" Text="Datum seminara" Visible="False"></asp:Label>
&nbsp;
                    <asp:TextBox ID="txtDatumSeminara" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblPredavac" runat="server" Text="Predavač" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtPredavac" runat="server" Visible="False"></asp:TextBox>
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style10">
                    <asp:Button ID="btnPrijavi" runat="server" OnClick="btnPrijavi_Click" Text="Pošalji predilježbu" Visible="False" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                    <asp:Button ID="btnOdustani" runat="server" Text="Odustani" OnClick="btnOdustani_Click" Visible="False" CausesValidation="False"/>
                </td>
            </tr>
        </table>
        <asp:HiddenField ID="hfIdSeminar" runat="server" />
        <asp:HiddenField ID="hfIdZaposlenik" runat="server" />
    </form>
</body>
</html>
