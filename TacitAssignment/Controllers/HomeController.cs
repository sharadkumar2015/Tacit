using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TacitAssignment.Repository;

namespace TacitAssignment.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        //public async Task<string> Test()
        //{
        //    RestaurantRepository repo = new RestaurantRepository();
        //    string data = await repo.GetDataAsync("api/v1/restaurants/9245");
        //    return data;
        //}
    }
}
