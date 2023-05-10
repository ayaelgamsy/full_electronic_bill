using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class deduction_billsController : Controller
    {
        Model1 db1 = new Model1();
        public ActionResult deduction_bills()
        {
            List<deduction_bills> deductions_billlist = db1.deduction_bills.ToList();
            ViewBag.deductions_billlist = deductions_billlist;
            return View();
        }
    }
}