<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="SliderEkle.aspx.cs" Inherits="sysadmin_SliderEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                BANNER Ekleme</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
                &nbsp;</p>
               <font style="color:Red"> Yükleyeceğiniz resim 710*495 şeklinde yeniden boyutlandırılacaktır. Lütfen görüntü bozukluğu olmaması için bu boyutlara uygun resim yükleyiniz.<br /><br />
          </font>  <br />
            <p>
                Resim seçiniz<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </p>
            <p>Link<br />
                <asp:TextBox ID="txtlink" runat="server"></asp:TextBox>
            
            </p>
            <p>
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
