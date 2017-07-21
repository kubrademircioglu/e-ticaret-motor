using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class sysadmin_urunler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Kategoriler();
        }

    }
    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void Kategoriler()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = dt.GetDataSet("select * from Kategoriler", null);

            drpkat.DataTextField = "Kategori";
            drpkat.DataValueField = "ID";

            drpkat.DataSource = ds;
            drpkat.DataBind();

            drpkat.Items.Insert(0, "Seçiniz");
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

    public void UrunGetir(string katID)
    {
        lblbos.Text = "";
        try
        {

            DataSet ds = new DataSet();

            SqlParameter[] prms = { 
                dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(katID))};



            ds = dt.GetDataSet("SELECT ID,UrunAdi,Resim1 FROM Urunler where KategoriID=@id", prms);


            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblbos.Text = "Bu arşivde henüz kayıt yok.";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            //dt.Dispose();
        }
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (e.CommandName == "sil")
        {
            try
            {
                dt.BaglantiAc();

                SqlParameter[] prms = { 
                dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex]))};

                int i = dt.GetExecuteNonQuery("DELETE FROM Urunler WHERE ID=@id", prms);
                if (i == 0)
                {
                    lblbos.Text = "Silinemedi ! Lütfen veritabanı durumunu kontrol edin.";
                }
                else
                {
                    lblbos.Text = "Silindi !";

                    string resim = ((HiddenField)DataList1.Items[e.Item.ItemIndex].FindControl("hdresim")).Value;

                    if (File.Exists(Server.MapPath("../dinamikimg/Urunler/") + resim))
                        File.Delete(Server.MapPath("../dinamikimg/Urunler/") + resim);

                    if (File.Exists(Server.MapPath("../dinamikimg/Urunler/mini/") + resim))
                        File.Delete(Server.MapPath("../dinamikimg/Urunler/mini/") + resim);


                    UrunGetir(drpkat.SelectedItem.Value);

                    //Response.Redirect("urunler.aspx", false);
                }
            }
            catch (Exception ex)
            {
                lblbos.Text = "Hata : " + ex.Message;
            }
            finally
            {
                dt.BaglantiKapat();
                dt.Dispose();
            }
        }
        else
        {
            Response.Redirect("urunduzenle.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString());
        }
    }
    protected void drpkat_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (drpkat.SelectedIndex == 0)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>Kategori seçiniz !</p></div>";
            Panel1.Visible = false;
            return;
        }

        UrunGetir(drpkat.SelectedItem.Value);
    }
}