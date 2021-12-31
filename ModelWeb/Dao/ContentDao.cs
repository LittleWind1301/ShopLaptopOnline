using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class ContentDao
    {
        private LaptopDBContext db = null;
        public ContentDao()
        {
            db = new LaptopDBContext();
        }

        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
    }
}
