using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class uyegiris : System.Web.UI.Page
{
    static string oncekisayfa = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Önceki sayfa adresini alıcaz
        if (!Page.IsPostBack)
        {
            oncekisayfa = Request.UrlReferrer.ToString();
        }
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand("select * from Uyeler where Kadi=@kadi and Sifre=@sifre", con);
        cmd.Parameters.AddWithValue("@kadi", TextBox1.Text);
        cmd.Parameters.AddWithValue("@sifre", TextBox2.Text);
        SqlDataReader dr = cmd.ExecuteReader();
        if (dr.Read() == true)
        {
            Session["uye_id"] = dr["ID"];
            Session["adsoyad"] = dr["AdSoyad"];
            //bir önceki sayfaya yönlendirme
            Response.Redirect(oncekisayfa);
        }
        else
        {
            lblgiris.Visible = true;
            lblgiris.Text = "E-mail yada Parola Yanlış Girildi";
            lblgiris.ForeColor = System.Drawing.Color.Red;
        }
        con.Close();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into Uyeler (AdSoyad,Kadi,Sifre,Email,Soru,Cevap) values (@adsoyad,@kadi,@sifre,@email,@soru,@cevap)", con);
        cmd.Parameters.AddWithValue("@adsoyad", txtadsoyad.Text);
        cmd.Parameters.AddWithValue("@kadi", txtkadi.Text);
        cmd.Parameters.AddWithValue("@sifre", txtparola.Text);
        cmd.Parameters.AddWithValue("@email", txtemail.Text);
        cmd.Parameters.AddWithValue("@soru", txtsoru.Text);
        cmd.Parameters.AddWithValue("@cevap", txtcevap.Text);
        cmd.ExecuteNonQuery();
        lblkayit.Visible = true;
        lblkayit.Text = "Kaydınız Başarıyla Gerçekleşti";
        lblkayit.ForeColor = System.Drawing.Color.Red;
        con.Close();
    }
}