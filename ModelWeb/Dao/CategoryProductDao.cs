using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class CategoryProductDao
    {
        private LaptopDBContext db = null;
        public CategoryProductDao()
        {
            db = new LaptopDBContext();
        }
        public List<CategoryProduct> GetAllCategoryProduct()
        {
            return db.CategoryProducts.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
        public CategoryProduct ViewDetail(long id)
        {
            return db.CategoryProducts.Find(id);
        }
    }
}
