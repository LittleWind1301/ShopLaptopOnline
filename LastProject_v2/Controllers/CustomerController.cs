using ModelWeb.EF1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LastProject_v2.Areas.Admin.Models;
using Facebook;
using System.Configuration;
using ModelWeb.Dao;

namespace LastProject_v2.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        LaptopDBContext db = new LaptopDBContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var checkLog = db.Users.SingleOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);
                if (checkLog != null)
                {
                    Session["Name"] = model.UserName.ToString();
                    Session["UserName"] = model.UserName;
                    Session["CustomerId"] = checkLog.ID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không chính xác");
                    return View("DangNhap");
                }
            }
            return View();
        }

        public ActionResult Dangky()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Dangky(User model)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(x => x.UserName == model.UserName))
                {
                    ViewBag.ThongBao = "Tên tài khoản đã tồn tại!!!";
                    ModelState.AddModelError("", "Tên tài khoản đã tồn tại!!!");
                    return View("DangKy");
                }
                else
                {
                    db.Users.Add(model);
                    db.SaveChanges();

                
                    return RedirectToAction("DangNhap", "Customer");
                }
            }
            return View();
        }

        public ActionResult DangXuat()
        {
            Session.Clear();
            return RedirectToAction("DangNhap", "Customer");
        }

        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email"
            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
         {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=first_name, middle_name, last_name, id, email");
                string email = me.email;
                string userName = me.email;
                string firstName = me.first_name;
                string lastName = me.last_name;
                string middleName = me.middle_name;

                var user = new User();
                user.Email = email;
                user.UserName = email;
                user.Status = false;
                user.Name = firstName + " " + middleName + " " + lastName;
                user.CreateDate = DateTime.Now;
                user.Password = "000";
                var res = new UserDao().InsertForFB(user);
                if(res >= 0)
                {
                    Session["Name"] = user.UserName.ToString();
                    Session["UserName"] = user.UserName;
                    Session["CustomerId"] = user.ID;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không chính xác");
                    return View("DangNhap");
                }
            }
            return View();
        }
    }
}