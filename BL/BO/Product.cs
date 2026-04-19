using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Product
    {
        public int ProductId;
        public string ProductName;
        public Category Category;
        public double Price;
        public int AmountProduct;
        //public List<s> Products;

        public Product(int ProductId, string ProductName, Category Category, double Price, int AmountProduct)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Price = Price;
            this.AmountProduct = AmountProduct;
        }
        public Product() { }

        public override string ToString() => this.ToStringProperty();
    }
}
