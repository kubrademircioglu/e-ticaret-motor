using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class urun : System.Web.UI.Page
{
    private void UrunGetir(int? kategoriId, int? menuid)
    {
        string sorgu = string.Empty;
        if (menuid != null)
            sorgu = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where  u.Menuid= " + menuid;

        if (kategoriId != null)
            sorgu = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where  u.KategoriID=" + kategoriId ;
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = sorgu;
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rpturunler.DataSource = dt;
        rpturunler.DataBind();
        con.Close();


    }

    protected void Page_Load(object sender, EventArgs e)
    {
        int? kategoriid = null;
        int? menuid = null;
        if (Request.QueryString["kategoriid"] != null)
        {
            kategoriid =Convert.ToInt32( Request.QueryString["kategoriid"]);
        }
        if (Request.QueryString["menuid"] != null)
        {
            menuid = Convert.ToInt32(Request.QueryString["menuid"]);
        }

        UrunGetir(kategoriid, menuid);
    }
}