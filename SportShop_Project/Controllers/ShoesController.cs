using SportShop_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_Project.Controllers
{
    public class ShoesController : Controller
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContext = new SportShopDBDataContext(stringConnection);
        // GET: Shoes
        public ActionResult GetAllShoes()
        {
            ViewBag.Title = "Shoes";
            return View(dataContext.Shoes.ToList());
        }
        public ActionResult GetAllShoesTable()
        {
            ViewBag.TableName = "Shoes Details";
            return View(dataContext.Shoes.ToList());
        }
        public ActionResult GetAllShoesOnSale()
        {
            ViewBag.Title = "Shoes on Sale";
            List<Shoe> list = dataContext.Shoes.Where((item) => item.ShoeInSale == true).ToList();
            return View(list);
        }
    }
}