using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10._05._2018
{
     public class ItemToPurchase
    {
        public int ProductQuantity;
        private Product Product_;

        public ItemToPurchase(Product _product, int _quantity)
        {
            Product_ = _product;
            ProductQuantity = _quantity;
        }
        public Product Product
        {
            get { return Product_; }
            set { Product_ = value; }
        }
        public int ProductQuantity_
        {
            get { return ProductQuantity; }
            set { ProductQuantity = value; }
        }
    }
}

