<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="Kategoriler.aspx.cs" Inherits="sysadmin_Kategoriler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                MARKALAR</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
     
            <br />
            <br /><div style="margin-left:30%">
            <asp:DataList ID="DataList1" runat="server" Width="50%" DataKeyField="ID" 
                CellPadding="4" ForeColor="#333333" onitemcommand="DataList1_ItemCommand1">
                <AlternatingItemStyle BackColor="White" ForeColor="#284775" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <ItemStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <ItemTemplate>
                    <table style="width: 100%">
                        <tr>
                          <%# Eval("kategori") %>
                        </tr>
                        
                        <tr>
                            <td>
                              <div style="float:right">  <a href="KategoriDuzenle.aspx?id=<%# Eval("ID") %>">Düzenle</a>&nbsp;&nbsp;&nbsp; <asp:LinkButton ID="LinkButton2" ForeColor="Red" runat="server"  >Sil</asp:LinkButton></div></td>
                        </tr>
                    </table>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList></div>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>

