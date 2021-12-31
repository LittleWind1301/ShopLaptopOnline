using LastProject_v2.Common;
using LastProject_v2.Models;
using ModelWeb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastProject_v2.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index(string searchString)
        {
            ViewBag.Slides  = new SlideDao().ListAll();
            var productDao = new ProductDao();
            ViewBag.NewProducts = productDao.ListNewProduct(searchString, 8);
            ViewBag.searchString = searchString;
            return View();
        }
        public PartialViewResult Slider()
        {
            ViewBag.Slides = new SlideDao().ListAll();
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult MainMenu()
        {
            var model = new MenuDao().ListByGroupId(1);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult TopMenu()
        {
            var model = new MenuDao().ListByGroupId(2);
            return PartialView(model);
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            var model = new FooterDao().GetFooter();
            return PartialView(model);
        }

        [ChildActionOnly]
        public PartialViewResult HeaderCart()
        {
            var cart = Session[CommonConstants.CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return PartialView(list);
        }

        public PartialViewResult Filler()
        {

            return PartialView();
        }
        public ActionResult FillterProduct(string searchString, int page = 1, int pageSize = 8)
        {
            ViewBag.Slides = new SlideDao().ListAll();
            var dao = new ProductDao();
            var model = dao.ListBySearch(searchString, page, pageSize);
            return View(model);
        }


    }
}