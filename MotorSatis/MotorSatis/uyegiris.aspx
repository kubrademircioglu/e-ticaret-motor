<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.master" AutoEventWireup="true"
    CodeFile="uyegiris.aspx.cs" Inherits="uyegiris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%">
        <tr>
            <td colspan="3" style="color: #000000; text-align: center;">
                Giriş Yap<br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="color: #000000; width: 242px;">
                Kullanıcı Adı&nbsp;
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            </td>
            <td style="color: #000000">
                Parola&nbsp;&nbsp;
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" CausesValidation="False" Text="Giriş Yap"
                    ForeColor="#003300" OnClick="Button1_Click" />
            </td>
            <td style="color: #000000">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="3" style="color: #000000">
                <asp:Label ID="lblgiris" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
    <table style="width: 100%">
        <tr>
            <td colspan="2" style="text-align: center">
                <br />
                Kayıt Ol<br />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Ad Soyad
            </td>
            <td>
                <asp:TextBox ID="txtadsoyad" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtadsoyad"
                    ErrorMessage="Bu Alan Boş Geçilemez" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Kullanıcı Adı
            </td>
            <td>
                <asp:TextBox ID="txtkadi" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtkadi"
                    ErrorMessage="Bu Alan Boş Geçilemez" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Parola
            </td>
            <td>
                <asp:TextBox ID="txtparola" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtparola"
                    ErrorMessage="Bu Alan Boş Geçilemez" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Tekrar Parola
            </td>
            <td>
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtparola"
                    ControlToValidate="TextBox3" ErrorMessage="Parolalar Uyuşmuyor" ForeColor="Red"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px; height: 31px">
                E-Mail
            </td>
            <td style="height: 31px">
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtemail"
                    ErrorMessage="Geçersiz E-Mail" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Güvenlik Sorusu
            </td>
            <td>
                <asp:TextBox ID="txtsoru" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsoru"
                    ErrorMessage="Bu Alan Boş Geçilemez" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                Cevap
            </td>
            <td>
                <asp:TextBox ID="txtcevap" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcevap"
                    ErrorMessage="Bu Alan Boş Geçilemez" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 276px">
                &nbsp;
            </td>
            <td>
                <br />
                <asp:Button ID="Button2" runat="server" ForeColor="#003300" OnClick="Button2_Click"
                    Text="Üye Ol" />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblkayit" runat="server" Text="Label" Visible="False"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
