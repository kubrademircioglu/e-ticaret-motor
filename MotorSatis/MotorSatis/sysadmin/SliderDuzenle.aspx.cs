﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Drawing;

public partial class sysadmin_SliderDuzenle : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

     if (!IsPostBack)
        {
            try
            {
                getir(Convert.ToInt32(Request.QueryString["id"]));
            }
            catch
            {

                Response.Redirect("Slider.aspx", true);
            }
        }

    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    protected void getir(int id)
    {
        try
        {
            notify.InnerHtml = "";


            dt.BaglantiAc();
            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };

            SqlDataReader rdr = dt.GetReader("Select * From Sliders where ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();


                Image1.ImageUrl = "../dinamikimg/Sliders/" + rdr["Slider"].ToString();
                HiddenField1.Value = rdr["Slider"].ToString();
                txtlink.Text = rdr["Link"].ToString();

            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Marka içeriği bulunamadı !</p></div>";
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

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_");

            String extension = System.IO.Path.GetExtension(this.FileUpload1.PostedFile.FileName);
            if (System.Text.RegularExpressions.Regex.IsMatch(extension, ".png|.jpg|.jpeg|.pjpeg|.PNG|.JPG|.JPEG|.PJPEG"))
            {

                Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
                Global.OranlaveKaydet(kucukResim, 710, 495, Server.MapPath("../dinamikimg/Sliders/" + filenameadd + FileUpload1.FileName));


                Guncelle(filenameadd + FileUpload1.FileName);
            }
            else
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Yanlızca .jpg,.jpeg,.pjpeg uzantıları kabul edilir !</p></div>";
            }
        }
        else
        {
            Guncelle(HiddenField1.Value);
        }
    }

   
    public void Guncelle(string filename)
    {
        
        try
        {
            dt.BaglantiAc();

            SqlParameter[] prms = { 
                dt.ParametreEkle("@id", SqlDbType.Int,Convert.ToInt32(Request.QueryString["id"])),
                dt.ParametreEkle("@bann", SqlDbType.VarChar,filename),
                dt.ParametreEkle("@plink", SqlDbType.VarChar,txtlink.Text)};

            int i = dt.GetExecuteNonQuery("UPDATE Sliders SET Slider=@bann,Link=@plink WHERE ID=@id", prms);
            if (i == 0)
            {
                notify.InnerHtml = "<div class='message errormsg'><p>Güncellenemedi ! Lütfen veritabanı durumunu kontrol edin.</p></div>";
            }
            else
            {
                notify.InnerHtml = "<div class='message success'><p>Güncellendi !</p></div>";
                Response.Redirect("Slider.aspx", false);
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