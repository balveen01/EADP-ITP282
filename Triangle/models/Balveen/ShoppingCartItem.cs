using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Triangle.models;
using System.Text;
using Triangle.BLL;



//IEquatable - type-specific to determine the equality of Instances
public class ShoppingCartItem : IEquatable<ShoppingCartItem>
{
    public int Quantity { get; set; }

    private string _ItemID;
    public string ItemID
    {
        get { return _ItemID; }
        set { _ItemID = value; }
    }

    private string _ItemName;
    public string Product_Name
    {
        get { return _ItemName; }
        set { _ItemName = value; }
    }

    private byte[] _ItemImage;
    public byte[] Product_Image
    {
        get { return _ItemImage; }
        set { _ItemImage = value; }

    }

    private string _ItemDesc;
    public string Product_Desc
    {
        get { return _ItemDesc; }
        set { _ItemDesc = value; }

    }

    private decimal _ItemPrice;
    public decimal Product_Price
    {
        get { return _ItemPrice; }
        set { _ItemPrice = value; }
    }

    private string _Type;
    public string Type
    {
        get { return _Type; }
        set { _Type = value; }
    }

    public decimal TotalPrice
    {
        get { return Product_Price * Quantity; }
    }

    public ShoppingCartItem(string productID)
    {
        this.ItemID = productID;
    }

    public ShoppingCartItem(string productID, Product prod)
    {
        ProductCat myCat = new ProductCat();
        DataSet ds;
        ds = myCat.getProductDetails(int.Parse(productID));
        this.ItemID = productID;
        this.Product_Name = ds.Tables[0].Rows[0]["product_name"].ToString();
        this.Product_Desc = ds.Tables[0].Rows[0]["product_desc"].ToString();
        this.Product_Price = decimal.Parse(ds.Tables[0].Rows[0]["unit_price"].ToString());
        this.Product_Image = (byte[])ds.Tables[0].Rows[0]["product_image"];
        this.Type = "product";
        //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //this.Product_Image = Encoding.ASCII.GetBytes(ds.Tables[0].Rows[0]["product_image"].ToString());

    }

    public ShoppingCartItem(string bundleid, Product bund, decimal totalprice)
    {
        /*BundleCat myCat = new BundleCat();
        DataSet ds;
        ds = myCat.getBundleDetails(int.Parse(bundleid));
        this.ItemID = bundleid;
        this.Product_Desc = ds.Tables[0].Rows[0]["bundle_desc"].ToString();
        this.Product_Name = ds.Tables[0].Rows[0]["bundle_name"].ToString();
        //this.Product_Price = decimal.Parse(ds.Tables[0].Rows[0]["total_price"].ToString())
        this.Product_Image = (byte[])ds.Tables[0].Rows[0]["bundle_image"];z;
        */
        ProductCat myCat = new ProductCat();
        DataSet ds;
        ds = myCat.getProductDetails(int.Parse(bundleid));
        this.ItemID = bundleid;
        this.Product_Name = ds.Tables[0].Rows[0]["product_name"].ToString();
        this.Product_Desc = ds.Tables[0].Rows[0]["product_desc"].ToString();
        this.Product_Price = totalprice;
        this.Product_Image = (byte[])ds.Tables[0].Rows[0]["product_image"];
        this.Type = "bundle";
        //string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        //this.Product_Image = Encoding.ASCII.GetBytes(ds.Tables[0].Rows[0]["product_image"].ToString());

    }

    public ShoppingCartItem(string productID, string productName, string productDesc, decimal productPrice, string productImage)
    {
        ProductCat myCat = new ProductCat();
        DataSet ds;
        ds = myCat.getProductDetails(int.Parse(productID));
        this.ItemID = productID;
        this.Product_Name = ds.Tables[0].Rows[0]["product_name"].ToString();
        this.Product_Desc = ds.Tables[0].Rows[0]["product_desc"].ToString();
        this.Product_Price = decimal.Parse(ds.Tables[0].Rows[0]["unit_price"].ToString());
        this.Product_Image = (byte[])ds.Tables[0].Rows[0]["product_image"];
        //this.Product_Image = Encoding.ASCII.GetBytes(ds.Tables[0].Rows[0]["product_image"].ToString());

    }

    public bool Equals(ShoppingCartItem anItem)
    {
        return anItem.ItemID == this.ItemID;
    }

    //public bool Equals(ShoppingCartItem product)
    //{
    //    return product.ItemID == this.ItemID;
    //}

}