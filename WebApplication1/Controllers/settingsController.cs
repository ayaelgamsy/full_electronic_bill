using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace electronic_bill.Controllers
{
    public class settingsController : Controller
    {
        Model1 db1 = new Model1();
        // GET: settings
        public ViewResult settings()
        {
            List<coins_type> coinstypelist = db1.coins_type.ToList();
            ViewBag.coinstypelist = coinstypelist.ToList();
            List<bill_type> billtypeslist = db1.bill_type.ToList();
            ViewBag.billtypeslist = billtypeslist.ToList();
            List<unit> units = db1.units.ToList();
            ViewBag.unitslist = units.ToList();
           
            return View();
        }
        public ActionResult save_bill_types(bill_type newtype)
        {
            if (ModelState.IsValid)
            {
                bill_type type = new bill_type();
                type.type_name = newtype.type_name;
                db1.bill_type.Add(type);
                db1.SaveChanges();
            }
            return RedirectToAction("settings", "settings");
        }
        public ActionResult save_coins(string coins_type)
        {
           
                List<coins_type> coins_typelist = db1.coins_type.ToList();
                coins_type coin = new coins_type();
            coin.coin_name = coins_type;
                db1.coins_type.Add(coin);
                db1.SaveChanges();
           
            return RedirectToAction("settings", "settings");
        }
        public ActionResult save_units( unit newunit)
        {
            if (ModelState.IsValid)
            {
                List<unit> units = db1.units.ToList();
                unit unit1 = new unit();
                unit1.unit_name = newunit.unit_name;
                unit1.tax_code = newunit.tax_code;
                db1.units.Add(unit1);
                db1.SaveChanges();
            }
            return RedirectToAction("settings", "settings");
        }
        public ActionResult updatecoins() 
        {
            

            if (Request.QueryString["coin_id"] != null)
            {
                List<coins_type> coinstypelist = db1.coins_type.ToList();
                ViewBag.coinstypelist = coinstypelist.ToList();
                int id = Convert.ToInt32(Request.QueryString["coin_id"]);
                coins_type coin1 = db1.coins_type.Find(id);

                ViewBag.coin_name = coin1.coin_name;
           }
            if (Request.QueryString["type_id"] != null) 
            {
                List<bill_type> bill_Types = db1.bill_type.ToList();
                ViewBag.bill_types = bill_Types.ToList();
                int id = Convert.ToInt32(Request.QueryString["type_id"]);
                bill_type type1 = db1.bill_type.Find(id);
                ViewBag.type1 = type1;
            }
            if (Request.QueryString["unit_id"]!= null)
            {
                List<unit> units = db1.units.ToList();
                ViewBag.unitslist = units.ToList();
                int id= Convert.ToInt32(Request.QueryString["unit_id"]);
                unit unit1 = db1.units.Find(id);
                ViewBag.unit_name = unit1.unit_name;
            }
            return View();
        }
        public ActionResult editecoin(coins_type newcoin)
        {
            if (ModelState.IsValid)
            {
                coins_type coin1 = db1.coins_type.Find(newcoin.coin_id);
                coin1.coin_name = newcoin.coin_name;
                db1.SaveChanges();
            }
            return RedirectToAction("settings", "settings");
        }
        public ActionResult editebilltype(bill_type edibill)
        {
            if (ModelState.IsValid)
            {
                bill_type bill_Type = db1.bill_type.Find(Convert.ToInt32(edibill.type_id));
                bill_Type.type_name = edibill.type_name;
                bill_Type.documentType = edibill.documentType;
                bill_Type.documentTypeVersion=edibill.documentTypeVersion;
                db1.SaveChanges();
            }
                return RedirectToAction("settings", "settings");
            
        }
       
             public ActionResult editeunits(unit edunite)
        {
            if (ModelState.IsValid)
            {
                unit units = db1.units.Find(Convert.ToInt32(edunite.unit_id));
                units.unit_name = edunite.unit_name;
                units.tax_code = edunite.tax_code;
                db1.SaveChanges();
            }
            return RedirectToAction("settings", "settings");
        }
    }
}