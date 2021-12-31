using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.ViewModel
{
    public class ProductViewModel
    {
        public long Id { get; set; }

        public string Images { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string CateName { get; set; }
        public string CateMetaTile { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
