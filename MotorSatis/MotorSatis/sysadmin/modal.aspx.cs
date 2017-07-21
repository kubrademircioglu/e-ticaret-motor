using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class sysadmin_modal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Request.QueryString["id"] != null)
        {
            SepetDetay(Convert.ToInt32(Request.QueryString["id"].ToString()));
        }
        else
        {
            Response.Write("Kayıt yok");
        }
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void SepetDetay(int ID)
    {
        try
        {

            DataSet ds = new DataSet();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int ,Convert.ToInt32(ID))};
            ds = dt.GetDataSet("Select * From SepetDetay where SepetID=@id", prms);

            DataList2.DataSource = ds.Tables[0].DefaultView;
            DataList2.DataBind();

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message + ex.InnerException + ex.StackTrace);
        }
        finally
        {
            dt.Dispose();
        }
    }
}