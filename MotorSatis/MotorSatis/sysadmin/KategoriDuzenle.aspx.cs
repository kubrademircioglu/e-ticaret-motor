using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class sysadmin_KategoriDuzenle : System.Web.UI.Page
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

                Response.Redirect("Kategoriler.aspx", true);
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

            SqlDataReader rdr = dt.GetReader("Select * From Kategoriler where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                txtad.Text = rdr["Kategori"].ToString();
                CKEditorControl1.Text = rdr["Icerik"].ToString();
                txttitle.Text = rdr["Title"].ToString();
                txtdesc.Text = rdr["Description"].ToString();
                txtkeys.Text = rdr["Keyword"].ToString();

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
                dt.ParametreEkle("@Kategori", SqlDbType.VarChar,txtad.Text),
                dt.ParametreEkle("@icerik", SqlDbType.VarChar, CKEditorControl1.Text), 
                dt.ParametreEkle("@title", SqlDbType.VarChar, txttitle.Text ),
                dt.ParametreEkle("@descript", SqlDbType.VarChar, txtdesc.Text ),
                dt.ParametreEkle("@keys", SqlDbType.VarChar, txtkeys.Text )};



            int i = dt.GetExecuteNonQuery("UPDATE Kategoriler SET Kategori=@Kategori,Icerik=@icerik,Title=@title,Description=@descript,Keyword=@keys WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Güncellenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Güncellendi !</p></div>";
                Response.Redirect("Kategoriler.aspx", false);
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