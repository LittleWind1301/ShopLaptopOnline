using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class OrderDetailDao
    {
        private LaptopDBContext db = null;
        public OrderDetailDao()
        {
            db = new LaptopDBContext();
        }

        public bool Insert(OrderDetail details)
        {
            try
            {
                db.OrderDetails.Add(details);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
