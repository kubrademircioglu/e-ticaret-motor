using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text.RegularExpressions;
public partial class mainmaster : System.Web.UI.MasterPage
{
    private void menudoldur()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from menuler order by goruntu_sirasi";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rptmenu.DataSource = dt;
        rptmenu.DataBind();
        con.Close();
    }

    public void SepetGetir()
    {
        if (Sepet.Instance.Items.Count == 0)
        {
            sepetdiv.InnerHtml = "<img src='img/cart.png' width='32px' />Sepetiniz henüz boş. <a href='sepet.aspx'>  Sepetim</a>";
        }
        else
        {
            sepetdiv.InnerHtml = "<img src='img/cart.png' width='32px' />Sepetinizde " + Sepet.Instance.ToplamSepetMiktari() + " ürün bulunuyor.  <a href='sepet.aspx'>  Sepetim</a>";
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //Eğer giriş yapılmadıysa
        if (Session["uye_id"] == null)
        {
            btngiris.Visible = true;
            btncikis.Visible = false;
        }
        else //Giriş yapıldığında
        {
            btngiris.Visible = false;
            btncikis.Visible = true;
            adsoyad.Text = Session["adsoyad"].ToString();
        }

        if (!IsPostBack)
        {
            SepetGetir();
        }
        menudoldur();
    }

    protected void btnAra_Click(object sender, EventArgs e)
    {
        if (txtArananan.Text != "ara...")
        {
            if (Regex.Replace(txtArananan.Text, @"<(.|\n)*?>", string.Empty).Length >= 3)
            {
                Response.Redirect("ara.aspx?key=" + Regex.Replace(txtArananan.Text, @"<(.|\n)*?>", string.Empty));
            }
            else
            {
                Response.Redirect("ara.aspx");
            }
        }
    }
    protected void btngiris_Click(object sender, EventArgs e)
    {
        Response.Redirect("uyegiris.aspx");
    }
    protected void btncikis_Click(object sender, EventArgs e)
    {
        Session["uye_id"] = null;
        Session["adsoyad"] = null;
        Response.Redirect("Default.aspx");
    }
}
