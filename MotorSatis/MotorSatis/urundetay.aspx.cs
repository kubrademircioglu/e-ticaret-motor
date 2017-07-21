using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class urundetay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                if (Request.QueryString["uID"] != null)
                {
                    getir(Convert.ToInt32(Request.QueryString["uID"]));
                    UrunResimleriAl(Convert.ToInt32(Request.QueryString["uID"]));

                }
                else
                {
                    Response.Redirect("Default.aspx", true);
                }
            }
            catch
            {

                Response.Redirect("Default.aspx", true);
            }
        }

    }

    DataAccess dt = new DataAccess(ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
    public string resimAdi = "";
    public string urunAdi = "";
    public string urunID = "";
    protected void getir(int id)
    {
        try
        {
            dt.BaglantiAc();
            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };

            SqlDataReader rdr = dt.GetReader("SELECT u.ID,u.UrunAdi,u.UrunKodu,u.Resim1,u.UrunKisaAciklama,u.UrunOzellikleri,u.Fiyati,u.Keyword,u.Description,u.Title,k.ID as KatID,k.Kategori FROM Urunler u join Kategoriler k on u.KategoriID=k.ID where u.ID=@id", prms);
            if (rdr.HasRows)
            {
                rdr.Read();

                urunID = rdr["ID"].ToString();
                hdID.Value = urunID;
                urunAdi = rdr["UrunAdi"].ToString();
                spnurunadi.InnerHtml = rdr["UrunAdi"].ToString();
                spnfiyat.InnerHtml = rdr["Fiyati"].ToString() + " TL";
                divkisa.InnerHtml = rdr["UrunKisaAciklama"].ToString().Replace("\n", "<br />"); ;

                resimAdi = rdr["Resim1"].ToString();
                divhakkinda.InnerHtml = rdr["UrunOzellikleri"].ToString();


                HtmlMeta Meta = new HtmlMeta();
                Meta.Attributes.Add("name", "keywords");
                Meta.Attributes.Add("content", rdr["Keyword"].ToString());
                Header.Controls.Add(Meta);
                Page.Header.Controls.Add(new LiteralControl("\n"));

                Meta = new HtmlMeta();
                Meta.Attributes.Add("name", "description");
                Meta.Attributes.Add("content", rdr["Description"].ToString());
                Header.Controls.Add(Meta);
                Page.Header.Controls.Add(new LiteralControl("\n"));



                Page.Title = rdr["Title"].ToString();
            }
            else
            {
                Response.Redirect("Default.aspx", true);
            }

        }
        catch (Exception ex)
        {
            spnurunadi.InnerHtml = ex.Message;
        }
        finally
        {
            dt.BaglantiKapat();
            // dt.Dispose();
        }
    }

    public void UrunResimleriAl(int id)
    {
        try
        {
            DataSet ds = new DataSet();

            SqlParameter[] prms = { dt.ParametreEkle("@id", SqlDbType.Int, id) };
            ds = dt.GetDataSet("SELECT * FROM Resimler where KategoriID=@id", prms);

            rptextra.DataSource = ds;
            rptextra.DataBind();


        }
        catch (Exception ex)
        {
            spnurunadi.InnerHtml = ex.Message;
        }
        finally
        {
            dt.BaglantiKapat();

        }
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (quantity76.Text != null && System.Text.RegularExpressions.Regex.IsMatch(quantity76.Text, "\\d+"))
        {
            try
            {
                if (Convert.ToInt32(quantity76.Text) >= 1 && Convert.ToInt32(quantity76.Text) <= 99)
                {
                    Sepet.Instance.SepeteEkle(Convert.ToInt32(hdID.Value), Convert.ToInt32(quantity76.Text));
                }
                else
                {
                    Sepet.Instance.SepeteEkle(Convert.ToInt32(hdID.Value), 5);
                }
            }
            catch
            {

                Sepet.Instance.SepeteEkle(Convert.ToInt32(hdID.Value), 5);
            }

        }
        else
        {
            Sepet.Instance.SepeteEkle(Convert.ToInt32(hdID.Value), 5);

        }
        Response.Redirect("sepet.aspx");
    }
    public void arttir()
    {
        quantity76.Text = (Convert.ToInt32(quantity76.Text) + 1).ToString();
    }
}