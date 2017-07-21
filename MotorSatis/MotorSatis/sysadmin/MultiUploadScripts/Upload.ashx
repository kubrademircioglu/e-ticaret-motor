<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Data.SqlClient;
using System.Web.SessionState;

public class Upload : IHttpHandler, IRequiresSessionState
{

    public void ProcessRequest(HttpContext context)
    {
        DataAccess dt = new DataAccess(System.Configuration.ConfigurationManager.AppSettings["ConnectToTheDantelEvim"]);
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string id = context.Request["id"];

            //tempPath = context.Request["folder"];

            //If you prefer to use web.config for folder path, uncomment below line:
            //tempPath = System.Configuration.ConfigurationManager.AppSettings["FolderPath"]; 


            //savepath = context.Server.MapPath(tempPath);
            //string filename = postedFile.FileName;
            //if (!Directory.Exists(savepath))
            //Directory.CreateDirectory(savepath);
            if (System.IO.Path.GetExtension(postedFile.FileName) == ".jpg" || System.IO.Path.GetExtension(postedFile.FileName) == ".jpeg")
            {
                string filenameadd = DateTime.Now.ToString().Replace(" ", "_").Replace(":", "_").Replace(".", "_");

                System.Drawing.Bitmap buyukResim = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(postedFile.InputStream));
                Global.OranlaveKaydet(buyukResim, 50, 50, context.Server.MapPath("../../dinamikimg/Resimler/mini/" + filenameadd + postedFile.FileName));

                System.Drawing.Bitmap kucukResim = new System.Drawing.Bitmap(System.Drawing.Image.FromStream(postedFile.InputStream));
                Global.OrantiliKaydet(kucukResim, 714, context.Server.MapPath("../../dinamikimg/Resimler/" + filenameadd + postedFile.FileName));

                string[] gelen = context.Request.QueryString["kid"].ToString().Split('_');

                dt.BaglantiAc();

                SqlParameter[] prms = { 
                dt.ParametreEkle("@id", System.Data.SqlDbType.Int,Convert.ToInt32(gelen[0])),
                dt.ParametreEkle("@bann", System.Data.SqlDbType.VarChar,filenameadd + postedFile.FileName)};


                int i = dt.GetExecuteNonQuery("INSERT INTO Resimler(KategoriID,Resim) VALUES(@id,@bann)", prms);

            }

            //postedFile.SaveAs(savepath + @"\" + resimGuid  + ext);
            context.Response.Write("_");
            context.Response.StatusCode = 200;

        }
        catch (Exception ex)
        {
            context.Session["sonuc"] = ex.Message;
            dt.BaglantiKapat();

        }



    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}