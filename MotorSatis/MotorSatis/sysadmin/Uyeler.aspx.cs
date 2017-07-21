using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class sysadmin_Uyeler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            Uyeler();
        }

    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void Uyeler()
    {
        try
        {
            DataSet ds = new DataSet();
            ds = dt.GetDataSet("SELECT * FROM Uyeler ORDER BY ID", null);

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

    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DataList1.DataKeys[e.Item.ItemIndex].ToString()))};

            int i = dt.GetExecuteNonQuery("DELETE FROM Uyeler WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Silinemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";

            }
            else
            {

                notify.InnerHtml = "<div class='message success'><p>Silindi !</p></div>";
                Response.Redirect("Uyeler.aspx", false);
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