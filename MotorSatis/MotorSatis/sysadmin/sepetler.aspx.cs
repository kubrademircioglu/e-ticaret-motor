using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Xml;

public partial class sysadmin_sepetler : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            TextBox1.Text = DateTime.Now.ToShortDateString();
            Sepetler("Tarih");



        }
    }
    
    public void Sepetler(string param)
    {
        DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
        notify.InnerHtml = "";
        try
        {

            DataSet ds = new DataSet();

            if (param == "All")
            {
                ds = dt.GetDataSet("Select * From Sepet  order by ID DESC", null);
            }
            else
            {
                SqlParameter[] prms = { 
                dt.ParametreEkle("@date", SqlDbType.DateTime,Convert.ToDateTime(TextBox1.Text))};
                //"Select * From Sepet where convert(varchar, Tarih, 104)=@date order by ID DESC
                ds = dt.GetDataSet("Select * From Sepet where Tarih=@date order by ID DESC", prms);
            }


            DataList1.DataSource = ds.Tables[0].DefaultView;
            DataList1.DataBind();

            if (ds.Tables[0].Rows.Count == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Kayıt yok.</p></div>";
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

        Response.Redirect("sepetduzenle.aspx?id=" + DataList1.DataKeys[e.Item.ItemIndex].ToString() + "&odeme=" + ((Label)DataList1.Items[e.Item.ItemIndex].FindControl("Label5")).Text, false);

    }
    protected void LinkButton4_Click(object sender, EventArgs e)
    {
        Sepetler("All");
    }
    protected void LinkButton3_Click(object sender, EventArgs e)
    {
        Sepetler("Tarih");
    }

}