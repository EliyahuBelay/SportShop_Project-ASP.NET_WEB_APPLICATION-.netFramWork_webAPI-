using SportShop_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_Project.Controllers
{
    public class ShirtController : Controller
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContext = new SportShopDBDataContext(stringConnection);
        // GET: Shirt
        public ActionResult GetAllShirt()
        {
            ViewBag.Title = "Shirts";
            List<Cloth> shirtsList= dataContext.Cloths.Where(item => item.ClothType == "Shirt").ToList();
            return View(shirtsList);
        }

        public ActionResult GetAllShirtTable()
        {
            ViewBag.TableName = "Shirts Details";
            List<Cloth> shirtsList = dataContext.Cloths.Where(item => item.ClothType == "Shirt").ToList();
            return View(shirtsList);
        }

        public ActionResult GetAllShortShirts()
        {
            ViewBag.Title = "Short Shirts ";
            List<Cloth> shirtsList = dataContext.Cloths.Where(item => item.ClothType == "Shirt" && item.ClothIsShort == true).ToList();
            return View(shirtsList);
        }

        public ActionResult GetAllLongShirts()
        {
            ViewBag.Title = "Long Shirts ";
            List<Cloth> shirtsList = dataContext.Cloths.Where(item => item.ClothType == "Shirt" && item.ClothIsShort == false).ToList();
            return View(shirtsList);
        }

        public ActionResult GetAllDryFitShirts()
        {
            ViewBag.Title = "Dry Fit Shirts ";
            List<Cloth> shirtsList = dataContext.Cloths.Where(item => item.ClothType == "Shirt" && item.ClothIsDryFit == true).ToList();
            return View(shirtsList);
        }

        public ActionResult GetAllSortShirtSortByPrice()
        {
            ViewBag.Title = "Price Low to High ";
            List<Cloth> shirtsList = dataContext.Cloths.Where(item => item.ClothType == "Shirt").OrderBy(item => item.ClothPrice).ToList();
            return View(shirtsList);
        }
    }
}