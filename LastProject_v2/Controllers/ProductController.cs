using ModelWeb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastProject_v2.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult CategoryProduct()
        {
            var model = new CategoryProductDao().GetAllCategoryProduct();
            return PartialView(model);
        }

        //public ActionResult Category(long id, int page =1, int pageSize = 4)
        //{
        //    var category = new CategoryDao().Detail(id);
        //    ViewBag.Category = category;
        //    int totalRecord = 0;
        //    var model = new ProductDao().ListByCategoryID(id, ref totalRecord, page, pageSize);

        //    ViewBag.Total = totalRecord;
        //    ViewBag.Page = page;

        //    int maxPage = 5;
        //    int totalPage = 0;
        //    totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
        //    ViewBag.TotalPage = totalPage;

        //    ViewBag.MaxPage = maxPage;
        //    ViewBag.First = 1;
        //    ViewBag.Last = totalPage;
        //    ViewBag.Next = page + 1;
        //    ViewBag.Prev = page - 1;
        //    return View(model);
        //}
        public ActionResult Category(long id, int page = 1, int pageSize = 4)
        {
            var category = new CategoryDao().Detail(id);
            ViewBag.Category = category;
            int totalRecord = 0;
            var model = new ProductDao().ListByCategoryID(id, ref totalRecord, page, pageSize);

            ViewBag.Total = totalRecord;
            ViewBag.Page = page;

            int maxPage = 5;
            int totalPage = 0;
            totalPage = (int)Math.Ceiling((double)(totalRecord / pageSize));
            ViewBag.TotalPage = totalPage;

            ViewBag.MaxPage = maxPage;
            ViewBag.First = 1;
            ViewBag.Last = totalPage;
            ViewBag.Next = page + 1;
            ViewBag.Prev = page - 1;
            return View(model);
        }
        public ActionResult Detail(long id)
        {
            var product = new ProductDao().GetByID(id);
            ViewBag.Category = new CategoryProductDao().ViewDetail(product.CategoryID.Value);
            ViewBag.RelatedProducts = new ProductDao().ListRelatedProducts(id);
            return View(product);
        }
    }
}