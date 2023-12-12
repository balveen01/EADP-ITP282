using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class CustOrderCartItem
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


        private decimal _ItemPrice;
        public decimal Product_Price
        {
            get { return _ItemPrice; }
            set { _ItemPrice = value; }
        }

        public decimal TotalPrice
        {
            get { return Product_Price * Quantity; }
        }

        private string _ItemDesc;
        public string Product_Desc
        {
            get { return _ItemDesc; }
            set { _ItemDesc = value; }

        }
        public decimal TotalItem
        {
            get { return Product_Price * Quantity; }
        }

        public CustOrderCartItem(string productID)
        {
            this.ItemID = productID;
        }

        public CustOrderCartItem(string productID, Product prod)
        {
            this.ItemID = productID;
            this.Product_Name = prod.product_name;
            this.Product_Desc = prod.product_desc;
            this.Product_Price = prod.unit_price;
            this.Product_Image = prod.product_image;

        }

        public CustOrderCartItem(string productID, string productName, string productDesc, decimal productPrice, byte[] productImage)
        {
            this.ItemID = productID;
            this.Product_Name = productName;
            this.Product_Desc = productDesc;
            this.Product_Price = productPrice;
            this.Product_Image = productImage;

        }

        public bool Equals(CustOrderCartItem anItem)
        {
            return anItem.ItemID == this.ItemID;
        }

        //public bool Equals(ShoppingCartItem product)
        //{
        //    return product.ItemID == this.ItemID;
        //}
    }
}