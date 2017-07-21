using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;

public partial class sysadmin_urunekle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Kategoriler();
            Menuler();
        }

        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder/";
        _FileBrowser.SetupCKEditor(ckozellikler);
    }


    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    DataAccess dt2 = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void Kategoriler()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = dt.GetDataSet("select * from Kategoriler", null);

            drpkategori.DataTextField = "Kategori";
            drpkategori.DataValueField = "ID";

            drpkategori.DataSource = ds;
            drpkategori.DataBind();

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Hata oluştu : " + ex.Message + "</p></div>";
        }
        finally
        {
            dt.Dispose();
        }
    }

    public void Menuler()
    {
        try
        {
            DataSet ds2 = new DataSet();
            ds2 = dt2.GetDataSet("select * from menuler", null);

            drpmenu.DataTextField = "menu";
            drpmenu.DataValueField = "id";

            drpmenu.DataSource = ds2;
            drpmenu.DataBind();

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Hata oluştu : " + ex.Message + "</p></div>";
        }
        finally
        {
            dt2.Dispose();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        String extension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
        if (System.Text.RegularExpressions.Regex.IsMatch(extension, ".png|.jpg|.jpeg|.pjpeg|.PNG|.JPG|.JPEG|.PJPEG") && FileUpload1.HasFile)
        {
            try
            {
                string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_").Replace(" ", "_").Replace("/", "_").Replace("\\", "_");

                Bitmap buyukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.YaziEkleVeOrantılıKaydet(buyukResim, 750, Server.MapPath("../dinamikimg/Urunler/" + filenameadd + FileUpload1.FileName), "ÖzMotorsShops.com");


                Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.OranlaveKaydet(kucukResim, 279, 180, Server.MapPath("../dinamikimg/Urunler/mini/" + filenameadd + FileUpload1.FileName));


                dt.BaglantiAc();

                SqlParameter[] prms = { 
                dt.ParametreEkle("@pUrunAdi", SqlDbType.VarChar,txturunadi.Text),
                dt.ParametreEkle("@pUrunKodu", SqlDbType.VarChar,txturunkodu.Text),
                dt.ParametreEkle("@pOzet", SqlDbType.VarChar,txtozet.Text),
                dt.ParametreEkle("@pUrunOzellikleri", SqlDbType.VarChar,ckozellikler.Text),
                dt.ParametreEkle("@pFiyati", SqlDbType.VarChar,txturunfiyati.Text),
                dt.ParametreEkle("@pResim1", SqlDbType.VarChar,filenameadd + FileUpload1.FileName),
                dt.ParametreEkle("@pKategoriID", SqlDbType.VarChar,drpkategori.SelectedItem.Value),
                dt.ParametreEkle("@title", SqlDbType.VarChar, txttitle.Text ),
                dt.ParametreEkle("@descript", SqlDbType.VarChar, txtdesc.Text ),
                dt.ParametreEkle("@keys", SqlDbType.VarChar, txtkeys.Text ),
                dt.ParametreEkle("@pmenuid", SqlDbType.VarChar,drpmenu.SelectedItem.Value),
                };

                int i = dt.GetExecuteNonQuery("INSERT INTO Urunler(UrunAdi,UrunKodu,UrunKisaAciklama,UrunOzellikleri,Fiyati,Resim1,KategoriID,Title, Description, Keyword, Menuid) VALUES(@pUrunAdi,@pUrunKodu,@pOzet,@pUrunOzellikleri,@pFiyati,@pResim1,@pKategoriID,@title, @descript, @keys, @pmenuid)", prms);
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
            notify.InnerHtml = "<div class='message errormsg'><p>Resim alanı boş geçilemez ve resim uzantısı yanlızca .jpg,.jpeg,.pjpeg uzantıları kabul edilir !</p></div>";
        }
    }

}