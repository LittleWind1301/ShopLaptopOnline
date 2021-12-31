using LastProject_v2.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ModelWeb.EF1;
using ModelWeb.Dao;

namespace LastProject_v2.Areas.Admin.Models
{
    public class ManagerController : BaseController
    {
        // GET: Admin/Default
        public ActionResult Index()
        {
            return View();
        }

        
    }
}