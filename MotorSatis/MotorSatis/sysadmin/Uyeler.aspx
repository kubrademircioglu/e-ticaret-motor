<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true"
    CodeFile="Uyeler.aspx.cs" Inherits="sysadmin_Uyeler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                ÜYELER</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
            <br />
            <asp:Label ID="lblbos" runat="server" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
            <asp:DataList ID="DataList1" runat="server" RepeatColumns="1" DataKeyField="ID" ForeColor="#333333"
                OnItemCommand="DataList1_ItemCommand" Width="100%">
                <AlternatingItemStyle BackColor="White" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("Email")%>
                        </td>
                        <td>
                            <%#Eval("AdSoyad")%>
                        </td>
                        <td>
                            <%#Eval("aktif")%>
                        </td>
                        <td>
                            <div style="float: right">
                                <a href="uyeduzenle.aspx?id=<%# Eval("ID") %>">Düzenle / İncele</a>&nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Red" CommandName="sil"
                                    OnClientClick="javascript:return confirm('Bu kayıt kalıcı olarak silinsin mi?');">sil</asp:LinkButton></div>
                        </td>
                    </tr>
                </ItemTemplate>
                <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:DataList><p>
            </p>
            <p>
            </p>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>
