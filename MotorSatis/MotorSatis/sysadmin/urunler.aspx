<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="urunler.aspx.cs" Inherits="sysadmin_urunler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
               ÜRÜNLER</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
            <br /><center>
        Marka seçiniz :     <asp:DropDownList ID="drpkat" runat="server"   Width="250px" AutoPostBack="true"
                onselectedindexchanged="drpkat_SelectedIndexChanged">
            </asp:DropDownList></center>
            <asp:Panel ID="Panel1" runat="server">
           
            <br />
            <asp:Label ID="lblbos" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" DataKeyField="ID" ForeColor="#333333" OnItemCommand="DataList1_ItemCommand" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#E3EAEB" />
                <ItemTemplate>
                    <div class="referanslar-kucuk-resim-alani-2">
                        <img src="../dinamikimg/Urunler/mini/<%#Eval("Resim1") %>"  height="80" border="0" />
                        
                        <%#Eval("UrunAdi") %> 
                        <br />
                        <div style="float: right">
                            <asp:LinkButton ID="LinkButton1" runat="server">düzenle</asp:LinkButton>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Red" CommandName="sil" OnClientClick="javascript:return confirm('Bu kayıt kalıcı olarak silinsin mi?');">sil</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; <a href="urunResimleriEkle.aspx?id=<%# Eval("ID") %>&tip=icerik">Resim Ekle</a>
                                 &nbsp;&nbsp;&nbsp; <a href="urunResimleri.aspx?id=<%# Eval("ID") %>&tip=icerik">Resimler</a>
                            </div>
                    </div>
                    <asp:HiddenField runat="server" ID="hdresim" Value='<%#Eval("Resim1") %>'></asp:HiddenField>
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList><p></p><p></p> </asp:Panel>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>

