using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class _Default : System.Web.UI.Page
{
    private void slidedoldur()
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM Sliders ORDER BY listesirasi";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rptsliders.DataSource = dt;
        rptsliders.DataBind();
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Session["Kategorid"] = null;
        Session["menuid"] = null;
        slidedoldur();
    }
}