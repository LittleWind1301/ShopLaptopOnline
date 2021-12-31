using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class FooterDao
    {
        private LaptopDBContext db = null;
        public FooterDao()
        {
            db = new LaptopDBContext();
        }

        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x=>x.Status == true);
        }
    }
}
