<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="Slider.aspx.cs" Inherits="sysadmin_Slider" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                BANNER RESİMLER</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
            <br />
        
            <asp:Label ID="lblbos" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" DataKeyField="ID" ForeColor="#333333" OnItemCommand="DataList1_ItemCommand" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#E3EAEB" />
                <ItemTemplate>
                    <div class="referanslar-kucuk-resim-alani-2">
                        <img src="../dinamikimg/Sliders/<%#Eval("Slider") %>"   border="0" />
                        <br />
                        <br />
                        <div style="float: right">
                            <asp:LinkButton ID="LinkButton1" runat="server">düzenle</asp:LinkButton>
                            <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Red" CommandName="sil" OnClientClick="javascript:return confirm('Bu kayıt kalıcı olarak silinsin mi?');">sil</asp:LinkButton></div>
                    </div>
                    <asp:HiddenField runat="server" ID="hdresim" Value='<%#Eval("Slider") %>'></asp:HiddenField>
                    <br />
                </ItemTemplate>
                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList><br /><br /><br />
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>

