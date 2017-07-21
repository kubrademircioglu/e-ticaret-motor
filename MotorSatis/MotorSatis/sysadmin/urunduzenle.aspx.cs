using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Drawing;

public partial class sysadmin_urunduzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Kategoriler();
            try
            {
                getir(Convert.ToInt32(Request.QueryString["id"]));
            }
            catch
            {

                Response.Redirect("urunler.aspx", true);
            }
        }

        CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
        _FileBrowser.BasePath = "../ckfinder/";
        _FileBrowser.SetupCKEditor(CKEditorControl1);
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void Kategoriler()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = dt.GetDataSet("select * from Kategoriler", null);

            DropDownList1.DataTextField = "Kategori";
            DropDownList1.DataValueField = "ID";

            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Hata oluştu : " + ex.Message + "</p></div>";
        }
        finally
        {
            //dt.Dispose();
        }
    }


    protected void getir(int id)
    {
        try
        {
            notify.InnerHtml = "";


            dt.BaglantiAc();
            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };

            SqlDataReader rdr = dt.GetReader("Select * From Urunler where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                txturunadi.Text = rdr["UrunAdi"].ToString();
                txturunkodu.Text = rdr["UrunKodu"].ToString();
                CKEditorControl1.Text = rdr["UrunOzellikleri"].ToString();
                txtfiyat.Text = rdr["Fiyati"].ToString();
                txtozet.Text = rdr["UrunKisaAciklama"].ToString();
                txttitle.Text = rdr["Title"].ToString();
                txtdesc.Text = rdr["Description"].ToString();
                txtkeys.Text = rdr["Keyword"].ToString();

                for (int j = 0; j < DropDownList1.Items.Count; j++)
                {
                    if (Convert.ToInt32(rdr["KategoriID"]) == Convert.ToInt32(DropDownList1.Items[j].Value))
                    {
                        DropDownList1.SelectedIndex = j;
                    }
                }

                Image1.ImageUrl = "../dinamikimg/Urunler/mini/" + rdr["Resim1"].ToString();
                HiddenField1.Value = rdr["Resim1"].ToString();


            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Ürün içeriği bulunamadı !</p></div>";
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
        if (FileUpload1.HasFile)
        {

            String extension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            if (System.Text.RegularExpressions.Regex.IsMatch(extension, ".png|.jpg|.jpeg|.pjpeg|.JPG|.JPEG|.PJPEG|.PNG"))
            {
                string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_").Replace(" ", "_").Replace("/", "_").Replace("\\", "_");

                Bitmap buyukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.YaziEkleVeOrantılıKaydet(buyukResim, 750, Server.MapPath("../dinamikimg/Urunler/" + filenameadd + FileUpload1.FileName), "Elegancegozluk.com");


                Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.OranlaveKaydet(kucukResim, 279, 180, Server.MapPath("../dinamikimg/Urunler/mini/" + filenameadd + FileUpload1.FileName));



                Guncelle(filenameadd + FileUpload1.FileName);
            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Yanlızca .jpg,.jpeg,.pjpeg uzantıları kabul edilir !</p></div>";
            }
        }
        else
        {
            Guncelle(HiddenField1.Value);
        }
    }



    public void Guncelle(string filename)
    {
       
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
                dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(Request.QueryString["id"])),
                dt.ParametreEkle("@pUrunAdi", SqlDbType.VarChar,txturunadi.Text),
                dt.ParametreEkle("@pUrunKodu", SqlDbType.VarChar,txturunkodu.Text),
                dt.ParametreEkle("@pOzet", SqlDbType.VarChar,txtozet.Text),
                dt.ParametreEkle("@pUrunOzellikleri", SqlDbType.VarChar,CKEditorControl1.Text),
                dt.ParametreEkle("@pFiyati", SqlDbType.VarChar,txtfiyat.Text),
                dt.ParametreEkle("@pResim1", SqlDbType.VarChar,filename),
                dt.ParametreEkle("@pKategoriID", SqlDbType.VarChar,DropDownList1.SelectedItem.Value),
                dt.ParametreEkle("@title", SqlDbType.VarChar, txttitle.Text ),
                dt.ParametreEkle("@descript", SqlDbType.VarChar, txtdesc.Text ),
                dt.ParametreEkle("@keys", SqlDbType.VarChar, txtkeys.Text ),
                };



            int i = dt.GetExecuteNonQuery("UPDATE Urunler SET UrunAdi=@pUrunAdi,UrunKodu=@pUrunKodu,UrunOzellikleri=@pUrunOzellikleri,UrunKisaAciklama=@pOzet,Fiyati=@pFiyati,Resim1=@pResim1,KategoriID=@pKategoriID, Title=@title, Description=@descript, Keyword=@keys WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Güncellenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Güncellendi !</p></div>";
                Response.Redirect("urunler.aspx", false);
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