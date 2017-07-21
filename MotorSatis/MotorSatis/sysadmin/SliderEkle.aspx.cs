using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;
using System.Drawing.Imaging;

public partial class sysadmin_SliderEkle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    protected void Button1_Click(object sender, EventArgs e)
    {
        String extension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
        if (System.Text.RegularExpressions.Regex.IsMatch(extension, ".png|.jpg|.jpeg|.pjpeg|.PNG|.JPG|.JPEG|.PJPEG") && FileUpload1.HasFile)
        {
            try
            {
                string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_");

               

                Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.OranlaveKaydet(kucukResim, 710, 495, Server.MapPath("../dinamikimg/Sliders/" + filenameadd + FileUpload1.FileName));


                dt.BaglantiAc();

                SqlParameter[] prms = { 
                dt.ParametreEkle("@bann", SqlDbType.VarChar,filenameadd + FileUpload1.FileName),
                dt.ParametreEkle("@plink", SqlDbType.VarChar,txtlink.Text)};


                int i = dt.GetExecuteNonQuery("INSERT INTO Sliders(Slider,Link) VALUES(@bann,@plink)", prms);
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

   
}