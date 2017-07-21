<%@ Page Language="C#" AutoEventWireup="true" CodeFile="modal.aspx.cs" Inherits="sysadmin_modal" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
    body
    {
        font-family:Trebuchet MS;
        font-size:12px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:DataList ID="DataList2" runat="server" Width="100%" >
                            <ItemTemplate>
                                    <tr>
                                        <td >
                                            <asp:Label ID="Label7" runat="server" Text='<%# Eval("SepetID") %>'></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label8" runat="server" Text='<%# Eval("UrunAdi") %>'></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label9" runat="server" Text='<%# Eval("BirimFiyat").ToString() %>'></asp:Label>
                                        </td>
                                        <td >
                                            <asp:Label ID="Label10" runat="server" Text='<%# Eval("miktar") %>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:Label ID="Label11" runat="server" Text='<%# Eval("Tutar") %>'></asp:Label>
                                        </td>
                                    </tr>
                             
                            </ItemTemplate>
                            <HeaderTemplate>
                            <tr style="font-weight:bolder;color:Green">
                                        <td >
                                           Sepet ID
                                        </td>
                                        <td >
                                        Ürün Adı
                                        </td>
                                        <td >
                                            Birim Fiyat
                                        </td>
                                        <td >
                                         Miktar
                                        </td>
                                        <td>
                                            Tutar
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                        </asp:DataList>
    </div>
    </form>
</body>
</html>
