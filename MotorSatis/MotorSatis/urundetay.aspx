<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster2.master" AutoEventWireup="true"
    CodeFile="urundetay.aspx.cs" Inherits="urundetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript" src="modal/tinybox.js"></script>
    <link rel="stylesheet" href="modal/style.css" />
    <div class="" style="width: 96%;">
        <div id="vmMainPage">
            <div class="Product-border">
                <div class="Product-border-conent">
                    <div class="wrapper">
                        <div class="float-left">
                            <div class="browseProductImageContainer">
                                <div class="browseProductImage Fly">
                                    <a onclick="TINY.box.show({image:'dinamikimg/Urunler/<%= resimAdi %>',boxid:'frame',animate:true})"
                                        id="zoom1">
                                        <img src="dinamikimg/Urunler/<%= resimAdi %>" alt='<%= urunAdi %>' width="402px"
                                            title="<%= urunAdi %>" /></a>
                                </div>
                            </div>
                        </div>
                        <div class="floatElement">
                            <h2 class="browseProductTitle">
                                <span runat="server" id="spnurunadi" class="product_name"></span>
                            </h2>
                            <div class="product-divider">
                                <div class="browsePriceContainer">
                                    <span class="productPrice" runat="server" id="spnfiyat"></span><strong>(Kdv dahildir)</strong>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div class="description">
                                <div class="desc">
                                    <div runat="server" id="divkisa" style="color: black">
                                    </div>
                                    <br />
                                    <asp:Repeater ID="rptextra" runat="server">
                                        <ItemTemplate>
                                            <a onclick="TINY.box.show({image:'dinamikimg/Resimler/<%# Eval("Resim") %>',boxid:'frame',animate:true})"
                                                rel="useZoom: 'zoom1', smallImage: 'dinamikimg/Resimler/<%# Eval("Resim") %>' ">
                                                <img src="dinamikimg/Resimler/mini/<%# Eval("Resim") %>" alt="<%# Eval("Resim") %>" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                            <div class="vmCartContainer1" style="width: 135px;">
                                <div class="vmCartContainer">
                                    <div style="width: auto;">
                                        <span class="quantity" style="display: block;">
                                            <label for="quantity76" class="quantity_box">
                                                Miktar:&nbsp;</label>
                                            <asp:TextBox ID="quantity76" runat="server" Text="1" class="inputboxquantity"></asp:TextBox>
                                    </div>
                                    <asp:HiddenField ID="hdID" runat="server" />
                                    <asp:LinkButton ID="LinkButton1" runat="server" class="addtocart_button" OnClick="LinkButton1_Click">Sepete Ekle</asp:LinkButton>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <br />
                    <dl class="tabs" id="pane">
                        <dt id="tab3" style="cursor: pointer;" class="open"><span><span>Ürün Özellikleri</span></span></dt>
                    </dl>
                    <div class="current">
                        <dd style="display: block;">
                            <div runat="server" id="divhakkinda">
                            </div>
                        </dd>
                        
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
