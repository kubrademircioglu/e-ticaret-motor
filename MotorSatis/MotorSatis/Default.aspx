<%@ Page Title="" Language="C#" MasterPageFile="~/mainmaster.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="module_slider" style="float: left; width: 100%;">
        <div class="next">
        </div>
        <div class="prev">
        </div>
        <div class="width-banners" style="width: 100%;">
            <div class="boxIndent">
                <div class="slider-wrapper theme-default">
                    <div class="wrapper">
                        <asp:Label ID="lblsliderhata" runat="server" Text=""></asp:Label>
                        <div id="slider" class="nivoSlider" style="width: 100%;">
                            <asp:Repeater ID="rptsliders" runat="server">
                                <ItemTemplate>
                                    <a href="<%#Eval("Link") %>">
                                        <img src="dinamikimg/Sliders/<%#Eval("Slider") %>" alt="motor" /></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="module_banners">
        <div class="next">
        </div>
        <div class="prev">
        </div>
        <div class="width-banners">
            <div class="boxIndent">
                <div class="wrapper">
                    <div class="bannergroup_banners">
                        <div class="banneritem_banners">
                            <div class="clr">
                            </div>
                        </div>
                        <div class="banneritem_banners">
                            <a href="encoksatanlar.aspx">&nbsp;</a><div class="clr">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="module_banners1">
        <div class=" jcarousel-skin-tango">
            <div class="jcarousel-container jcarousel-container-horizontal" style="position: relative;
                display: block;">
                <div class="jcarousel-clip jcarousel-clip-horizontal" style="position: relative;">
                    <ul id="mycarousel" class="jcarousel-list jcarousel-list-horizontal" style="overflow: hidden;
                        position: relative; top: 0px; margin: 0px; padding: 0px; left: 0px; width: 960px;">
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=1" title=''>
                                <img src="img/1_kanuni.jpg" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=7" title=''>
                                <img src="img/bmwlogo.png" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=3" title=''>
                                <img src="img/suzuki-logo1.jpg" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=2" title=''>
                                <img src="img/mondiallogo.jpg" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=1" title=''>
                                <img src="img/1_kanuni.jpg" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=7" title=''>
                                <img src="img/bmwlogo.png" width="120" height="82" alt='' />
                            </a></li>
                        <li class="jcarousel-item jcarousel-item-horizontal jcarousel-item-1 jcarousel-item-1-horizontal">
                            <a href="urun.aspx?kategoriid=3" title=''>
                                <img src="img/mondiallogo.jpg" width="120" height="82" alt='' />
                            </a></li>
                       
                    </ul>
                </div>
                <div class="jcarousel-prev jcarousel-prev-horizontal jcarousel-prev-disabled jcarousel-prev-disabled-horizontal"
                    style="display: block;" disabled="true">
                </div>
                <div class="jcarousel-next jcarousel-next-horizontal" style="display: block;" disabled="false">
                </div>
            </div>
        </div>
    </div>
    <div class="clear">
    </div>
</asp:Content>
