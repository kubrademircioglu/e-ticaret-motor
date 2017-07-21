using System.Collections.Generic;
using System.Web;

/**
 * The ShoppingCart class
 * 
 * Holds the items that are in the cart and provides methods for their manipulation
 */
public class Sepet
{
    #region Properties

    public List<Urun> Items { get; private set; }

    #endregion

    #region Singleton Implementation

    // Readonly properties can only be set in initialization or in a constructor
    public static readonly Sepet Instance;
    // The static constructor is called as soon as the class is loaded into memory
    static Sepet()
    {
        // If the cart is not in the session, create one and put it there
        // Otherwise, get it from the session
        if (HttpContext.Current.Session["Sepetim"] == null)
        {
            Instance = new Sepet();
            Instance.Items = new List<Urun>();
            HttpContext.Current.Session["Sepetim"] = Instance;
        }
        else
        {
            Instance = (Sepet)HttpContext.Current.Session["Sepetim"];
        }
    }

    // A protected constructor ensures that an object can't be created from outside
    protected Sepet() { }

    #endregion

    #region Item Modification Methods
    
    //Sepete Ekle metodu
    public void SepeteEkle(int urunId, int ilk_miktar)
    {
        // Sepet için yeni ürün belirle
        Urun newItem = new Urun(urunId);

        //Eğer daha önceden ekliyse miktarı arttır
        if (Items.Contains(newItem))
        {
            foreach (Urun item in Items)
            {
                if (item.Equals(newItem))
                {
                    item.Miktar++;
                    return;
                }
            }
        }
        else
        {
            //ilk kez eklendiyse miktarı gelen miktara eşitle
            newItem.Miktar = ilk_miktar;
            Items.Add(newItem);
        }
    }

    //Ürün miktarını güncelle
    public void MiktarGuncelle(int urunId, int miktar)
    {
        // eğer miktar 0 girildiyse ürünü sepetten sil
        if (miktar == 0)
        {
            SepettenSil(urunId);
            return;
        }

        //Güncellenecek ürünü bul
        Urun updatedItem = new Urun(urunId);

        foreach (Urun item in Items)
        {
            if (item.Equals(updatedItem))
            {
                item.Miktar = miktar;
                return;
            }
        }
    }

    //Sepetten ürün sil
    public void SepettenSil(int urunId)
    {
        Urun silinecekeleman = new Urun(urunId);
        Items.Remove(silinecekeleman);
    }
    #endregion

    #region Reporting Methods
    //Toplam tutar belirle
    public decimal ToplamTutar()
    {
        decimal toplam = 0;
        foreach (Urun item in Items)
            toplam += item.ToplamFiyat;

        return toplam;
    }

    //Toplam tutar belirle
    public decimal ToplamSepetMiktari()
    {
        int toplam = 0;
        foreach (Urun item in Items)
            toplam += item.Miktar;

        return toplam;
    }
    #endregion
}
