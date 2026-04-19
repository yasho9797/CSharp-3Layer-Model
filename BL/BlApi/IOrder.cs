using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlApi
{
    public interface IOrder
    {
        int Create(BO.Order item);
       BO.Order? Read(int id);
        BO.Order? Read(Func<BO.Order, bool>? filter = null);
        List<BO.Order?> ReadAll(Func<BO.Order, bool>? filter = null);
        void Update(BO.Order item);
        void Delete(int id);
        bool IsExist(int id);
    }
}
