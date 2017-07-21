using System;
using System.Data;
using System.Data.SqlClient;
using System.Web;

public class DataAccess : IDisposable
{

    private string m_ConStr;// Connection string değişkeni tanımla


    private SqlConnection con = null;// SqlConnection veri kaynağına bağlantı hattını yapacak olan nesne.

    /// <summary>
    /// Yapıcı metod bir string parametresi alır. Bu parametre SQL bağlantısı için bağlantı cümlesidir.
    /// </summary>
    /// <param name="sConStr"></param>
    public DataAccess(string sConStr)
    {
        this.strConnection = sConStr;
    }

    /// <summary>
    /// Sınıfa ait strConnection özelliği ile m_ConStr değişkeni atanıyor ve bağlantı yaratılıyor.
    /// </summary>
    public string strConnection
    {
        get
        {
            return m_ConStr;
        }

        set
        {
            m_ConStr = value;
            try
            {
                this.con = new SqlConnection(value);// SqlConnection bağlantı nesnesi yarat
            }
            catch
            {
                throw;
            }
        }
    }

    /// <summary>
    /// SQL sunucuyla olan bağlantı açılır.
    /// </summary>
    public void BaglantiAc()
    {
        try
        {
            if (con.State != ConnectionState.Open)// Eğer bağlantı açık değilse
                con.Open(); // Bağlantıyı aç
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// SQL sunucuyla olan bağlantı kapatılır.
    /// </summary>
    public void BaglantiKapat()
    {
        try
        {
            if (con != null)
                con.Close(); // Bağlantıyı kapat
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    ///  Kaynakları serbest bırak.
    /// </summary>
    public void Dispose()
    {
        if (con != null)
        {
            con.Dispose();// Bağlantı nesnesinin serbest bırakılması
            con = null;
        }
    }

    /// <summary>
    /// Parametre eklemek içindir. SqlParameter nesnesi döner.
    /// </summary>
    /// <param name="pAdi">Parametre adı</param>
    /// <param name="DbType">Parametrenin SqlDbType özelliği</param>
    /// <param name="pDeger">Parametrenin değeri</param>
    /// <returns></returns>
    public SqlParameter ParametreEkle(string pAdi, SqlDbType DbType, object pDeger)
    {
        SqlParameter param = new SqlParameter(pAdi, DbType);// SqlParameter nesnesi tanımla
        param.Value = pDeger;// Parametere değerini ver
        return param;
    }

    /// <summary>
    /// GetCommand metodu için bir sorgu ve parametreler girilir. Geriye SqlCommand nesnesi döndürür.
    /// </summary>
    /// <param name="sorgu">Sql sorgusu</param>
    /// <param name="prms">Parametreler</param>
    /// <returns></returns>
    public SqlCommand GetCommand(string sorgu, SqlParameter[] prms)
    {
        using (SqlCommand cmd = new SqlCommand(sorgu, con))// SqlCommand nesnemizi oluşturuyoruz.
        {
            return cmd; // SqlCommand nesnesini döndür.
        }
    }

    /// <summary>
    /// GetScalarCommand metodu bir Stored procedure çalıştırır ve geriye bir tamsayı değer döndürür.
    /// </summary>
    /// <param name="sorgu">Sql Sorgusu</param>
    /// <param name="prms">Parametreler</param>
    /// <param name="sRetValParam">RETURN ile değer döndüren parametremizin adı.</param>
    /// <returns></returns>
    public int GetScalarCommand(string sorgu, SqlParameter[] prms)
    {
        SqlCommand cmd = GetCommand(sorgu, prms);// SqlCommand nesnesini hazırla.
        if (prms != null)// Parametre varsa SqlCommand parametrelerine ekle.
        {
            foreach (SqlParameter parameter in prms)//Parametreleri ekle.
                cmd.Parameters.Add(parameter);
        }
        BaglantiAc();// Bağlantımızı açıyoruz.
        int donendeger = Convert.ToInt32(cmd.ExecuteScalar());// Komutumuz tek bir değer döndüreceğinden ExecuteScalar metodu ile çalıştırıyoruz.
        BaglantiKapat();// Bağlantımızı kapatıyoruz.

        return donendeger;
    }

    /// <summary>
    /// GetExecuteNonQuery sorgu ve parametreler ile ExecuteNonWuery metodunu çağırır ve geriye int tipinde sonucu döner.
    /// </summary>
    /// <param name="sorgu">Sql Sorgusu</param>
    /// <param name="prms">Parametreler</param>
    /// <returns></returns>
    public int GetExecuteNonQuery(string sorgu, SqlParameter[] prms)
    {
        SqlCommand cmd = GetCommand(sorgu, prms);// SqlCommand nesnesini hazırla.
        if (prms != null)// Parametre varsa SqlCommand parametrelerine ekle.
        {
            foreach (SqlParameter parameter in prms)//Parametreleri ekle.
                cmd.Parameters.Add(parameter);
        }

        int donendeger = Convert.ToInt32(cmd.ExecuteNonQuery());// Komutumuz tek bir değer döndüreceğinden ExecuteScalar metodu ile çalıştırıyoruz.
        cmd.Parameters.Clear();
        return donendeger;
    }

    /// <summary>
    /// GetDataSet metodu sql sorgusu çalıştırlması sonucunda, dataset içini doldurur ve bu nesneyi geriye gönderir.
    /// </summary>
    /// <param name="sorgu">Sql sorgusu</param>
    /// <param name="prms"></param>
    /// <returns></returns>
    public DataSet GetDataSet(string sorgu, SqlParameter[] prms)
    {
        DataSet ds = new DataSet(); // DataSet nesnesini oluştur.
        try
        {
            BaglantiAc();// Bağlantımızı açıyoruz.
            SqlCommand cmd = GetCommand(sorgu, prms);// SqlCommand nesnesini hazırla.

            if (prms != null)// Parametre varsa SqlCommand parametrelerine ekle.
            {
                foreach (SqlParameter parameter in prms)
                    cmd.Parameters.Add(parameter);
            }

            SqlDataAdapter myAdptr = new SqlDataAdapter();// SqlDataAdapter nesnesini oluştur.
            myAdptr.SelectCommand = cmd;// objCmd nesnesini işaret et.
            myAdptr.Fill(ds, "myTable");// myAdptr oluşturduğumuz DataSet nesnesini doldurur.
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiKapat(); // Bağlantımızı kapatıyoruz.
        }

        return ds;
    }

    /// <summary>
    /// GetDataSet metodu sql sorgusu çalıştırlması sonucunda, dataset içini doldurur ve bu nesneyi geriye gönderir. 
    /// </summary>
    /// <param name="sorgu">Sql sorgusu</param>
    /// <param name="prms"></param>
    /// <returns>DataSet</returns>
    public DataSet GetDataSetWithPaging(string sorgu, int baslangicKaydi, int sayfadakiKayitSirasi, string tableName, SqlParameter[] prms)
    {
        DataSet ds = new DataSet(); // DataSet nesnesini oluştur.
        try
        {
            BaglantiAc();// Bağlantımızı açıyoruz.
            SqlCommand cmd = GetCommand(sorgu, prms);// SqlCommand nesnesini hazırla.

            if (prms != null)// Parametre varsa SqlCommand parametrelerine ekle.
            {
                foreach (SqlParameter parameter in prms)
                    cmd.Parameters.Add(parameter);
            }

            SqlDataAdapter myAdptr = new SqlDataAdapter();// SqlDataAdapter nesnesini oluştur.
            myAdptr.SelectCommand = cmd;// objCmd nesnesini işaret et.
            myAdptr.Fill(ds, baslangicKaydi, sayfadakiKayitSirasi, tableName);// myAdptr oluşturduğumuz DataSet nesnesini doldurur.
        }
        catch
        {
            throw;
        }
        finally
        {
            BaglantiKapat(); // Bağlantımızı kapatıyoruz.
        }

        return ds;
    }


    /// <summary>
    /// SqlDataReader geriye döner.
    /// </summary>
    /// <param name="spName">Sp Adı</param>
    /// <param name="parameters">Sp Parametreleri</param>
    /// <returns>SqlDataReader</returns>
    public SqlDataReader GetReader(string sorgu, SqlParameter[] prms)
    {
        SqlCommand cmd = GetCommand(sorgu, prms);// SqlCommand nesnesini hazırla.

        if (prms != null)
        {
            for (int i = 0; i < prms.Length; i++)
            {
                cmd.Parameters.Add(prms[i]);
            }
        }

        SqlDataReader rdr = cmd.ExecuteReader();// SqlDataAdapter nesnesini oluştur.
        return rdr;
    }


    /*
     * KULLANIM
     * 
   DATASET DOLDUR
   --parametresiz
   DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["Connect"]);
   DataSet ds = new DataSet();
   ds = dt.GetDataSet("SELECT * FROM Personeller", null);//parametre yok ise null
   DataList1.DataSource = ds;
   DataList1.DataBind();
   dt.Dispose();
   
   --parametreli
   DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["Connect"]);
   DataSet ds = new DataSet();
   SqlParameter[] prms = { dt.ParametreEkle("@tip", SqlDbType.VarChar, wr) };
   ds = dt.GetDataSet("SELECT * FROM Icerikler WHERE SayfaTip=@tip", prms);
   DataList1.DataSource = ds;
   DataList1.DataBind();
   
     
   
   
   DATAREADER ÇALIŞTIR
   DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["Connect"]);
   dt.BaglantiAc();
   SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.VarChar, drppersonel.SelectedValue) };//parametre yok ise GetReader metodunun ikinci parametresi null geçilir
   SqlDataReader rdr = dt.GetReader("Select * From Personeller where ID=@id", prms);
   if (rdr.HasRows)
   {
   rdr.Read();
   txtad.Text = rdr["AdSoyad"].ToString();
   }
   else
   {
    //kayıt yok kodları
   }
   dt.BaglantiKapat();
   dt.Dispose();
   
   
   
   EXECUTENONQUERY ÇALIŞTIR
   DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["Connect"]);
   dt.BaglantiAc();
   SqlParameter[] prms = {dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(drppersonel.SelectedValue))};//parametre yok ise GetExecuteNonQuery metodunun ikinci parametresi null geçilir
   int i = dt.GetExecuteNonQuery("Update - Insert - Delete işlemleri", prms);
   if (i == 0)
   {
   notify.InnerHtml = "Düzenlememedi ! Lütfen veritabanı durumunu kontrol edin.";
   }
   else
   {
   notify.InnerHtml = "Düzenlendi !";
   }
   dt.BaglantiKapat();
   dt.Dispose();
   
   
   
   PARAMETRE EKLE
   SqlParameter[] prms = {dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(drppersonel.SelectedValue))};//İlk parametre sqlparametrenin adı, ikincisi dbtype, üçüncüsü sqlparametrenin değeridir.
   
   
   
   BAĞLANTI TANIMLA
   DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["Connect"]);
   
    */

}