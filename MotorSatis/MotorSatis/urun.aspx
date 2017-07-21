<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster2.master" AutoEventWireup="true" CodeFile="urun.aspx.cs" Inherits="urun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   
    <div style="width:100%;"></div>
    <div class="anythingSlider2" style=" float:left;">
                                    <div class="wrapper" style="width:80%">
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
                                                                <a href="urundetay.aspx?uID=<%# Eval("ID") %>" title="<%# Eval("UrunAdi") %>"><%# Eval("UrunAdi") %></a>
                                                            </div>
                                                            <div class="float-right">


                                                                <div class="productDetail">
                                                                    <a href="urundetay.aspx?uID=<%# Eval("ID") %>" title="incele">incele</a>
                                                                </div>
                                                            </div>
                                                            <div class="productPrice">
                                                                <%# Eval("Fiyati") %> TL
                                                            </div>
                                                        </div>
                                                    </li>

                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </ul>
                                    </div>
                                </div>
</asp:Content>

