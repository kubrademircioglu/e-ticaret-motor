<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="sysadmin_Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                Sayfa içerik düzenleme</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
     
            <br />
          <h1>ADMİN KULLANICI EKLE</h1><br />



     
                    <p>
                        <label>
                            Admin Kullanıcı Adı
                        </label>
                        <br />
                        <asp:TextBox ID="txtuser" runat="server" Width="60%"></asp:TextBox>
                    </p>
                     <p>
                        <label>
                            Admin Şifre
                        </label>
                        <br />
                        <asp:TextBox ID="txtsifre" runat="server" Width="60%" OnTextChanged="txtsifre_TextChanged"></asp:TextBox>
                    </p>
                    <br />
                    <p>
                        <asp:Button ID="Button1" runat="server" Text="EKLE" OnClick="Button1_Click" class="butonlar" />
                    </p>
                    <br /><br />
                    <hr /><br /><br /> <h1>ADMİN KULLANICI DÜZENLE</h1><br />
                 <p>
                        <label>
                            Admin Kullanıcılar
                        </label>
                        <br />
                        <asp:DropDownList ID="DropDownList1" runat="server" Width="285px" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </p>
                    <p>
                        <label>
                            Yeni Kullancı Adı</label><br />
                        <asp:TextBox ID="txtadminguncelle" runat="server" Width="60%"></asp:TextBox>
                    </p>
                     <p>
                        <label>
                            Yeni Şifre</label><br />
                        <asp:TextBox ID="txtsifreguncelle" runat="server" Width="60%"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="Button2" runat="server" Text="GÜNCELLE" OnClick="Button2_Click" class="butonlar" />veya&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="SİL" OnClick="Button3_Click" class="butonlar" />
                    </p>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>

