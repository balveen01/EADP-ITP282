using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Doosan.models
{
    public class CustOrderCart
    {
        public List<CustOrderCartItem> Items { get; private set; }

        //public static readonly ShoppingCart Instance;
        public static CustOrderCart Instance;

        // A Static Default ShoppingCart Constructor. Meaning developers need not use the New keyword.
        static CustOrderCart()
        {
            if (HttpContext.Current.Session["DoosanShoppingCart"] == null)
            {
                Instance = new CustOrderCart();
                Instance.Items = new List<CustOrderCartItem>();
                HttpContext.Current.Session["DoosanShoppingCart"] = Instance;
            }
            else
            {
                Instance = (CustOrderCart)HttpContext.Current.Session["CSharpShoppingCart"];
            }
        }

        // A Default ShoppingCart Constructor. 
        protected CustOrderCart() { }

        // Find a ShoppingCartItem inside the ShoppingCart Instance by providing a Product ID
        public CustOrderCartItem getAShopptingCartItem(string ProductID)
        {

            //ShoppingCartItem newItem = new ShoppingCartItem(ProductID, prod);

            if (!Items.Equals(null))
            {
                foreach (CustOrderCartItem item in Items)
                {
                    if (item.ItemID == ProductID)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        // Add a ShoppingCartItem into the ShoppingCart Instance by providing a Product ID and Product object
        public void AddItem(string ProductID, Product prod)
        {
            //ShoppingCartItem newItem = new ShoppingCartItem(ProductID);
            CustOrderCartItem newItem = new CustOrderCartItem(ProductID, prod);

            if (Items.Contains(newItem))
            {
                foreach (CustOrderCartItem item in Items)
                {
                    if (item.Equals(newItem))
                    {
                        item.Quantity++;
                        return;
                    }
                }
            }
            else
            {
                newItem.Quantity = 1;
                Items.Add(newItem);
            }
        }

        public void SetItemQuantity(string ProductID, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(ProductID);
                return;
            }

            CustOrderCartItem updatedItem = new CustOrderCartItem(ProductID);

            foreach (CustOrderCartItem Item in Items)
            {
                if (Item.Equals(updatedItem))
                {
                    Item.Quantity = quantity;
                    return;
                }
            }
        }

        // Remove a ShoppingCartItem from the ShoppingCart Instance by providing a Product ID 
        public void RemoveItem(string ProductID)
        {
            Items.Remove(CustOrderCart.Instance.getAShopptingCartItem(ProductID));
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (CustOrderCartItem item in Items)
            {
                subTotal += item.TotalPrice;
            }
            return subTotal;
        }

    }
}