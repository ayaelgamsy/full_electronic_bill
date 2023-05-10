using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{

    public class activityController : Controller
    {
        Model1 db1 = new Model1();
        // GET: activity
        public ActionResult creat_activity()
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                int next_id = db1.activities.Select(n => n.activity_id).Max();
                next_id = next_id + 1;
                ViewBag.next_id = next_id;
                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }


        public ActionResult save(activity newactive)
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                if (ModelState.IsValid)
                {
                    List<activity> activitylist = db1.activities.ToList();
                    activity active = new activity();
                    active.activity_name = newactive.activity_name;
                    active.tax_registration_number = newactive.tax_registration_number;
                    active.tax_card = newactive.tax_card;
                    active.commercial_register = newactive.commercial_register;
                    active.phone_number = newactive.phone_number;
                    active.manger_name = newactive.manger_name;
                    active.address = newactive.address;
                    active.email = newactive.email;
                    active.internal_numberofcomp = newactive.internal_numberofcomp;
                    active.seed_number = newactive.seed_number;
                    active.branche_id = newactive.branche_id;
                    active.country = newactive.country;
                    active.governate = newactive.governate;
                    active.regionCity = newactive.regionCity;
                    active.street = newactive.street;
                    active.buildingNumber = newactive.buildingNumber;
                    active.postalCode = newactive.postalCode;
                    active.floor = newactive.floor;
                    active.room = newactive.room;
                    active.landmark = newactive.landmark;
                    active.additionalInformation = newactive.additionalInformation;
                    active.client_id = newactive.client_id;
                    active.secret_id = newactive.secret_id;
                    db1.activities.Add(active);
                    db1.SaveChanges();


                }

                List<activity> activitylistview = db1.activities.ToList();
                ViewBag.activitylistview = activitylistview.ToList();
                return View();
            }
        
            else
            {
                return RedirectToAction("loginpage", "login");
            }
        }
    }
}