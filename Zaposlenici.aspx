<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Zaposlenici.aspx.cs" Inherits="Zaposlenici" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .auto-style1 {
            text-align: center;
            font-size: x-large;
            width: 1023px;
        }
        .auto-style2 {
            width: 100%;
            height: 787px;
        }
        .auto-style18 {
            width: 140px;
            text-align: justify;
            height: 59px;
        }
        .auto-style6 {
            font-size: x-large;
        }
        .auto-style13 {
            font-size: medium;
            width: 248px;
            height: 30px;
        }
        .auto-style31 {
            width: 633px;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style11 {
            width: 99%;
        }
        .auto-style14 {
            font-size: medium;
            width: 115px;
        }
        .auto-style10 {
            font-size: medium;
            width: 369px;
        }
        .auto-style15 {
            font-size: medium;
            width: 115px;
            height: 30px;
        }
        .auto-style16 {
            font-size: medium;
            width: 115px;
            height: 49px;
        }
        .auto-style12 {
            font-size: medium;
            width: 369px;
            height: 49px;
        }
        .auto-style28 {
            width: 140px;
            text-align: justify;
            height: 53px;
        }
        .auto-style7 {
            font-size: large;
        }
        .auto-style30 {
            width: 140px;
            text-align: justify;
            height: 36px;
        }
        .auto-style5 {
            text-align: left;
        height: 434px;
    }
        .auto-style32 {
            width: 140px;
            text-align: justify;
            height: 36px;
            font-size: large;
        }
        .auto-style33 {
            color: #FFFFFF;
        }
        .auto-style34 {
            width: 633px;
            height: 23px;
        }
        .auto-style35 {
            height: 23px;
        }
        .auto-style36 {
            font-size: medium;
            width: 369px;
            height: 30px;
        }
        .auto-style37 {
            font-size: medium;
        }
        .auto-style38 {
            font-size: large;
            text-decoration: underline;
        }
        .auto-style39 {
            text-align: left;
            height: 59px;
        }
        .auto-style40 {
            text-align: left;
            height: 53px;
        }
        .auto-style41 {
            text-align: left;
            height: 36px;
        }
        .auto-style42 {
            width: 27px;
            text-align: left;
            height: 434px;
        }
        .auto-style45 {
            text-align: left;
            height: 243px;
        }
        .auto-style46 {
            width: 140px;
            text-align: justify;
            height: 243px;
        }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <asp:Label ID="lblIme" runat="server"></asp:Label>
            <br />
        </div>
        <p class="auto-style1" style="background-color: #5D7B9D; color: #FFFFFF;">
            <strong>Z</strong><span class="auto-style33"><strong>aposlenici</strong></span></p>
        <table aria-orientation="horizontal" class="auto-style2">
            <tr>
                <td class="auto-style39" colspan="2">&nbsp;</td>
                <td class="auto-style18"></td>
                <td class="auto-style6" rowspan="8">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <br />
                    <table class="auto-style13" style="width:100%;">
                        <tr>
                            <td class="auto-style34">&nbsp;</td>
                            <td class="auto-style35">
                                <asp:LinkButton ID="btnDodajNovog" runat="server" CausesValidation="False" Font-Bold="True" OnClick="btnDodajNovog_Click">Dodaj novog zaposlenika</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style31">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style31">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        </table>
                    <asp:GridView ID="gvZaposlenici" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style37" ForeColor="#333333" GridLines="None" Height="167px" OnRowDeleting="gvZaposlenik_RowDeleting" OnSelectedIndexChanged="gvPonudaSeminara_SelectedIndexChanged" Width="836px">
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:BoundField DataField="IdZaposlenik" HeaderText="Id">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Ime" HeaderText="Ime">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Prezime" HeaderText="Prezime">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="KorisnickoIme" HeaderText="Korisničko ime">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Lozinka" HeaderText="Lozinka">
                            <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:CommandField SelectText="Izmijeni" ShowSelectButton="True" />
                            <asp:CommandField DeleteText="Obriši" ShowDeleteButton="True" />
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
                    <div class="auto-style8">
                    <table class="auto-style11">
                        <tr>
                            <td class="auto-style37" colspan="2">
                                <asp:Label ID="lblHeader" runat="server" Font-Bold="True"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td rowspan="8">
                    <asp:HiddenField ID="hfZaposlenici" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <br />
                                <asp:Label ID="lblImeZaposlenika" runat="server" Text="Ime"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td class="auto-style10">
                                <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtIme" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">
                                <br />
                                <asp:Label ID="lblPrezime" runat="server" Text="Prezime"></asp:Label>
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                            <td class="auto-style36">
                                <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPrezime" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">
                                <br />
                                <asp:Label ID="lblKorisnickoIme" runat="server" Text="Korisničko ime"></asp:Label>
                                &nbsp;&nbsp;&nbsp;<br />
                                &nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="txtKorisnickoIme" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtKorisnickoIme" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <br />
                                <asp:Label ID="lblLozinka" runat="server" Text="Lozinka"></asp:Label>
                                <br />
                                <br />
                            </td>
                            <td class="auto-style10">
                                <asp:TextBox ID="txtLozinka" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtLozinka" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;<br />
                                <asp:Button ID="btnDodaj" runat="server" OnClick="btnDodaj_Click" Text="Dodaj" />
                                <br />
                                <br />
                            </td>
                            <td class="auto-style10">&nbsp;
                                <asp:Button ID="btnIzmijeni" runat="server" OnClick="btnIzmijeni_Click" Text="Izmijeni " />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnOdustani" runat="server" OnClick="btnOdustani_Click" Text="Odustani" CausesValidation="False" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <br />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; </td>
                            <td class="auto-style10">&nbsp;</td>
                        </tr>
                    </table>
                        <br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style40" colspan="2">&nbsp;</td>
                <td class="auto-style28"><span class="auto-style7"><strong>Linkovi:</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style41" colspan="2">&nbsp;</td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style38" ForeColor="Blue" NavigateUrl="~/Predbiljezbe.aspx">Predbilježbe</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style41" colspan="2">&nbsp;</td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style38" ForeColor="Blue" NavigateUrl="~/Seminari.aspx">Seminari</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style41" colspan="2">&nbsp;</td>
                <td class="auto-style32">
                    <asp:HyperLink ID="lnkZaposlenici" runat="server" Font-Bold="True" ForeColor="Blue" NavigateUrl="~/Zaposlenici.aspx" Visible="False">Zaposlenici</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style41" colspan="2"></td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="auto-style38" ForeColor="Blue" NavigateUrl="~/Prijava.aspx">Odjava</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style45" colspan="2"></td>
                <td class="auto-style46"></td>
            </tr>
            <tr>
                <td class="auto-style42">&nbsp;</td>
                <td class="auto-style5" colspan="2">&nbsp;</td>
            </tr>
        </table>
    </form>
</body>
</html>
