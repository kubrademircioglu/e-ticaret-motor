using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text.RegularExpressions;
using System.Drawing.Drawing2D;
using System.Net.Mail;

/// <summary>
/// Summary description for PartvendoGlobal
/// </summary>
public class Global
{
    public Global()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    //Kullanımı
    //Bitmap kucukResim = new Bitmap(System.Drawing.Image.FromStream(FileUpload1.PostedFile.InputStream));
    //Global.OranlaveKaydet(kucukResim, 950, 315, Server.MapPath("../dinamikimg/Sliders/" + filenameadd + FileUpload1.FileName));
    public static void OranlaveKaydet(Bitmap resim, int genislik, int yukseklik, string kayitYol) // burada resim değişkeni dikkatinizi çektiği üzere Bitmap objesi yani metodumuza Bitmap göndereceğiz, dönüştürme ise istediğimiz dönüştürme oranı oluyor
    {
        Bitmap oranlanacak = resim;

        using (Bitmap Orjinal = resim)
        {
            Size yenidegerler = new Size(genislik, yukseklik);
            Bitmap yeniresim = new Bitmap(Orjinal, yenidegerler);
            oranlanacak = yeniresim;
        }

        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
        Encoder myEncoder = Encoder.Quality;
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 85L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        oranlanacak.Save(kayitYol, myImageCodecInfo, myEncoderParameters);
    }

    public static void OrantiliKaydet(Bitmap resim, int genislik, string kayitYol) // burada resim değişkeni dikkatinizi çektiği üzere Bitmap objesi yani metodumuza Bitmap göndereceğiz, dönüştürme ise istediğimiz dönüştürme oranı oluyor
    {
        Bitmap oranlanacak = resim;


        double ResimYukseklik = resim.Height; //resmin yüksekliğini alıyor
        double ResimUzunluk = resim.Width; //resmin genişliğini alıyor
        double sabit = genislik; // resmimizi 350px genişliğinde sabitliyoruz
        double oran = 0;

        if (ResimUzunluk > sabit)
        {
            oran = ResimUzunluk / ResimYukseklik;
            ResimUzunluk = sabit;
            ResimYukseklik = sabit / oran;

        }

        Bitmap yeniresim = new Bitmap(oranlanacak, Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));


        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
        Encoder myEncoder = Encoder.Quality;
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 85L);
        myEncoderParameters.Param[0] = myEncoderParameter;
        yeniresim.Save(kayitYol, myImageCodecInfo, myEncoderParameters);
    }


    public static void YaziEkleVeOrantılıKaydet(Bitmap resim, int genislik, string kayitYol, string yazi) // burada resim değişkeni dikkatinizi çektiği üzere Bitmap objesi yani metodumuza Bitmap göndereceğiz, dönüştürme ise istediğimiz dönüştürme oranı oluyor
    {
        Bitmap oranlanacak = resim;


        double ResimYukseklik = resim.Height; //resmin yüksekliğini alıyor
        double ResimUzunluk = resim.Width; //resmin genişliğini alıyor
        double sabit = genislik; // resmimizi 350px genişliğinde sabitliyoruz
        double oran = 0;

        if (ResimUzunluk > sabit)
        {
            oran = ResimUzunluk / ResimYukseklik;
            ResimUzunluk = sabit;
            ResimYukseklik = sabit / oran;

        }

        Bitmap yeniresim = new Bitmap(oranlanacak, Convert.ToInt32(ResimUzunluk), Convert.ToInt32(ResimYukseklik));

        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/jpeg");
        Encoder myEncoder = Encoder.Quality;
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 85L);
        myEncoderParameters.Param[0] = myEncoderParameter;


        Bitmap bmp = yeniresim;
        Graphics g = Graphics.FromImage(bmp);
        Brush seffaflik = new SolidBrush(Color.FromArgb(80, Color.Red)); //Yazı Şeffaflığı ayarlandı
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.DrawString(yazi, new Font("Trebuchet MS", 17, FontStyle.Bold), seffaflik, new Point(Convert.ToInt32(yeniresim.Width * 0.60), Convert.ToInt32(yeniresim.Height * 0.90)));

        bmp.Save(kayitYol, myImageCodecInfo, myEncoderParameters);


    }


    private static ImageCodecInfo GetEncoderInfo(String mimeType)
    {
        int j;
        ImageCodecInfo[] encoders;
        encoders = ImageCodecInfo.GetImageEncoders();
        for (j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
                return encoders[j];
        }
        return null;
    }
}