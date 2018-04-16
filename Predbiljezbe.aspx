<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Predbiljezbe.aspx.cs" Inherits="Predbiljezbe" %>

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
            text-align: center;
        }
        .auto-style9 {
            font-size: medium;
        }
        .auto-style10 {
            height: 31px;
        }
        .auto-style11 {
            width: 160px;
        }
        .auto-style12 {
            height: 31px;
            width: 160px;
        }
        .auto-style13 {
            width: 100%;
        }
        .auto-style14 {
            width: 324px;
        }
        .auto-style15 {
            height: 31px;
            width: 324px;
        }
        .auto-style16 {
            width: 31px;
            text-align: left;
            height: 59px;
        }
        .auto-style18 {
            width: 32px;
            text-align: left;
            height: 53px;
        }
        .auto-style19 {
            width: 140px;
            text-align: justify;
            height: 53px;
        }
        .auto-style20 {
            width: 31px;
            text-align: left;
            height: 36px;
        }
        .auto-style21 {
            width: 140px;
            text-align: justify;
            height: 36px;
        }
        .auto-style23 {
            width: 140px;
            text-align: justify;
            height: 36px;
            position: inherit;
        }
        .auto-style24 {
            width: 31px;
            text-align: left;
            height: 53px;
        }
        .auto-style27 {
            width: 692px;
            height: 31px;
        }
        .auto-style28 {
            width: 692px;
            height: 36px;
        }
        .auto-style29 {
            height: 36px;
            width: 131px;
        }
        .auto-style30 {
            height: 31px;
            width: 131px;
        }
        .auto-style31 {
            position: relative;
            left: 0px;
            top: 0px;
            height: 82px;
        }
        .auto-style32 {
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
            <strong style="color: #FFFFFF">Predbilježbe</strong></p>
        <table class="auto-style2" aria-orientation="horizontal" style="position: relative">
            <tr>
                <td class="auto-style16"></td>
                <td class="auto-style18" style="position: inherit"></td>
                <td class="auto-style6" rowspan="8">
                    <table class="auto-style31">
                        <tr>
                            <td class="auto-style28" style="height: 36px"><span class="auto-style7">Pretraga</span>&nbsp;
                    <asp:TextBox ID="txtKljucnaRijec" runat="server"></asp:TextBox>
&nbsp;
                    <asp:Button ID="btnPrikazi" runat="server" Text="Prikaži" CausesValidation="False" OnClick="btnPrikazi_Click" />
                            &nbsp;&nbsp;
                                <asp:Button ID="btnSvePredbiljezbe" runat="server" CausesValidation="False" OnClick="btnSvePredbiljezbe_Click" Text="Sve predbilježbe" />
                            </td>
                            <td class="auto-style29" style="height: 36px"> <span class="auto-style9"><strong>Filtriraj prijave</strong></span></td>
                        </tr>
                        <tr>
                            <td class="auto-style27"></td>
                            <td class="auto-style30">
                    <asp:DropDownList ID="ddlStatusPrijave" runat="server" AutoPostBack="True" Height="16px" OnSelectedIndexChanged="ddlStatusPrijave_SelectedIndexChanged" Width="131px">
                    </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <table class="auto-style13" style="top: 100%">
                        <tr>
                            <td style="height: 100%">
                        <asp:GridView ID="gvPredbiljezbe" runat="server" AutoGenerateColumns="False" CellPadding="4" CssClass="auto-style9" ForeColor="#333333" GridLines="None" Width="836px" OnSelectedIndexChanged="gvPredbiljezbe_SelectedIndexChanged" OnRowDeleting="gvPredbiljezbe_RowDeleting" Height="167px" AllowPaging="True" OnPageIndexChanging="gvPredbiljezbe_PageIndexChanging">
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="IdPredbiljezba" HeaderText="Predbilježba br." >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Ime" HeaderText="Ime" />
                                <asp:BoundField DataField="Prezime" HeaderText="Prezime" />
                                <asp:BoundField DataField="Adresa" HeaderText="Adresa" />
                                <asp:BoundField DataField="Naziv" HeaderText="Naziv seminara" >
                                <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Datum" HeaderText="Datum" />
                                <asp:CheckBoxField DataField="Status" HeaderText="Prihvaćen" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CheckBoxField>
                                <asp:CheckBoxField DataField="Odbijen" HeaderText="Odbijen" >
                                <ItemStyle HorizontalAlign="Center" />
                                </asp:CheckBoxField>
                                <asp:CommandField SelectText="Obradi " ShowSelectButton="True" />
                                <asp:CommandField DeleteText="Obriši " ShowDeleteButton="True" />
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
                    <div class="auto-style8">
                    </div>
                    <asp:Label ID="lblPrediljezbe" runat="server" CssClass="auto-style9"></asp:Label>
                    <br />
                    <br />
                    <table class="auto-style13">
                        <tr>
                            <td class="auto-style11">
                                <asp:Label ID="lblBr" runat="server" CssClass="auto-style9" Text="Predbilježba br."></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtBr" runat="server" ReadOnly="True"></asp:TextBox>
                            </td>
                            <td class="auto-style9">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style11">
                                <asp:Label ID="lblImePredbiljezbe" runat="server" CssClass="auto-style9" Text="Ime"></asp:Label>
                            </td>
                            <td class="auto-style14">
                                <asp:TextBox ID="txtIme" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtIme" CssClass="auto-style9" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lblPrezime" runat="server" CssClass="auto-style9" Text="Prezime"></asp:Label>
                            </td>
                            <td class="auto-style15">
                                <asp:TextBox ID="txtPrezime" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPrezime" CssClass="auto-style9" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style10">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:Label ID="lblAdresa" runat="server" CssClass="auto-style9" Text="Adresa"></asp:Label>
                            </td>
                            <td class="auto-style15">
                                <asp:TextBox ID="txtAdresa" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAdresa" CssClass="auto-style9" ErrorMessage="Obavezan unos!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style10">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12" style="background-color: #FFFFFF" id="tablePlavi" runat="server">
                                <asp:RadioButtonList ID="rblStatus" runat="server" CssClass="auto-style9" Height="16px" Width="173px">
                                    <asp:ListItem Value="1">Potvrdi prijavu</asp:ListItem>
                                    <asp:ListItem Value="0">Odbij prijavu</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style15">&nbsp;<asp:Button ID="btnPotvrdi" runat="server" OnClick="btnPotvrdi_Click" Text="Obradi" />
                            &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnOdustani" runat="server" CausesValidation="False" OnClick="btnOdustani_Click" Text="Odustani" />
                            </td>
                            <td class="auto-style10">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style12">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="rblStatus" CssClass="auto-style9" ErrorMessage="Obavezan odabir!" ForeColor="#CC0000"></asp:RequiredFieldValidator>
                            </td>
                            <td class="auto-style15">&nbsp;</td>
                            <td class="auto-style10">&nbsp;</td>
                        </tr>
                    </table>
                    <asp:HiddenField ID="hfPredbiljazba" runat="server" />
                    <br />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style24"></td>
                <td class="auto-style19" style="position: inherit"><span class="auto-style7"><strong>Linkovi:</strong></span></td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style21" style="position: inherit"><strong>
                    <asp:HyperLink ID="HyperLink1" runat="server" CssClass="auto-style32" ForeColor="Blue" NavigateUrl="~/Predbiljezbe.aspx">Predbilježbe</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style21" style="position: inherit"><strong>
                    <asp:HyperLink ID="HyperLink2" runat="server" CssClass="auto-style32" ForeColor="Blue" NavigateUrl="~/Seminari.aspx">Seminari</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style21" style="position: inherit">
                    <asp:HyperLink ID="lnkZaposlenici" runat="server" CssClass="auto-style32" Font-Bold="True" ForeColor="Blue" NavigateUrl="~/Zaposlenici.aspx" Visible="False">Zaposlenici</asp:HyperLink>
                </td>
            </tr>
            <tr>
                <td class="auto-style20"></td>
                <td class="auto-style23"><strong>
                    <asp:HyperLink ID="HyperLink3" runat="server" CssClass="auto-style32" ForeColor="Blue" NavigateUrl="~/Prijava.aspx">Odjava</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style3" rowspan="2" style="position: inherit"><strong><br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
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
            <tr>
                <td class="auto-style5"><strong>
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    <br class="auto-style7" />
                    </strong></td>
            </tr>
        </table>
    </form>
    </body>
</html>
