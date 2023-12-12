using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triangle.models
{
    public class ConsumerShoppingCart
    {
        public List<ConsumerShoppingCartItems> Items { get; private set; }

        public static ConsumerShoppingCart Instance;

        protected ConsumerShoppingCart() { }

        static ConsumerShoppingCart()
        {
            if (HttpContext.Current.Session["ConsumerCart"] == null)
            {
                Instance = new ConsumerShoppingCart();
                Instance.Items = new List<ConsumerShoppingCartItems>();
                HttpContext.Current.Session["ConsumerCart"] = Instance;
            }
            else
            {
                Instance = (ConsumerShoppingCart)HttpContext.Current.Session["ConsumerCart"];
            }
        }


        public ConsumerShoppingCartItems getAShopptingCartItem(string ItemID)
        {
            if (!Items.Equals(null))
            {
                foreach (ConsumerShoppingCartItems item in Items)
                {
                    if (item.ItemID == ItemID)
                    {
                        return item;
                    }
                }
            }
            return null;
        }

        public void AddItem(string productID, string productName, decimal productPrice, int quantity)
        {
            ConsumerShoppingCartItems newItem = new ConsumerShoppingCartItems(productID, productName, productPrice, quantity);

            if (Items.Contains(newItem))
            {
                foreach (ConsumerShoppingCartItems item in Items)
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

        public void SetItemQuantity(string ItemID, int quantity)
        {
            if (quantity == 0)
            {
                RemoveItem(ItemID);
                return;
            }

            ConsumerShoppingCartItems updatedItem = new ConsumerShoppingCartItems(ItemID);

            foreach (ConsumerShoppingCartItems Item in Items)
            {
                if (Item.Equals(updatedItem))
                {
                    Item.Quantity = quantity;
                    return;
                }
            }
        }

        public void RemoveItem(string ItemID)
        {
            Items.Remove(ConsumerShoppingCart.Instance.getAShopptingCartItem(ItemID));
        }

        public decimal GetSubTotal()
        {
            decimal subTotal = 0;
            foreach (ConsumerShoppingCartItems item in Items)
            {
                subTotal += item.Price;
            }
            return subTotal;
        }
    }

    public class ConsumerShoppingCartItems : IEquatable<ConsumerShoppingCartItems>
    {
        public int Quantity { get; set; }

        private string _ItemID;
        private Product _product;
        private string _name;
        private decimal _price;
        private int _quantity;

        public string ItemID
        {
            get { return _ItemID; }
            set { _ItemID = value; }
        }
        public string ProductName
        {
            get { return _name; }
            set { _name = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public int ProdQuantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public ConsumerShoppingCartItems(string productID)
        {
            this.ItemID = productID;
        }

        public ConsumerShoppingCartItems(string productID, string productName, decimal productPrice, int quantity)
        {
            ItemID = productID;
            _name = productName;
            _price = productPrice;
            _quantity = quantity;
        }

        public bool Equals(ConsumerShoppingCartItems anItem)
        {
            return anItem.ItemID == this.ItemID;
        }

        public ConsumerShoppingCartItems() { }

    }
}