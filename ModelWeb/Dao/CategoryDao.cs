using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class CategoryDao
    {
        private LaptopDBContext db = null;
        public CategoryDao()
        {
            db = new LaptopDBContext();
        }

        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public CategoryProduct Detail(long id)
        {
            return db.CategoryProducts.Find(id);
        }
    }
}
