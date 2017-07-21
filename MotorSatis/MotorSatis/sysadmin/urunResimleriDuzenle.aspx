<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="urunResimleriDuzenle.aspx.cs" Inherits="sysadmin_urunResimleriDuzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                ÜRÜN RESİM DÜZENLEME</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
                &nbsp;</p>
             <font style="color:Red"> Yükleyeceğiniz resmin genişliği 750px olarak yeniden boyutlandırılacaktır.<br /><br />
          </font><br />
            <p>
                Resim <br />
            <asp:Image ID="Image1" runat="server" Height="150" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
            </p>
            <p>
                Resim seçiniz - (<b style="color:Red">Değişmeyecekse boş bırakınız.</b>)<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Onayla" OnClick="Button1_Click" 
                    class="butonlar" Height="30px" />
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
