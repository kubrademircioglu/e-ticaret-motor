﻿<%@ Page Title="" Language="C#" MasterPageFile="~/sysadmin/Admin.master" AutoEventWireup="true"
    CodeFile="urunekle.aspx.cs" Inherits="sysadmin_urunekle" %>

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
                Ürün Ekleme</h2>
        </div>
        <!-- .block_head ends -->
        <div class="block_content">
            <div runat="server" id="notify">
            </div>
            <p>
                &nbsp;</p>
                <p>
               Marka Seçiniz :<br />
                    <asp:DropDownList ID="drpkategori"  Width="792px" runat="server">
                    </asp:DropDownList>

            </p>
             <p>
               Menü Seçiniz :<br />
                    <asp:DropDownList ID="drpmenu"  Width="792px" runat="server">
                    </asp:DropDownList>

            </p>

            <p>
                Ürün Adı :<br />
                <asp:TextBox ID="txturunadi" runat="server" Width="792px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txturunadi"
                    ErrorMessage="Boş geçilemez." SetFocusOnError="True"></asp:RequiredFieldValidator>
            </p>
            <p>
                Ürün Kodu :
                <br />
                <asp:TextBox ID="txturunkodu" runat="server" Width="792px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txturunkodu"
                    ErrorMessage="Boş geçilemez." SetFocusOnError="True"></asp:RequiredFieldValidator>
            </p>
            <p>
                Ürün Kısa Açıklaması :<br />
                <asp:TextBox ID="txtozet" runat="server" TextMode="MultiLine" Height="150px" Width="792px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtozet"
                    ErrorMessage="Boş geçilemez." SetFocusOnError="True"></asp:RequiredFieldValidator>
            </p>
            <p>
                Ürün Özellikleri :<br />
                <CKEditor:CKEditorControl ID="ckozellikler" runat="server" Height="123px"></CKEditor:CKEditorControl>
            </p>
            
            <p>
                Ürün Fiyatı (KDV dahil fiyatı yanlızca rakam olarak giriniz. Örnek : 317,50     küsürat için virgül kullanınız.) :
                <br />
                <asp:TextBox ID="txturunfiyati" runat="server" Width="792px"></asp:TextBox> 
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
            </p>
            <p>
                Resim seçiniz :<br />
                <asp:FileUpload ID="FileUpload1" runat="server" />
            </p>
            
             <p>
               
                 &nbsp;</p>
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
