using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class sepet : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SepetGetir();
        }
    }

    double toplamfiyat = 0;
    public void SepetGetir()
    {
        if (Sepet.Instance.Items.Count == 0)
        {
            lblbos.Text = "Sepetiniz henüz boş. <a href='Default.aspx' style='font-size: 17px; color: Red;'>Buradan ana sayfaya</a> ulaşabilirsiniz.";
            sepetDiv.Visible = false;
        }
        else
        {
            rptsepet.DataSource = Sepet.Instance.Items;
            rptsepet.DataBind();

            //toplam fiyatlar
            toplamfiyat = Convert.ToDouble(Sepet.Instance.ToplamTutar());

            lblgenel.Text = string.Format("{0:0.00}", toplamfiyat);


            //lblaratoplam.Text = string.Format("{0:0.00}", toplamfiyat);
            //lblkdv.Text = string.Format("{0:0.00}", (toplamfiyat * 1.18) - toplamfiyat);
            //lblgenel.Text = string.Format("{0:0.00}", (toplamfiyat * 1.18));


        }
    }
    protected void rptsepet_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "sil")
        {
            Sepet.Instance.SepettenSil(Convert.ToInt32(((HiddenField)rptsepet.Items[e.Item.ItemIndex].FindControl("hdID")).Value));
        }
        else if (e.CommandName == "guncelle")
        {
            TextBox txtyenimiktar = (TextBox)rptsepet.Items[e.Item.ItemIndex].FindControl("txtmiktar");
            if (txtyenimiktar.Text != null && System.Text.RegularExpressions.Regex.IsMatch(txtyenimiktar.Text, "\\d+"))
            {
                try
                {
                    if (Convert.ToInt32(txtyenimiktar.Text) >= 1 && Convert.ToInt32(txtyenimiktar.Text) <= 99)
                    {
                        Sepet.Instance.MiktarGuncelle(Convert.ToInt32(((HiddenField)rptsepet.Items[e.Item.ItemIndex].FindControl("hdID")).Value), Convert.ToInt32(txtyenimiktar.Text));
                    }
                    else
                    {
                        Response.Redirect("sepet.aspx", true);
                    }
                }
                catch
                {
                    Response.Redirect("sepet.aspx", true);
                }
            }
            else
            {
                Response.Redirect("sepet.aspx", true);
            }
        }

        Response.Redirect("sepet.aspx", true);
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {

        if (Session["uye_id"] == null)
        {
            Response.Redirect("uyegiris.aspx");
        }
        else
        {
            SepetYaz spstyaz = new SepetYaz();
            spstyaz.OdemeBitir(Session["adsoyad"].ToString(), "nakit", "ödenmedi", "hayır", "hayır", Convert.ToInt32(Session["uye_id"]));
            lblonay.Text = "Siparişiniz Bize Ulaşmıştır. En Kısa Sürede Adresinize Gönderilecektir...";
            //Response.Redirect("~/default.aspx");
        }

    }
}