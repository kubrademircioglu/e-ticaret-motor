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


public partial class sysadmin_sepetduzenle : System.Web.UI.Page
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

                Response.Redirect("sepetler.aspx", true);
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

            SqlDataReader rdr = dt.GetReader("Select * From sepet where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                txtkadi.Text = rdr["KullaniciAdi"].ToString();
                txtKargo.Text = rdr["kargo"].ToString();
                txtOdemeAlindimi.Text = rdr["odemealindi"].ToString();
                txtOdemeDurum.Text = rdr["durum"].ToString();
                txtOdemeTip.Text = rdr["OdemeTip"].ToString();
                txtSepettutar.Text = rdr["SepetTutar"].ToString();
                

            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>sepet içeriği bulunamadı !</p></div>";
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(Request.QueryString["id"])),
            dt.ParametreEkle("@pkargo", SqlDbType.VarChar, txtKargo.Text),
	        dt.ParametreEkle("@podemealindi", SqlDbType.VarChar, txtOdemeAlindimi.Text),
	        dt.ParametreEkle("@pdurum", SqlDbType.VarChar, txtOdemeDurum.Text),
            dt.ParametreEkle("@pOdemeTip", SqlDbType.VarChar, txtOdemeTip.Text),
            dt.ParametreEkle("@pSepetTutar", SqlDbType.Decimal, Convert.ToDecimal( txtSepettutar.Text))};



            int i = dt.GetExecuteNonQuery("UPDATE sepet SET kargo=@pkargo ,odemealindi=@podemealindi ,durum=@pdurum , OdemeTip=@pOdemeTip, SepetTutar=@pSepetTutar  WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Güncellenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Güncellendi !</p></div>";
                Response.Redirect("sepetler.aspx", false);
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