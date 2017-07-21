using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for ContentReader
/// </summary>
public class ContentReader
{
    public ContentReader()
    {
        //
        // TODO: Add constructor logic here
        //
    }

   

    public static string KategoriOku(int Kategori, out string categoryname, out string titles, out string descript, out string keys)
    {
        string contentpage = "";
        string CateName = "";
        string PageTitle = "";
        string PageDesc = "";
        string PageKeys = "";

        DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
        dt.BaglantiAc();
        SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, Kategori) };
        SqlDataReader rdr = dt.GetReader("Select * From Kategoriler where ID=@id", prms);
        if (rdr.HasRows)
        {
            rdr.Read();
            contentpage = rdr["Icerik"].ToString();
            CateName = rdr["Kategori"].ToString();
            PageTitle = rdr["Title"].ToString();
            PageDesc = rdr["Description"].ToString();
            PageKeys = rdr["Keyword"].ToString();
        }
        else
        {
            contentpage = "İçerik Bulunamadı !";
            CateName = "er@ygozluk.com";
            PageTitle = "er@ygozluk.com | Gözlük, lens, bay gözlük , bayan gözlük, çocuk gözlük";
            PageDesc = "er@ygozluk.com | Gözlük, lens, bay gözlük , bayan gözlük, çocuk gözlük";
            PageKeys = "er@ygozluk.com | Gözlük, lens, bay gözlük , bayan gözlük, çocuk gözlük";
        }
        dt.BaglantiKapat();
        dt.Dispose();

        titles = PageTitle;
        descript = PageDesc;
        keys = PageKeys;
        categoryname = CateName;
        return contentpage;
    }


}