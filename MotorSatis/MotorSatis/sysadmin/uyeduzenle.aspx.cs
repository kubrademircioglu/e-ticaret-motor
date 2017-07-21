using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;

public partial class sysadmin_uyeduzenle : System.Web.UI.Page
{
   
   protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            try
            {
                getir(Convert.ToInt32(Request.QueryString["id"]));
            }
            catch
            {

                Response.Redirect("Uyeler.aspx", true);
            }
        }

    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    protected void getir(int id)
    {
        try
        {
            notify.InnerHtml = "";


            dt.BaglantiAc();
            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };

            SqlDataReader rdr = dt.GetReader("Select * From Uyeler where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                txtmail.Text=rdr["Email"].ToString();
	            txtsifre.Text=rdr["Sifre"].ToString();
	            txtad.Text=rdr["AdSoyad"].ToString();
                txtkadi.Text = rdr["Kadi"].ToString();

                if(Convert.ToBoolean(rdr["aktif"].ToString()) == false)
                {
                    CheckBox1.Checked = false;
                    CheckBox1.Text = "  Aktivasyon yapılmadı.";
                    CheckBox1.ForeColor = Color.Red;
                }
                 
            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Marka içeriği bulunamadı !</p></div>";
            }

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
            dt.Dispose();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(Request.QueryString["id"])),
            dt.ParametreEkle("@p_Email", SqlDbType.VarChar, txtmail.Text),
	        dt.ParametreEkle("@p_Sifre", SqlDbType.VarChar, txtsifre.Text),
	        dt.ParametreEkle("@p_AdSoyad", SqlDbType.VarChar, txtad.Text),
            dt.ParametreEkle("@aktive", SqlDbType.Bit, Convert.ToBoolean(CheckBox1.Checked))};



            int i = dt.GetExecuteNonQuery("UPDATE Uyeler SET Email=@p_Email ,Sifre=@p_Sifre ,AdSoyad=@p_AdSoyad , aktif=@aktive  WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Güncellenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Güncellendi !</p></div>";
                Response.Redirect("Uyeler.aspx", false);
            }

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
            dt.Dispose();
        }
    }
}