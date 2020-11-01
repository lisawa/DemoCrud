using DemoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCrud.Controllers
{
    public class HomeController : Controller
    {
        private UserDataService service;

        public HomeController()
        {
            service = new UserDataService();
        }

        public ActionResult Index()
        {
            var result = service.GetAllData();

            return View(result);
        }

        public ActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Insert(string name, int age, string city)
        {
            service.CreateUserData(new UserDataModel()
            {
                name = name,
                age = age,
                city = city
            });

            return Json(new { isSuccess = true }); ;
        }

        [HttpPost]
        public ActionResult Delete(string pk)
        {
            service.DeleteUserData(pk);

            return Json(new { isSuccess = true }); ;
        }

        public ActionResult Update(string pk)
        {
            var result = service.GetDataByPK(pk);

            return View(result);
        }

        [HttpPost]
        public ActionResult Update(UserDataModel user)
        {
            service.UpdateUserData(user);

            return Json(new { isSuccess = true }); ;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}