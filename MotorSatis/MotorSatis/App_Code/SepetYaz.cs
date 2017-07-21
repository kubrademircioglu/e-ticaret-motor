using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

/// <summary>
/// Summary description for SepetYaz
/// </summary>
public class SepetYaz
{
    public SepetYaz()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    int max_Satis_ID = 0;
    string donecekMesaj = "";
    string ipAdres = "";
    SqlConnection cn = new SqlConnection(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public string OdemeBitir(string kullaniciAdi, string odemetip, string durum, string OdemeAlindimi, string kargo,int kullaniciid)
    {
        try
        {
            cn.Open();
            try
            {

                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    ipAdres = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
                {
                    ipAdres = HttpContext.Current.Request.UserHostAddress;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Sepet (KullaniciAdi,SepetTutar,OdemeTip,IP,durum,odemealindi,kargo,kullaniciid) VALUES (@user,@tutar,@odemetip,@ip,@durum,@alindi,@kargo,@kullaniciid); select @@identity;", cn);
                cmd.Parameters.Add("@user", SqlDbType.VarChar).Value = kullaniciAdi;
                cmd.Parameters.Add("@tutar", SqlDbType.Decimal).Value = Sepet.Instance.ToplamTutar();
                cmd.Parameters.Add("@odemetip", SqlDbType.VarChar).Value = odemetip;
                cmd.Parameters.Add("@ip", SqlDbType.VarChar).Value = ipAdres;
                cmd.Parameters.Add("@durum", SqlDbType.VarChar).Value = durum;
                cmd.Parameters.Add("@alindi", SqlDbType.VarChar).Value = OdemeAlindimi;
                cmd.Parameters.Add("@kargo", SqlDbType.VarChar).Value = kargo;
                cmd.Parameters.Add("@kullaniciid", SqlDbType.Int).Value = kullaniciid;

                max_Satis_ID = Convert.ToInt32(cmd.ExecuteScalar());
                cmd.Dispose();


                foreach (Urun urunler in Sepet.Instance.Items)
                {

                    cmd = new SqlCommand("INSERT INTO SepetDetay (SepetID,UrunAdi,BirimFiyat,miktar,Tutar,urunid) VALUES(@sepetno,@urunAd,@birimFiyat,@miktar,@urunToplamTutar,@urunid)", cn);
                    cmd.Parameters.Add("@sepetno", SqlDbType.Int).Value = max_Satis_ID;
                    cmd.Parameters.Add("@urunAd", SqlDbType.VarChar).Value = urunler.Tanim;
                    cmd.Parameters.Add("@birimFiyat", SqlDbType.Decimal).Value = Convert.ToDecimal(urunler.BirimFiyat);
                    cmd.Parameters.Add("@urunToplamTutar", SqlDbType.Decimal).Value = Convert.ToDecimal(urunler.ToplamFiyat);
                    cmd.Parameters.Add("@miktar", SqlDbType.Int).Value = urunler.Miktar;
                    cmd.Parameters.Add("@urunid", SqlDbType.Int).Value = urunler.UrunId;
                    cmd.ExecuteNonQuery();
                   // cmd.Dispose();
                }
                //if (odemetip != "Havale")
                //{
                //    donecekMesaj = "<br/>Alışverişlerinizde bizi tercih ettiğiniz için teşekkür ederiz." + max_Satis_ID + " numaralı siparişiniz alınmıştır, en kısa sürede kargoya verilecektir.<br/><br/>Ortalama 1 saat içinde 'Sipariş Takibi' sayfanıza aktarılacak bilgi yardımıyla <br/>siparişinizi online olarak takip edebilirsiniz.";
                //}
                //else
                //{
                donecekMesaj = "<br/>Alışverişlerinizde bizi tercih ettiğiniz için teşekkür ederiz. " + max_Satis_ID + " numaralı siparişiniz alınmıştır, ödeme gerçekleştiğinde ürünleriniz en kısa sürede kargoya verilecektir.<br/><br/>Hesap numaralarımıza ödemeyi yaptıktan sonra lütfen Müşteri Hizmetleri menüsünden 'Bildirim Formunu' doldurunuz.<br/><br/>Ortalama 1 saat içinde 'Sipariş Takibi' sayfanıza aktarılacak bilgi yardımıyla <br/>siparişinizi online olarak takip edebilirsiniz.";
                //}
            }
            catch (Exception ex)
            {
                donecekMesaj = ex.Message;

            }
            finally
            {
                cn.Close();
            }
        }
        catch (Exception ex)
        {
            donecekMesaj = ex.Message;
        }

        Sepet.Instance.Items.Clear();
        return donecekMesaj;
    }

}