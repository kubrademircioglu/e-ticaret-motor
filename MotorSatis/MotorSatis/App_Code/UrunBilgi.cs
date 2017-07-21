
/**
 * The Product class
 * 
 * This is just to simulate some way of accessing data about  our products
 */
using System.Data.SqlClient;
using System.Data;
using System;
using System.Configuration;
public class UrunBilgi
{

	public int Id { get; set; }
	public decimal Fiyat { get; set; }
	public string Tanim { get; set; }
    public string Resim { get; set; }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public UrunBilgi(int id)
	{
		


        //try
        //{
            dt.BaglantiAc();
            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };

            SqlDataReader rdr = dt.GetReader("Select * From Urunler where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                this.Id = id;
                this.Tanim = rdr["UrunAdi"].ToString();
                this.Fiyat = Convert.ToDecimal(rdr["Fiyati"]);
              
                this.Resim = rdr["Resim1"].ToString();
               

             
            }
            else
            {
                //Response.Redirect("Default.aspx", true);
            }

        //}
        //catch (Exception ex)
        //{
        //    //spnurunadi.InnerHtml = ex.Message;
        //}
        //finally
        //{
            dt.BaglantiKapat();
            // dt.Dispose();
        //}
	}

}
