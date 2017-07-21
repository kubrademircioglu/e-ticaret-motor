using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class sysadmin_Kategoriler : System.Web.UI.Page
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
            ds = dt.GetDataSet("SELECT * FROM Kategoriler where Main=0 ORDER BY listesirasi", null);

            DataList1.DataSource = ds;
            DataList1.DataBind();

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

    protected void DataList1_ItemCommand1(object source, DataListCommandEventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString()))};

            int i = dt.GetExecuteNonQuery("DELETE FROM Kategoriler WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Silinemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";

            }
            else
            {

                notify.InnerHtml = "<div class='message success'><p>Silindi !</p></div>";
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