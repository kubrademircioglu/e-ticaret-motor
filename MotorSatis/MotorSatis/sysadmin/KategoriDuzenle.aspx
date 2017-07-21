<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="KategoriDuzenle.aspx.cs" Inherits="sysadmin_KategoriDuzenle" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<%@ Register Assembly="CKFinder" Namespace="CKFinder" TagPrefix="CKFinder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                Marka Düzenle</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
           <p>
                Marka Adı : <br />
                <asp:TextBox ID="txtad" runat="server" Width="792px" Text=""></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtad"
                    ErrorMessage="Boş geçilemez."></asp:RequiredFieldValidator>
            </p>

           
           <p>
                    <label>
                        Sayfa içeriği :
                    </label>
                    <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server"></CKEditor:CKEditorControl>
                    <br />
                </p>
               <p>
                    Başlık (Title)<br />
                    <asp:TextBox ID="txttitle" runat="server"  Width="889px" ></asp:TextBox>
                </p>
                <p>
                    Anahtar Kelimeler (Keywords)<br />
                    <asp:TextBox ID="txtkeys" runat="server" TextMode="MultiLine" Width="889px" Height="109px"></asp:TextBox>
                </p>
                <p>
                    Tanımlama (Description)<br />
                    <asp:TextBox ID="txtdesc" runat="server" TextMode="MultiLine" Width="889px" Height="109px"></asp:TextBox>
                </p>

          
            <p>
                &nbsp;</p>
             <p>
   
                <br />
                <asp:Button ID="Button1" runat="server" Text="Onayla" OnClick="Button1_Click" class="butonlar" />
            </p>
        </div>
        <br />
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>
