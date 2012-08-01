using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApp.Controllers
{

    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View("Account");
        }

        /// <summary>
        /// Search Method
        /// </summary>
        /// <param name="SearchCriteria"></param>
        /// <returns></returns>
        public JsonResult Search(string SearchCriteria)
        {
            //Temporary Code
            //todo: can write actual search functionality
            Random rnd = new Random();

            return Json(new { AccountId = 1, Name = "test", Balance = rnd.NextDouble() * 93.244d });
        }

        /// <summary>
        /// Save method
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="Name"></param>
        /// <returns></returns>
        public JsonResult Update(int AccountId, string Name)
        {
            ////Temporary Code
            //todo: can write actual update code
            Random rnd = new Random();

            return Json(new { AccountId = AccountId, Name = "test", Balance = rnd.NextDouble() * 93.244d });
        }

    }
}
