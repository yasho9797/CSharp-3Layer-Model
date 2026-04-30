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
        // הוספת get ו-set לכל השדות כדי שהטבלה תוכל להציג אותם
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public int AmountProduct { get; set; }

        // בנאי עם פרמטרים
        public Product(int ProductId, string ProductName, Category Category, double Price, int AmountProduct)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Category = Category;
            this.Price = Price;
            this.AmountProduct = AmountProduct;
        }

        // בנאי ריק
        public Product() { }

        public override string ToString() => this.ToStringProperty();
    }
}