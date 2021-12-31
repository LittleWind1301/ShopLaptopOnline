using ModelWeb.EF1;
using ModelWeb.ViewModel;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelWeb.Dao
{
    public class ProductDao
    {
        private LaptopDBContext db = null;
        public ProductDao()
        {
            db = new LaptopDBContext();
        }

        public IEnumerable<tProduct> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<tProduct> model = db.tProducts;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString));
            }
            
            return model.OrderBy(x => x.CreateDate).ToPagedList(page, pageSize);

            
        }

        public List<tProduct> ListNewProduct(int top)
        {
            return db.tProducts.OrderByDescending(x => x.CreateDate).Take(top).ToList();
        }

        public tProduct GetByID(long id)
        {
            return db.tProducts.Find(id);
        }
        public List<tProduct> ListRelatedProducts(long productID)
        {
            var product = db.tProducts.Find(productID);
            return db.tProducts.Where(x => x.ID != productID && x.CategoryID == product.CategoryID).ToList();
        }


        public long Insert(tProduct product)
        {
            try
            {
                var name = db.tProducts.SingleOrDefault(x => x.Name == product.Name);
                if (name != null)
                {
                    return 0;
                }
                else
                {
                    db.tProducts.Add(product);
                    db.SaveChanges();
                    return product.ID;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }

        public bool Update(tProduct product)
        {
            try
            {
                var model = db.tProducts.Find(product.ID);
                model.Name = product.Name;
                model.Description = product.Description;
                model.Image = product.Image;
                model.Price = product.Price;
                model.Quantity = product.Quantity;
                model.CategoryID = product.CategoryID;
                model.Detail = product.Detail;
                model.BaoHanh = product.BaoHanh;
                model.CreateDate = product.CreateDate;
                model.CreateBy = product.CreateBy;
                model.ModifiedBy = product.ModifiedBy;
                model.ModifiedDate = DateTime.Now;
                model.Status = product.Status;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                var product = db.tProducts.Find(id);
                db.tProducts.Remove(product);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Get list product by category
        /// </summary>
        /// <param name="categoryID"></param>
        /// <returns></returns>
        //public List<tProduct> ListByCategoryID(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 5)
        //{
        //    totalRecord = db.tProducts.Where(x => x.CategoryID == categoryID).Count();
        //    var model = db.tProducts.Where(x => x.CategoryID == categoryID).OrderByDescending(x=>x.CreateDate).Skip((pageSize-1)* pageIndex).Take(pageSize).ToList();
        //    return model;
        //}

        public List<ProductViewModel> ListByCategoryID(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 5)
        {
            totalRecord = db.tProducts.Where(x => x.CategoryID == categoryID).Count();
            var model = from a in db.tProducts
                        join b in db.CategoryProducts
                        on a.CategoryID equals b.ID
                        where a.CategoryID == categoryID
                        select new ProductViewModel()
                        {
                            CateMetaTile = b.MetaTittle,
                            CateName = b.Name,
                            CreateDate = a.CreateDate,
                            Id = a.ID,
                            Images = a.Image,
                            Name = a.Name,
                            Price = a.Price
                        };
            model.OrderByDescending(x => x.CreateDate).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
            return model.ToList();
        }
        


    }
}
