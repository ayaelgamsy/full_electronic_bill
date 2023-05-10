using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class deductionsController : Controller
    {
        // GET: deductions
        Model1 db1 = new Model1();
        public ActionResult deducitions()
        {
            List<deductions> deductionslist = db1.deductions.ToList();
            ViewBag.deductionslist = deductionslist;
            return View();
        }
        public ActionResult creat_deduction()
        {
            List<deductions> deductionslist = db1.deductions.ToList();
            ViewBag.deductionslist = deductionslist;
            return View();
        }
        public ActionResult save_deduction(deductions deduct)
        {
            deductions newdedyct = new deductions();
            newdedyct.deduction_name = deduct.deduction_name;
            newdedyct.returnable = deduct.returnable;
            
            db1.deductions.Add(newdedyct);
            db1.SaveChanges();
            return RedirectToAction("deducitions","deductions");
        }
        public ActionResult update_deduction(int id)
        {

            return View(db1.deductions.Find(id));
        }
        public ActionResult edite_deduction(deductions deduct)
        {
            deductions deducedite = db1.deductions.Find(deduct.deduction_id);
            deducedite.deduction_name = deduct.deduction_name;
            deducedite.returnable = deduct.returnable;
            
            db1.SaveChanges();
            return RedirectToAction("deducitions", "deductions");
        }
    }

}