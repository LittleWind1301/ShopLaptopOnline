
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelWeb.EF1;

namespace ModelWeb.Dao
{
    public class SlideDao
    {
        private LaptopDBContext db = null;
        public SlideDao()
        {
            db = new LaptopDBContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y=>y.DisplayOrder).ToList();
        }
    }
}
