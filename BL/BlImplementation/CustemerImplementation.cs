using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace BlImplementation
{
    internal class CustemerImplementation : BlApi.ICustemer
    {
        private DalApi.IDal _dal = DalApi.Factory.Get;

        public int Create(BO.Custemer boCust)
        {
            try
            {
                DO.Custemer doCust = boCust.CopyToDO();

                int id = _dal.Custemer.Create(doCust);

                return id;
            }
            catch (BO.BlAlreadyExistsException ex) // אם ה-ID כבר קיים בנתונים
            {
                throw new BO.BlAlreadyExistsException($"Customer with ID {boCust.CustemerID} already exists", ex);
            }
        }
        public BO.Custemer? Read(int id)
        {
            try
            {
                DO.Custemer? doCust = _dal.Custemer.Read(id);

                if (doCust == null)
                {
                    throw new BO.BlDoesNotExistException($"Customer with ID {id} does not exist in the system.");
                }
                return doCust.CopyToBO();
            }
            catch (BO.BlDoesNotExistException ex) 
            {
                throw new BO.BlDoesNotExistException($"Customer with ID {id} was not found.", ex);
            }
        }
    }
}
