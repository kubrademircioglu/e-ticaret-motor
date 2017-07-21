using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

public partial class sysadmin_urunResimleri : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            DetayResimGetir(Convert.ToInt32(Request.QueryString["id"].ToString()));
        }
        catch
        {

            Response.Redirect("urunler.aspx", true);
        }
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void DetayResimGetir(int id)
    {
        lblbos.Text = "";
        try
        {

            DataSet ds = new DataSet();

            SqlParameter[] prms = {dt.ParametreEkle("@id",SqlDbType.Int, id)};

            ds = dt.GetDataSet("SELECT * FROM ExtraUrunResimleri where UrunID =@id", prms);

            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblbos.Text = "Bu ürün için kayıt yok.";
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.InnerException + ex.StackTrace);
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

                int i = dt.GetExecuteNonQuery("DELETE FROM ExtraUrunResimleri WHERE ID=@id", prms);
                if (i == 0)
                {
                    lblbos.Text = "Silinemedi ! Lütfen veritabanı durumunu kontrol edin.";
                }
                else
                {
                    lblbos.Text = "Silindi !";

                    string resim = ((HiddenField)DataList1.Items[e.Item.ItemIndex].FindControl("hdresim")).Value;

                    if (File.Exists(Server.MapPath("../dinamikimg/ExtraUrunler/") + resim))
                        File.Delete(Server.MapPath("../dinamikimg/ExtraUrunler/") + resim);

                    if (File.Exists(Server.MapPath("../dinamikimg/ExtraUrunler/mini/") + resim))
                        File.Delete(Server.MapPath("../dinamikimg/ExtraUrunler/mini/") + resim);

                    Response.Redirect("urunler.aspx", false);
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
            Response.Redirect("urunResimleriDuzenle.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString());
        }
    }
}