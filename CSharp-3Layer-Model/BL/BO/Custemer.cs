using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Custemer
    {
        public int? CustemerID;
        public string CustemerName;
        public string Adress;
        public int? Phone;


        public Custemer(int CustemerID, string CustemerName, string Adress, int Phone)
        {
            this.CustemerID = CustemerID;
            this.CustemerName= CustemerName;
            this.Adress = Adress;
            this.Phone = Phone;
        }
        public Custemer() { }
        public override string ToString() => this.ToStringProperty();
    }
}
