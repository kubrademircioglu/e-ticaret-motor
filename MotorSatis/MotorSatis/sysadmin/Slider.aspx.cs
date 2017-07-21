using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class sysadmin_Slider : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            BannerGetir();
        }
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void BannerGetir()
    {
        lblbos.Text = "";
        try
        {

            DataSet ds = new DataSet();

            ds = dt.GetDataSet("SELECT * FROM Sliders order by listesirasi", null);

            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                lblbos.Text = "Bu arşivde henüz kayıt yok.";
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

                int i = dt.GetExecuteNonQuery("DELETE FROM Sliders WHERE ID=@id", prms);
                if (i == 0)
                {
                    lblbos.Text = "Silinemedi ! Lütfen veritabanı durumunu kontrol edin.";
                }
                else
                {
                    lblbos.Text = "Silindi !";

                    string resim = ((HiddenField)DataList1.Items[e.Item.ItemIndex].FindControl("hdresim")).Value;

                    if (File.Exists(Server.MapPath("../dinamikimg/Sliders/") + resim))
                        File.Delete(Server.MapPath("../dinamikimg/Sliders/") + resim);

                    Response.Redirect("Slider.aspx", false);
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
            Response.Redirect("SliderDuzenle.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString());
        }
    }
}