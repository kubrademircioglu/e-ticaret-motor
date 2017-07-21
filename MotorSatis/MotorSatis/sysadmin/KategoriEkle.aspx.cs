using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

public partial class sysadmin_KategoriEkle : System.Web.UI.Page
{
    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    protected void Button1_Click(object sender, EventArgs e)
    {

        try
        {

            dt.BaglantiAc();
            SqlParameter[] prms = { 
                dt.ParametreEkle("@Kategori", SqlDbType.VarChar,txtad.Text),
                dt.ParametreEkle("@main", SqlDbType.Int,0),
                dt.ParametreEkle("@alt", SqlDbType.Int,0),
                dt.ParametreEkle("@pIcerik", SqlDbType.VarChar, CKEditorControl1.Text), 
                dt.ParametreEkle("@pTitle", SqlDbType.VarChar, txttitle.Text ),
                dt.ParametreEkle("@pDescription", SqlDbType.VarChar, txtdesc.Text ),
                dt.ParametreEkle("@pKeyword", SqlDbType.VarChar, txtkeys.Text )};


            int i = dt.GetExecuteNonQuery("INSERT INTO Kategoriler(Kategori,Main,Alt,Icerik,Title,Description,Keyword) VALUES(@Kategori,@main,@alt,@pIcerik,@pTitle,@pDescription,@pKeyword)", prms);
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

}