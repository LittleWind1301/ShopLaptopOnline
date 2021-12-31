using ModelWeb.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LastProject_v2.Areas.Admin.Controllers
{
    public class CartManagerController : Controller
    {
        // GET: Admin/Cart
        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            var dao = new OrderDao();
            var model = dao.ListAll(searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }

        public ActionResult ViewDetail(long id)
        {
            var dao = new OrderDao();
            var model = dao.ListViewCart(id);
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var res = new OrderDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}