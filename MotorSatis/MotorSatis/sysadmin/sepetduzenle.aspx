<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true" CodeFile="sepetduzenle.aspx.cs" Inherits="sysadmin_sepetduzenle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                            Sepet Tutar:
                        </td>
                        <td>
                            <asp:TextBox ID="txtSepettutar" runat="server" Width="350px" ReadOnly="true"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorsepettutar" runat="server" ControlToValidate="txtSepettutar"
                                SetFocusOnError="true" ErrorMessage="Sepet tutarını yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ödeme Tipi:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOdemeTip" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorodemetip" runat="server" ControlToValidate="txtOdemeTip"
                                SetFocusOnError="true" ErrorMessage="Ödeme Tipini yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ödeme Durumu:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOdemeDurum" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidatorodemedurum" runat="server" ControlToValidate="txtOdemeDurum"
                                SetFocusOnError="true" ErrorMessage="Ödeme durumunu yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ödeme 
                            Alındı Mı:
                        </td>
                        <td>
                            <asp:TextBox ID="txtOdemeAlindimi" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOdemeAlindimi"
                                SetFocusOnError="true" ErrorMessage="Ödeme Alındı mıyı yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>  
                    <tr>
                        <td>
                            Kargo:
                        </td>
                        <td>
                            <asp:TextBox ID="txtKargo" runat="server" Width="350px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtKargo"
                                SetFocusOnError="true" ErrorMessage="Kargo durumunu yazınız." Display="Dynamic"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </tbody>
            </table>
            <p>
                <asp:Button ID="btnSave" runat="server" Text="Kaydet"  class="butonlar" 
                    onclick="btnSave_Click" />
            </p>
        </div>
        <!-- .block_content ends -->
        <div class="bendl">
        </div>
        <div class="bendr">
        </div>
    </div>
</asp:Content>

