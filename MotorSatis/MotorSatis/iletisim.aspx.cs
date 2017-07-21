using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class iletisim : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand("insert into mesajlar (adsoyad,email,telefon,mesaj) values (@adsoyad,@email,@tel,@mesaj)", con);
        cmd.Parameters.AddWithValue("@adsoyad", txtad.Text);
        cmd.Parameters.AddWithValue("@email", txtmail.Text);
        cmd.Parameters.AddWithValue("@tel", txttel.Text);
        cmd.Parameters.AddWithValue("@mesaj", txtmesaj.Text);
        cmd.ExecuteNonQuery();
        Label1.Visible = true;
        Label1.Text = "Mesajınız Başarıyla Gönderildi";
        con.Close();
    }
}