using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class ara : System.Web.UI.Page
{
    private void Ara()
    {
        if (Request.QueryString["key"] != null)
        {
            string key = Request.QueryString["key"].ToString();
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where u.UrunAdi like '%" + key + "%'  or u.UrunKisaAciklama like '%" + key + "%'  or u.UrunOzellikleri like '%" + key + "%'";
            cmd.ExecuteNonQuery();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            rpturunler.DataSource = dt;
            rpturunler.DataBind();
            con.Close();
        }
    }
    private void Ara1()
    {
        int? menu = null;
        int? kategori = null;
        string key = TextBox1.Text;
        try
        {
            menu = Convert.ToInt32(DropDownList1.SelectedValue);
        }
        catch
        {
            menu = null;
        }
        try
        {
            kategori = Convert.ToInt32(DropDownList2.SelectedValue);
        }
        catch
        {
            kategori = null;
        }

        if (!string.IsNullOrEmpty(key))
        {
            key = TextBox1.Text;
        }
        else
        {
            key = null;
        }
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        if (key != null)
        {
            cmd.CommandText = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where u.UrunAdi like '%" + key + "%'  or u.UrunKisaAciklama like '%" + key + "%'  or u.UrunOzellikleri like '%" + key + "%' and u.Menuid='" + menu + "' and u.KategoriID='" + kategori + "'  ";

        }
        else
        {
            cmd.CommandText = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where u.Menuid=" + menu + " and u.KategoriID=" + kategori;

        }
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rpturunler.DataSource = dt;
        rpturunler.DataBind();
        con.Close();
    }

    private void Ara2()
    {
        int menu = Convert.ToInt32(DropDownList1.SelectedValue);
        int kategori = Convert.ToInt32(DropDownList2.SelectedValue);
        SqlConnection con = new SqlConnection();
        con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT u.ID,u.UrunAdi,u.Resim1,u.UrunKisaAciklama,u.Fiyati,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where u.Menuid='" + menu + "' and u.KategoriID='" + kategori + "'  ";
        cmd.ExecuteNonQuery();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataTable dt = new DataTable();
        da.Fill(dt);
        rpturunler.DataSource = dt;
        rpturunler.DataBind();
        con.Close();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.AppSettings["ConnectToTheDantelEvim"];
            con.Open();
            SqlCommand cmd = new SqlCommand("select menu,id from menuler", con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                DropDownList1.Items.Add(new ListItem(dr["menu"].ToString(), dr["id"].ToString()));
            }
            con.Close();
            con.Open();
            SqlCommand cmd2 = new SqlCommand("select Kategori,ID from Kategoriler", con);
            SqlDataReader dr2 = cmd2.ExecuteReader();
            while (dr2.Read())
            {
                DropDownList2.Items.Add(new ListItem(dr2["Kategori"].ToString(), dr2["ID"].ToString()));
            }
            con.Close();

            Session["Kategorid"] = null;
            Session["menuid"] = null;
            Ara();
        }


    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Ara1();

    }
}