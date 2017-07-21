using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

public partial class sysadmin_urunResimleriEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("urunler.aspx",true);
        }
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void resimEkle(int id)
    {
        String extension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
        if (System.Text.RegularExpressions.Regex.IsMatch(extension, ".png|.jpg|.jpeg|.pjpeg|.PNG|.JPG|.JPEG|.PJPEG") && FileUpload1.HasFile)
        {
            try
            {
                string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_");


                Bitmap buyukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.YaziEkleVeOrantılıKaydet(buyukResim, 750, Server.MapPath("../dinamikimg/ExtraUrunler/" + filenameadd + FileUpload1.FileName),"DantelEvim.com");


                Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.OranlaveKaydet(kucukResim, 77, 77, Server.MapPath("../dinamikimg/ExtraUrunler/mini/" + filenameadd + FileUpload1.FileName));


                dt.BaglantiAc();

                SqlParameter[] prms = { 
                dt.ParametreEkle("@res", SqlDbType.VarChar,filenameadd + FileUpload1.FileName),
                dt.ParametreEkle("@id", SqlDbType.Int,id)};


                int i = dt.GetExecuteNonQuery("INSERT INTO ExtraUrunResimleri(Urunresim,UrunID) VALUES(@res,@id)", prms);
                if (i == 0)
                {
                    notify.InnerHtml = "<div class='message errormsg'><p>Eklenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
                }
                else
                {
                    notify.InnerHtml = "<div class='message success'><p>Eklendi !</p></div>";
                }


            }
            catch (Exception ex)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
            }
            finally
            {
                dt.BaglantiKapat();
            }
        }
        else
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Resim alanı boş geçilemez ve resim uzantısı yanlızca .png,.jpg,.jpeg,.pjpeg uzantıları kabul edilir !</p></div>";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            resimEkle(Convert.ToInt32(Request.QueryString["id"].ToString()));
        }
        catch
        {
            Response.Redirect("urunler.aspx",true);
        }
    }
}