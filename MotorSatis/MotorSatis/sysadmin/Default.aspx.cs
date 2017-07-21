using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class sysadmin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["AdminUser"] != null)
        {
            Response.Redirect("sepetler.aspx", false);
        }
    }

    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    protected void Button1_Click(object sender, EventArgs e)
    {
         string oncekisayfa = string.Empty;
        try
        {
            notify.InnerHtml = "";
            cn.Open();
            SqlCommand cmd = new SqlCommand("SELECT *  FROM AdminUsers WHERE username = @name AND pass = @pass", cn);
            cmd.Parameters.Add("@name", txtuser.Text);
            cmd.Parameters.Add("@pass", txtsifre.Text);
            SqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();
            if (rdr.HasRows)
            {                
                Session["yetki"] =rdr["yetki"].ToString();

                if (Session["yetki"].ToString() == "1")
                {
                    Session["AdminUser"] = "Admin";
                    Response.Redirect("Kategoriler.aspx", false);
                }
                else if(Session["yetki"].ToString() == "0")
                {
                    Session["AdminUser"] = "Firma";
                    Response.Redirect("Kategoriler.aspx", false);
                }

            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Kullanıcı Adı ya da Şifre Hatalı! Lütfen tekrar deneyiniz.</p></div>";
            }

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Hata oluştu : " + ex.Message + "</p></div>";
        }
    }
}