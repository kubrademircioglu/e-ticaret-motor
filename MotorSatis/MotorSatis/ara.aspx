<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.master" AutoEventWireup="true"
    CodeFile="ara.aspx.cs" Inherits="ara" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="anythingSlider2" style="float: left;">

        <div class="wrapper">
                <div id="aramas">
                    
                    <table class="width">
                        <tr>
                            <td class="cart-module">
                                <strong>Anahtar Sözcük Girin&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp; Kategori Seçin&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList1" runat="server">
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; Marka Seçin&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="ARA" />
                                </strong>
                            </td>
                        </tr>
                    </table>
                    
                    <table class="width">
                        <tr>
                            <td class="avPlayerContainer">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="avPlayerContainer">
                                &nbsp;</td>
                        </tr>
                    </table>
                    
                </div>
            <br />
            <br />
            <ul>
                <asp:Repeater ID="rpturunler" runat="server">
                    <ItemTemplate>
                        <li>
                            <div class="ProductBox item_01 ">
                                <div class="lastProductImage">
                                    <a href="urundetay.aspx?uID=<%# Eval("ID") %>" title="<%# Eval("UrunAdi") %>">
                                        <img class="lazy" src="img/lazy.gif" data-original="dinamikimg/Urunler/mini/<%# Eval("Resim1") %>"
                                            alt="" height="178" />
                                    </a>
                                </div>
                                <div class="lastProductName">
                                    <a href="urundetay.aspx?uID=<%# Eval("ID") %>" title="<%# Eval("UrunAdi") %>">
                                        <%# Eval("UrunAdi") %></a>
                                </div>
                                <div class="float-right">
                                    <div class="productDetail">
                                        <a href="urundetay.aspx?uID=<%# Eval("ID") %>" title="incele">incele</a>
                                    </div>
                                </div>
                                <div class="productPrice">
                                    <%# Eval("Fiyati") %>
                                    TL
                                </div>
                            </div>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
</asp:Content>
