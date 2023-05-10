using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace electronic_bill.Controllers
{
    public class tax_typesController : Controller
    {
        Model1 db1 = new Model1();
        // GET: tax_types
        public ActionResult tax_types()
        {
            List<tax_types> tax_Typeslist = db1.tax_types.ToList();
            ViewBag.tax_Typeslist = tax_Typeslist;
            return View();
            
        }
        public ActionResult creat_tax_type()
        {
            List<tax_types> tax_Typeslist = db1.tax_types.ToList();
            ViewBag.tax_Typeslist = tax_Typeslist;
            return View();
        }
        public ActionResult save_tax_type(tax_types type)
        {
            tax_types newtype = new tax_types();
            newtype.tax_name = type.tax_name;
            newtype.tax_name_code = type.tax_name_code;
            newtype.tax_cat_system_id = type.tax_cat_system_id;
            newtype.percent = type.percent;
            db1.tax_types.Add(newtype);
            db1.SaveChanges();
            return RedirectToAction("tax_types", "tax_types");
        }
        public ActionResult update_tax_type( int id)
        {

            return View(db1.tax_types.Find(id));
        }
        public ActionResult edite_tax_type(tax_types type) 
        {
            tax_types editedtax = db1.tax_types.Find(type.tax_id);
            editedtax.tax_name = type.tax_name;
            editedtax.tax_name_code = type.tax_name_code;
            editedtax.tax_cat_system_id = type.tax_cat_system_id;
            editedtax.percent = type.percent;
            db1.SaveChanges();
            return RedirectToAction("tax_types", "tax_types");
        }
        public ActionResult delete_tax_type(int id) 
        {
            tax_types deltax = db1.tax_types.Find(id);
            db1.tax_types.Remove(deltax);
            db1.SaveChanges();
            return RedirectToAction("tax_types", "tax_types");
            
        }
    }
}