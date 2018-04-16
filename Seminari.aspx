<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Seminari.aspx.cs" Inherits="Seminari" %>

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
            height: 400px;
        }
        .auto-style3 {
            width: 140px;
            text-align: justify;
        }
        .auto-style5 {
            width: 31px;
            text-align: left;
        }
        .auto-style6 {
            font-size: x-large;
        }
        .auto-style7 {
            font-size: large;
        }
        .auto-style8 {
            text-align: left;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            font-size: medium;
            width: 248px;
        }
        .auto-style11 {
            width: 99%;
        }
        .auto-style12 {
            font-size: medium;
            width: 248px;
            height: 49px;
        }
        .auto-style13 {
            font-size: medium;
            width: 248px;
            height: 30px;
        }
        .auto-style14 {
            font-size: medium;
            width: 141px;
        }
        .auto-style15 {
            font-size: medium;
            width: 141px;
            height: 30px;
        }
        .auto-style16 {
            font-size: medium;
            width: 141px;
            height: 49px;
        }
        .auto-style17 {
            width: 31px;
            text-align: left;
            height: 59px;
        }
        .auto-style18 {
            width: 140px;
            text-align: justify;
            height: 59px;
        }
        .auto-style27 {
            width: 31px;
            text-align: left;
            height: 53px;
        }
        .auto-style28 {
            width: 140px;
            text-align: justify;
            height: 53px;
        }
        .auto-style29 {
            width: 31px;
            text-align: left;
            height: 36px;
        }
        .auto-style30 {
            width: 140px;
            text-align: justify;
            height: 36px;
        }
        .auto-style31 {
            width: 659px;
        }
        .auto-style32 {
            width: 659px;
            height: 34px;
        }
        .auto-style33 {
            height: 34px;
        }
        .auto-style34 {
            width: 140px;
            text-align: justify;
            height: 36px;
            font-size: large;
        }
        .auto-style35 {
            font-size: large;
            text-decoration: underline;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="lblIme" runat="server"></asp:Label>
    
        <br />
    
    </div>
        <p class="auto-style1" style="background-color: #5D7B9D">
            <strong style="color: #FFFFFF">Seminari</strong></p>
        <table class="auto-style2" aria-orientation="horizontal">
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style18"></td>
                <td class="auto-style6" rowspan="7"><span class="auto-style9">&nbsp;&nbsp;&nbsp; </span>
                    <br />
                    <table class="auto-style13" style="width:100%;">
                        <tr>
                            <td class="auto-style32"><span class="auto-style7">Pretraga</span>&nbsp;
                    <asp:TextBox ID="txtKljucnaRijec" runat="server"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnPrikazi" runat="server" Text="Prikaži" CausesValidation="False" OnClick="btnPrikazi_Click" />
                                &nbsp;&nbsp;&nbsp;<asp:Button ID="btnSviSeminari" runat="server" CausesValidation="False" OnClick="btnSviSeminari_Click" Text="Svi seminari" Visible="False" />
                            </td>
                            <td class="auto-style33">
                    <asp:LinkButton ID="lnkDodajNoviSeminar" runat="server" CssClass="auto-style9" Font-Bold="True" OnClick="lnkDodajNoviSeminar_Click" CausesValidation="False">Dodaj novi seminar</asp:LinkButton>
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
                        <tr>
                            <td colspan="2">
                        <asp:GridView ID="gvSeminari" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style9" ForeColor="#333333" GridLines="None" Height="167px" Width="836px" OnRowDeleting="gvSeminari_RowDeleting" OnSelectedIndexChanged="gvSeminari_SelectedIndexChanged" AllowPaging="True" OnPageIndexChanging="gvSeminari_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="IdSeminar" HeaderText="IdSeminar"  />
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv" />
                                <asp:BoundField DataField="Opis" HeaderText="Opis" />
                                <asp:BoundField DataField="Datum" HeaderText="Datum" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Predavac" HeaderText="Predavač" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BrPredbiljezbi" HeaderText="Broj predbilježbi" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="Zatvoren" HeaderText="Zatvoren" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CheckBoxField>
                                <asp:CommandField CancelText="Odustani" DeleteText="Obriši" EditText="Uredi " ShowDeleteButton="True" ShowSelectButton="True" UpdateText="" SelectText="Uredi" />
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
                                    </td>
                        </tr>
                    </table>
                    <br />
                    <br />
                    <div class="auto-style8">
                                    <br />
            <br />
        </div>
                    
                    <table class="auto-style11">
                        <tr>
                            <td class="auto-style14">
                                &nbsp;</td>
                            <td class="auto-style10">
                                &nbsp;</td>
                            <td rowspan="8">
                                <asp:GridView ID="gvZaposlenici" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style9" ForeColor="#333333" GridLines="None">
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:BoundField DataField="IdZaposlenik" HeaderText="Id Zaposlenika" />
                                        <asp:BoundField DataField="Ime" HeaderText="Ime" />
                                        <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                                        <asp:BoundField DataField="KorisnickoIme" HeaderText="Korisničko ime" />
                                        <asp:BoundField DataField="Lozinka" HeaderText="Lozinka" />
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
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style9" colspan="2">
                                <strong>
                                <asp:Label ID="lblHeaderSeminar" runat="server"></asp:Label>
                                </strong>
                                <br />
                                <br />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style15">&nbsp;<asp:Label ID="lblNaziv" runat="server" Text="Naziv*"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                            <td class="auto-style13">
                                <asp:TextBox ID="txtNaziv" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNaziv" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style16">&nbsp;<asp:Label ID="lblOpis" runat="server" Text="Opis*"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <br />
                            </td>
                            <td class="auto-style12">
                                <asp:TextBox ID="txtOpis" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOpis" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">&nbsp;<asp:Label ID="lblDatum" runat="server" Text="Datum*"></asp:Label>
&nbsp;&nbsp;&nbsp;
                                <br />
                                <br />
                            </td>
                            <td class="auto-style10">
                                <asp:TextBox ID="txtDatum" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDatum" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="lblPredavac" runat="server" Text="Predavač*"></asp:Label>
&nbsp;&nbsp;
                                <br />
                                <br />
                            </td>
                            <td class="auto-style10">
                                <asp:TextBox ID="txtPredavac" runat="server" BackColor="#CCCCCC" ReadOnly="True"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPredavac" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <asp:Label ID="lblZatvoriSeminar" runat="server" Text="Zatvori seminar"></asp:Label>
                            </td>
                            <td class="auto-style10">
                                <asp:CheckBox ID="chkZatvoriSeminar" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style14">
                                <br />
                                <asp:Button ID="btnDodaj" runat="server" Text="Dodaj seminar" OnClick="btnDodaj_Click" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                </td>
                            <td class="auto-style10">
                                <asp:Button ID="btnIzmijeni" runat="server" OnClick="btnIzmijeni_Click" Text="Izmijeni seminar" />
                                <asp:Button ID="btnOdustani" runat="server" OnClick="btnOdustani_Click" Text="Odustani" CausesValidation="False" />
                            </td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hfIdZaposlenik" runat="server" />
                                <asp:HiddenField ID="hfIdSeminar" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style27"></td>
                <td class="auto-style28"><span class="auto-style7"><strong>Linkovi:</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style35" ForeColor="Blue" NavigateUrl="~/Predbiljezbe.aspx">Predbilježbe</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style35" ForeColor="Blue" NavigateUrl="~/Seminari.aspx">Seminari</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style34">
                    <asp:HyperLink ID="lnkZaposlenici" runat="server" Font-Bold="True" Font-Underline="True" ForeColor="Blue" NavigateUrl="~/Zaposlenici.aspx" Visible="False">Zaposlenici</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style29"></td>
                <td class="auto-style30"><strong>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="auto-style35" ForeColor="Blue" NavigateUrl="~/Prijava.aspx">Odjava</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style5"><strong>
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    </strong></td>
                <td class="auto-style3"><strong><br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    </strong><strong><br class="auto-style7" />
                    <br class="auto-style7" />
                    </strong><span class="auto-style7"><strong aria-orientation="vertical"><br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    </strong></span></td>
            </tr>
        </table>
    </form>
</body>
</html>
