using SportShop_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_Project.Controllers
{
    public class PantsController : Controller
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContext = new SportShopDBDataContext(stringConnection);
        // GET: Shirt
        public ActionResult GetAllPants()
        {
            ViewBag.Title = "Pants";
            List<Cloth> pantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants").ToList();
            return View(pantsList);
        }

        public ActionResult GetAllPantsTable()
        {
            ViewBag.TableName = "Pants Details";
            List<Cloth> PantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants").ToList();
            return View(PantsList);
        }

        public ActionResult GetAllLongPants()
        {
            ViewBag.Title = "Long Pants ";
            List<Cloth> PantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants" && item.ClothIsShort == false).ToList();
            return View(PantsList);
        }
        public ActionResult GetAllShortPants()
        {
            ViewBag.Title = "Short Pants ";
            List<Cloth> PantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants" && item.ClothIsShort == true).ToList();
            return View(PantsList);
        }


        public ActionResult GetAllDryFitPants()
        {
            ViewBag.Title = "Dry Fit Pants ";
            List<Cloth> PantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants" && item.ClothIsDryFit == true).ToList();
            return View(PantsList);
        }

        public ActionResult GetAllSortPantsSortByPrice()
        {
            ViewBag.Title = "Price Low to High ";
            List<Cloth> PantsList = dataContext.Cloths.Where(item => item.ClothType == "Pants").OrderBy(item => item.ClothPrice).ToList();
            return View(PantsList);
        }

    }
}