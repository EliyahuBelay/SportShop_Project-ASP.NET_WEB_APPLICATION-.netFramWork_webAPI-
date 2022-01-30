using SportShop_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportShop_Project.Controllers
{
    public class EquipmentController : Controller
    {
        static string stringConnection = "Data Source=LAPTOP-HG30JHU1;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        SportShopDBDataContext dataContext = new SportShopDBDataContext(stringConnection);
        // GET: Shirt
        public ActionResult GetAllSportsEquipment()
        {
            ViewBag.Title = "Sport Equipment";
            List<SportEquipment> equipmentList = dataContext.SportEquipments.ToList();
            return View(equipmentList);
        }

        public ActionResult GetAllSportsEquipmentTable()
        {
            ViewBag.TableName = "Sports Equipment Details";
            List<SportEquipment> equipmentList = dataContext.SportEquipments.ToList();
            return View(equipmentList);
        }

        public ActionResult GetAllSoccerSportsEquipment()
        {
            ViewBag.Title = "Soccer Equipment ";
            List<SportEquipment> EquipmentList = dataContext.SportEquipments.Where(item => item.SportType == "Soccer").ToList();
            return View(EquipmentList);
        }
        public ActionResult GetAllBasketballSportsEquipment()
        {
            ViewBag.Title = "Basketball Equipment ";
            List<SportEquipment> EquipmentList = dataContext.SportEquipments.Where(item => item.SportType == "Basketball").ToList();
            return View(EquipmentList);
        }
        public ActionResult GetAllSortEquipmentSportSortByPrice()
        {
            ViewBag.Title = "Price Low to High ";
            List<SportEquipment> EquipmentList = dataContext.SportEquipments.OrderBy(item => item.EquipmentPrice).ToList();
            return View(EquipmentList);
        }
    }
}