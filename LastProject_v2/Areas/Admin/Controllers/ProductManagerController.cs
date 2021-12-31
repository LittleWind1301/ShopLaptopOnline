using ModelWeb.Dao;
using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
namespace LastProject_v2.Areas.Admin.Controllers
{
    public class ProductManagerController : BaseController
    {
        LaptopDBContext db = new LaptopDBContext();
        // GET: Admin/ProductManager
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging( searchString, page, pageSize);
            ViewBag.searchString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.HangSX = new SelectList(db.CategoryProducts.ToList(), "ID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Create(tProduct product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    SetAlert("Thêm sản phẩm thành công", "success");
                    return RedirectToAction("Index", "ProductManager");
                }
                else
                {
                    SetAlert("Tên sản phẩm đã tồn tại!!!", "error");
                    return View("Create");
                }
            }
            return View("Index");
        }

        public ActionResult Edit(long id)
        {
            ViewBag.HangSX = new SelectList(db.CategoryProducts.ToList(), "ID", "Name");
            var product = new ProductDao().GetByID(id);
            return View(product);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(tProduct product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    SetAlert("cập nhật sản phẩm thành công", "success");
                    return RedirectToAction("Index", "ProductManager");
                }
                else
                {
                    SetAlert("Thất bại!!!", "error");
                    return View("Edit");
                }
            }
            return View("Index");
        }

        [HttpDelete]
        public ActionResult Delete(long id)
        {
            var res = new ProductDao().Delete(id);
            if (res)
            {
                SetAlert("Xóa sản phẩm thành công", "success");
            }
           
            return RedirectToAction("Index");
        }
    }
}