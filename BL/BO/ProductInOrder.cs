using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class ProductInOrder
    {
        public int Id;
        public string NameProduct;
        public double BasePrice;
        public int Amount;
        public List<SaleInProduct> ListSale= new List<SaleInProduct>();
        public double EndPriceProduct;

        public ProductInOrder(int Id, string NameProduct, double BasePrice, int Amount, double EndPriceProduct)
        { 
            this.Id = Id;
            this.NameProduct = NameProduct;
            this.BasePrice = BasePrice;
            this.Amount = Amount;
            this.EndPriceProduct = EndPriceProduct;
        }

    }
}
