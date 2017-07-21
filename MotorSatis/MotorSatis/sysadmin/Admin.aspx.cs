using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class sysadmin_Admin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
      
        if (!IsPostBack)
            Getir();
    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public void Getir()
    {
        try
        {
            notify.InnerHtml = "";

            dt.BaglantiAc();
            DataSet ds = new DataSet();
            ds = dt.GetDataSet("SELECT * FROM AdminUsers", null);

            DropDownList1.DataValueField = "ID";
            DropDownList1.DataTextField = "UserName";
            DropDownList1.DataSource = ds;
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "Seçiniz");
        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@admin", SqlDbType.VarChar,txtuser.Text),
            dt.ParametreEkle("@pass", SqlDbType.VarChar,txtsifre.Text)};

            int i = dt.GetExecuteNonQuery("INSERT INTO AdminUsers(UserName,Pass) VALUES(@admin,@pass)", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Eklenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Eklendi !</p></div>";
                Response.Redirect("admin.aspx", false);
            }
        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
        }

    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (DropDownList1.SelectedValue == "Seçiniz")
            {
                notify.InnerHtml = "Kullanıcı seçiniz";
                txtadminguncelle.Text = "";
                txtsifreguncelle.Text = "";
                return;
            }

            notify.InnerHtml = "";
            dt.BaglantiAc();
            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DropDownList1.SelectedValue))};

            SqlDataReader rdr = dt.GetReader("Select * From AdminUsers where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();
                txtadminguncelle.Text = rdr["UserName"].ToString();
                txtsifreguncelle.Text = rdr["Pass"].ToString();
            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Kullanıcı bulunamadı !</p></div>";
            }

        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        try
        {
            notify.InnerHtml = "";

            dt.BaglantiAc();
            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DropDownList1.SelectedValue)),
            dt.ParametreEkle("@adm", SqlDbType.VarChar,txtadminguncelle.Text),
            dt.ParametreEkle("@pwd", SqlDbType.VarChar,txtsifreguncelle.Text)};

            int i = dt.GetExecuteNonQuery("UPDATE AdminUsers SET UserName=@adm, Pass=@pwd WHERE ID=@id", prms);

            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Düzenlememedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Düzenlendi !</p></div>";
            }
        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
        }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
            dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(DropDownList1.SelectedValue))};

            int i = dt.GetExecuteNonQuery("DELETE FROM AdminUsers WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Silinemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Silindi !</p></div>";
                Response.Redirect("admin.aspx", false);
            }
        }
        catch (Exception ex)
        {
            notify.InnerHtml = "<div class='message errormsg'><p>" + ex.Message + "</p></div>";
        }
        finally
        {
            dt.BaglantiKapat();
        }
    }
    protected void txtsifre_TextChanged(object sender, EventArgs e)
    {

    }
}