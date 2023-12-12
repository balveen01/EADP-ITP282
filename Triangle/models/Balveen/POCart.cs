using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class POCart
    {
        public List<POCartItem> Items { get; private set; }

        //public static readonly ShoppingCart Instance;
        public static POCart Instance;

        // A Static Default ShoppingCart Constructor. Meaning developers need not use the New keyword.
        static POCart()
        {
            if (HttpContext.Current.Session["CSharpShoppingCart"] == null)
            {
                Instance = new POCart();
                Instance.Items = new List<POCartItem>();
                HttpContext.Current.Session["CSharpShoppingCart"] = Instance;
            }
            else
            {
                Instance = (POCart)HttpContext.Current.Session["CSharpShoppingCart"];
            }
        }

        // A Default ShoppingCart Constructor. 
        protected POCart() { }

        // Find a ShoppingCartItem inside the ShoppingCart Instance by providing a Product ID
        public POCartItem getAShopptingCartItem(string ProductID)
        {

            //ShoppingCartItem newItem = new ShoppingCartItem(ProductID, prod);

            if (!Items.Equals(null))
            {
                foreach (POCartItem item in Items)
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
            POCartItem newItem = new POCartItem(ProductID, prod);

            if (Items.Contains(newItem))
            {
                foreach (POCartItem item in Items)
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
        public void AddBundle(string bundleid, Product bund, decimal totalprice)
        {
            //ShoppingCartItem newItem = new ShoppingCartItem(ProductID);
            POCartItem newItem = new POCartItem(bundleid, bund, totalprice);

            if (Items.Contains(newItem))
            {
                foreach (POCartItem item in Items)
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

            POCartItem updatedItem = new POCartItem(ProductID);

            foreach (POCartItem Item in Items)
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
            Items.Remove(POCart.Instance.getAShopptingCartItem(ProductID));
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (POCartItem item in Items)
            {
                subTotal += item.TotalPrice;
            }
            return subTotal;
        }



    }
}