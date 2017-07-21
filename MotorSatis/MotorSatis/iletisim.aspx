<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.master" AutoEventWireup="true"
    CodeFile="iletisim.aspx.cs" Inherits="iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="iceriksol">
        
        <table class="width">
            <tr>
                <td style="width: 458px">
                    <span style="color: rgb(97, 97, 97); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-size: 13px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">
                    Görüş, öneri ve isteklerinizi aşağıdaki formu
                    <br />
                    kullanarak bize iletebilirsniz...<br />
                    </span></td>
                <td style="width: 400px">
                    <span id="Cont_cn_Label5" 
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; float: left; width: 80px; color: rgb(134, 25, 31); line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    Adres :</span><p 
                        style="border: 0px; background-color: transparent; font-size: 13px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(97, 97, 97); float: left; width: 200px; line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                        Düzce üniversitesi akçakoca yolu no:10 kat:2 Adana/Düzce</p>
                </td>
                <td rowspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 458px">
                    <span style="color: rgb(219, 87, 111); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">
                    Ad Soyad *<br />
                    </span>
                    <asp:TextBox ID="txtad" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtad" ErrorMessage="Bu Alan Boş Geçilemez"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 400px" rowspan="2">
                    <span id="Cont_cn_Label6" 
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; float: left; width: 80px; color: rgb(134, 25, 31); line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    Telefon :</span><p 
                        style="border: 0px; background-color: transparent; font-size: 13px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(97, 97, 97); float: left; width: 200px; line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                        +90(380) 000 00 00</p>
                    <span id="Cont_cn_Label7" 
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; float: left; width: 80px; color: rgb(134, 25, 31); line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    <br />
                    </span><p 
                        style="border: 0px; background-color: transparent; font-size: 13px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(97, 97, 97); float: left; width: 200px; line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    <span id="Cont_cn_Label8" 
                        
                            style="background-color: transparent; font-size: 14px; outline: 0px; vertical-align: top; float: left; width: 80px; color: rgb(134, 25, 31); line-height: 22px; font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-repeat: initial initial; ">
                    Fax :</span>+90(380) 000 00 11</p>
                </td>
            </tr>
            <tr>
                <td style="width: 458px">
                    <span id="Cont_cn_Label1" 
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(219, 87, 111); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    Email *<br />
                    </span>
                    <asp:TextBox ID="txtmail" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtmail" ErrorMessage="Geçersiz E-Mail" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 458px">
                    <span id="Cont_cn_Label3" 
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(219, 87, 111); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    Telefon<br />
                    </span>
                    <asp:TextBox ID="txttel" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
                    <span style="color: rgb(219, 87, 111); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-size: 14px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; display: inline !important; float: none; ">
                    <span id="Cont_cn_Label9" 
                        
                        style="border: 0px; background-color: transparent; font-size: 14px; margin: 0px; padding: 0px; outline: 0px; vertical-align: top; color: rgb(219, 87, 111); font-family: 'Trebuchet MS', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: 2; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-size-adjust: auto; -webkit-text-stroke-width: 0px; background-position: initial initial; background-repeat: initial initial; ">
                    Mesaj İçeriği</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtmesaj" ErrorMessage="Mesaj Alanı Boş Geçilemez"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="txtmesaj" runat="server" Height="79px" TextMode="MultiLine" 
                        Width="400px"></asp:TextBox>
                    <br />
                    <br />
                    <asp:Button ID="Button1" runat="server" BorderStyle="Double" BorderWidth="2px" 
                        ForeColor="#CC0000" onclick="Button1_Click" Text="Gönder" />
                    <br />
                    <br />
                    <asp:Label ID="Label1" runat="server" ForeColor="#CC0000" Visible="False"></asp:Label>
                </td>
                <td style="width: 400px">
                    &nbsp;<iframe width="425" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" 
                   src="https://www.google.com.tr/maps/place/D%C3%BCzce,+D%C3%BCzce+Merkez%2FD%C3%BCzce/@40.8531821,31.1175789,13z/data=!3m1!4b1!4m5!1m2!2m1!1s%C3%BCniversite!3m1!1s0x409da01b6536d421:0xe1d0a622568cf8d7"></iframe><br /><small><a href="https://www.google.com.tr/maps/place/D%C3%BCzce,+D%C3%BCzce+Merkez%2FD%C3%BCzce/@40.8531821,31.1175789,13z/data=!3m1!4b1!4m5!1m2!2m1!1s%C3%BCniversite!3m1!1s0x409da01b6536d421:0xe1d0a622568cf8d7" style="color:#0000FF;text-align:left">View Larger Map>View Larger Map</a></small></td>
            </tr>
            </table>
        
    </div>
</asp:Content>
