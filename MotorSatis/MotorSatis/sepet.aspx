<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.master" AutoEventWireup="true"
    CodeFile="sepet.aspx.cs" Inherits="sepet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content-indent">
        <div id="vmMainPage">
            <h2 class="title">
                Sepetim</h2>
            <div class="cart-top" style="padding: 20px 0px 0px 0px;">
                <div id="content">
                    <asp:Label ID="lblbos" runat="server" Style="font-size: 17px; color: Red; font-family: 'Amaranth', cursive;"></asp:Label>
                    <asp:Label ID="lblonay" runat="server" Style="font-size: 17px; color: Red; font-family: 'Amaranth', cursive;"></asp:Label>
                    <div runat="server" id="sepetDiv">
                        <div class="cart-info">
                            <table>
                                <thead>
                                    <tr>
                                        <td class="remove">
                                            sil
                                        </td>
                                        <td class="image">
                                        </td>
                                        <td class="name">
                                            Ürün Adı
                                        </td>
                                        <td class="quantity">
                                            Miktar
                                        </td>
                                        <td class="price">
                                            Birim Fiyat
                                        </td>
                                        <td class="total">
                                            Toplam Fiyat
                                        </td>
                                        <td>
                                            güncelle
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Repeater ID="rptsepet" runat="server" OnItemCommand="rptsepet_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                                <td class="remove">
                                                    <asp:ImageButton ID="ImageButton1" ImageUrl="img/delete.png" CommandName="sil" Width="45px"
                                                        runat="server" />
                                                    <asp:HiddenField ID="hdID" runat="server" Value='<%# Eval("UrunId") %>' />
                                                </td>
                                                <td class="image">
                                                    <img src="dinamikimg/Urunler/mini/<%# Eval("Resim") %>" alt="<%# Eval("Tanim") %>"
                                                        width="60px" />
                                                </td>
                                                <td class="name" style="color: #D06464">
                                                    <%# Eval("Tanim") %>
                                                    <div>
                                                    </div>
                                                </td>
                                                <td class="quantity">
                                                    <asp:TextBox ID="txtmiktar" runat="server" MaxLength="2" Text='<%# Eval("Miktar") %>'
                                                        onKeyPress="return sedeceSayi(event)" Width="25px"></asp:TextBox>
                                                </td>
                                                <td class="price">
                                                    <span class="yenitlfiyat">
                                                        <%# Eval("BirimFiyat")%></span>
                                                </td>
                                                <td class="total">
                                                    <span class="yenitlfiyat">
                                                        <%# Eval("ToplamFiyat") %></span>
                                                </td>
                                                <td>
                                                    <asp:ImageButton ID="ImageButton2" ImageUrl="img/refresh.png" CommandName="guncelle"
                                                        Width="45px" runat="server" />
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                        <div class="cart-total">
                            <table>
                                <tbody>
                                    <%--    <tr>
                                        <td colspan="5"></td>
                                        <td class="right">
                                            <b>Ara Toplam:</b>
                                        </td>
                                        <td class="right numbers yenitlfiyat">
                                            <asp:Label ID="lblaratoplam" runat="server" Text=""></asp:Label> TL
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="5"></td>
                                        <td class="right">
                                            <b>KDV 18%:</b>
                                        </td>
                                        <td class="right numbers yenitlfiyat">
                                            <asp:Label ID="lblkdv" runat="server" Text=""></asp:Label> TL
                                        </td>
                                    </tr>--%>
                                    <tr>
                                        <td colspan="5">
                                        </td>
                                        <td class="right numbers_total">
                                            <b>Genel Toplam:</b>
                                        </td>
                                        <td class="right numbers_total yenitlfiyatbuyuk">
                                            <asp:Label ID="lblgenel" runat="server" Text=""></asp:Label>
                                            TL
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="buttons">
                            <div class="vmCartContainer">
                                <asp:LinkButton ID="LinkButton2" runat="server" class="addtocart_button" OnClick="LinkButton1_Click">Sepeti Onayla</asp:LinkButton>
                            </div>
                            <br />
                            <br />
                            <div class="vmCartContainer">
                                <asp:LinkButton ID="LinkButton1" runat="server" class="addtocart_button" OnClick="LinkButton1_Click">Sepeti Onayla</asp:LinkButton>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="statusBox" style="text-align: center; display: none; visibility: hidden;">
    </div>
</asp:Content>
