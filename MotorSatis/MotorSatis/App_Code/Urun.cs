using System;

/**
 * The CartItem Class
 * 
 * Basically a structure for holding item data
 */
public class Urun : IEquatable<Urun> {
	#region Properties

	// A place to store the quantity in the cart
	// This property has an implicit getter and setter.
	public int Miktar { get; set; }

	private int _urunId;
	public int UrunId {
        get { return _urunId; }
		set {
			// To ensure that the Prod object will be re-created
            _urun = null;
            _urunId = value;
		}
	}

	private UrunBilgi _urun = null;
    public UrunBilgi Prod
    {
		get {
			// Lazy initialization - the object won't be created until it is needed
            if (_urun == null)
            {
                _urun = new UrunBilgi(UrunId);
			}
            return _urun;
		}
	}

	public string Tanim {
		get { return Prod.Tanim; }
	}

	public decimal BirimFiyat {
		get { return Prod.Fiyat; }
	}

	public decimal ToplamFiyat {
        get { return BirimFiyat * Miktar; }
	}

    public string Resim
    {
        get { return Prod.Resim; }
    }

	#endregion

	// CartItem constructor just needs a productId
    public Urun(int urunId)
    {
        this.UrunId = urunId;
	}

	/**
	 * Equals() - Needed to implement the IEquatable interface
	 *    Tests whether or not this item is equal to the parameter
	 *    This method is called by the Contains() method in the List class
	 *    We used this Contains() method in the ShoppingCart AddItem() method
	 */
    public bool Equals(Urun item)
    {
        return item.UrunId == this.UrunId;
	}
}
