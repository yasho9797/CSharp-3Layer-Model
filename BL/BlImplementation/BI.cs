using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlApi;

namespace BlImplementation
{
    internal class BI : IBI
    {
        public IProduct Product => new ProductImplementation();
        public ICustemer Custemer => new CustemerImplementation();
        public ISale Sale => new SaleImplementation();
        public IOrder Order => new OrderImplementation();

    }
}
