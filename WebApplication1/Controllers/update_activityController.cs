using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace electronic_bill.Controllers
{
    public class update_activityController : Controller
    {
        // GET: update_activity
        Model1 db1 = new Model1();
        public ActionResult update_activity(int id)
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                return View(db1.activities.Find(id));
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        public ActionResult delete_activity(int id )
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                activity active = db1.activities.Find(id);
            db1.activities.Remove(active);
            db1.SaveChanges();
            List<activity> activitylistview = db1.activities.ToList();
            ViewBag.activitylistview = activitylistview.ToList();
            return RedirectToAction("save", "activity");
            }
            else { return RedirectToAction("loginpage", "login"); }


        }
        public ActionResult edite_active(activity act1)
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                activity acts = db1.activities.Find(act1.activity_id);
                acts.activity_name = act1.activity_name;
                acts.tax_registration_number = act1.tax_registration_number;
                acts.tax_card = act1.tax_card;
                acts.commercial_register = act1.commercial_register;
                acts.phone_number = act1.phone_number;
                acts.manger_name = act1.manger_name;
                acts.address = act1.address;
                acts.email = act1.email;
                acts.internal_numberofcomp = act1.internal_numberofcomp;
                acts.seed_number = act1.seed_number;
                acts.branche_id = act1.branche_id;
                acts.country = act1.country;
                acts.governate = act1.governate;
                acts.regionCity = act1.regionCity;
                acts.street = act1.street;
                acts.buildingNumber = act1.buildingNumber;
                acts.postalCode = act1.postalCode;
                acts.floor = act1.floor;
                acts.room = act1.room;
                acts.landmark = act1.landmark;
                acts.additionalInformation = act1.additionalInformation;
                acts.client_id = act1.client_id;
                acts.secret_id = act1.secret_id;
                db1.SaveChanges();
           
            return RedirectToAction("save", "activity");
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        
    }
}