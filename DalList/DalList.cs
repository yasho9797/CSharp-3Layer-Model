using DO;
using DalApi;

namespace Dal
{
    internal sealed class DalList : IDal
    {
        public ICustemer Custemer => new CustemerImplementation();
        public IProduct Product => new ProductImplementation();
        public ISale Sale => new SaleImplementation();

        private static readonly DalList instance = new DalList();
        private DalList() { }

        public static DalList Instance
        {
            get { return instance; }
        }




    }
}
