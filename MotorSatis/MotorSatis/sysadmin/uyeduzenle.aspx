<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true"
    CodeFile="uyeduzenle.aspx.cs" Inherits="sysadmin_uyeduzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="block">
        <div class="block_head">
            <div class="bheadl">
            </div>
            <div class="bheadr">
            </div>
            <h2>
                ÜYE DÜZENLE</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
            </p>
            <br />
            <table class="form">
                <tbody>
                    <tr>
                        <td>
                            E-Mail Adresi:
                        </td>
                        <td>
                            <asp:TextBox ID="txtmail" runat="server" Width="350px" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtmail"
                                SetFocusOnError="true" ErrorMessage="E-Mail adresinizi yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtmail"
                                ErrorMessage="Geçerli formatta yazınız." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Kullanıcı Adı:
                        </td>
                        <td>
                            <asp:TextBox ID="txtkadi" runat="server" Width="350px"  Enabled="false"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorkadi" runat="server" ControlToValidate="txtkadi"
                                SetFocusOnError="true" ErrorMessage="Kullanıcı adını yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Şifre:
                        </td>
                        <td>
                            <asp:TextBox ID="txtsifre" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatormail" runat="server" ControlToValidate="txtsifre"
                                SetFocusOnError="true" ErrorMessage="Şifrenizi yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ad Soyad:
                        </td>
                        <td>
                            <asp:TextBox ID="txtad" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtad"
                                SetFocusOnError="true" ErrorMessage="Adınızı ve soyadınızı yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Aktivasyon:
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" Text="Üyelik aktive edilmiş." Checked="true" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <p>
                <asp:Button ID="Button2" runat="server" Text="Onayla" OnClick="Button1_Click" class="butonlar" />
            </p>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>
