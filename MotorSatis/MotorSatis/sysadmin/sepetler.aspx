<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true"
    CodeFile="sepetler.aspx.cs" Inherits="sysadmin_sepetler" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style>
        .white_content
        {
            display: none;
            position: fixed;
            top: 25%;
            left: 25%;
            width: 50%;
            height: 50%;
            padding: 16px;
            border: 16px solid orange;
            background-color: white;
            z-index: 1002;
            overflow: auto;
        }
    </style>
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                Sepetler</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
                Tarihe göre filtrele :<p>
                    <asp:TextBox ID="TextBox1" runat="server" Width="280px"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Getir</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp; |&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Tüm Satışlar</asp:LinkButton>
                    <center>
                        <asp:DataList ID="DataList1" runat="server" Width="940px" DataKeyField="ID" OnItemCommand="DataList1_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </td>
                                    <td style="width: 135px">
                                        <asp:Label ID="lbltarih" runat="server" Text='<%# Eval("Tarih") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("KullaniciAdi") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("SepetTutar").ToString() %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Text='<%# Eval("OdemeTip") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Text='<%# Eval("durum") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label5" runat="server" Text='<%# Eval("odemealindi") %>'></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label6" runat="server" Text='<%# Eval("kargo") %>'></asp:Label>
                                    </td>
                                    <td>
                                        
                                            <a href="javascript:void(0)" style="color:Blue" onclick="document.getElementById('light<%# Eval("ID") %>').style.display='block';">
                                                incele</a>
                                        <div id="light<%# Eval("ID") %>" class="white_content">
                                            <iframe src="modal.aspx?id=<%# Eval("ID") %>" frameborder="0" width="100%" height="90%">
                                            </iframe>
                                            <br />
                                            <a style="color:Red;font-weight:bolder;float:right;" href="javascript:void(0)" onclick="document.getElementById('light<%# Eval("ID") %>').style.display='none';">
                                                Kapat</a></div>
                                    </td>
                                    <td>
                                        <asp:LinkButton ID="LinkButton2" runat="server" ForeColor="Blue" CommandName="duzenle">düzenle</asp:LinkButton>
                                    </td>
                                </tr>
                            </ItemTemplate>
                        </asp:DataList>
                        <br />
                        <asp:DataList ID="DataList2" runat="server" Width="800px" Visible="False">
                            <ItemTemplate>
                                <table style="width: 100%">
                                    <tr>
                                        <td style="width: 49px">
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("SepetID") %>'></asp:Label>
                                        </td>
                                        <td style="width: 273px">
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label>
                                        </td>
                                        <td style="width: 173px">
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("BirimFiyat").ToString() %>'></asp:Label>
                                        </td>
                                        <td style="width: 144px">
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("miktar") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("Tutar") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:DataList>
                    </center>
                </p>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>
