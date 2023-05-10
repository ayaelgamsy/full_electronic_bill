using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace electronic_bill.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        Model1 db1 = new Model1();

        public ViewResult add_customer()
        {
            List<customer> customerlist = db1.customers.ToList();
            ViewBag.customerlist = customerlist;
            List<activity> activelis = db1.activities.ToList();
            ViewBag.actives = activelis;
            var list = Session["custumers_actives"] as List<custumers_activity>;

            if (list == null)
            {
                var custumers_actives = db1.custumers_activity.Where(n => n.customer_id == 0);
                Session["custumers_actives"] = custumers_actives;
            }
            return View();
        }
        public ActionResult add_custumers_activity(string activity_id, string nots)

        {
            List<customer> customers = db1.customers.ToList();

            int cust_id = 0;
            List<activity> activities = db1.activities.ToList();

            var list = Session["custumers_actives"] as List<custumers_activity>;

            if (list != null)
            {

                List<custumers_activity> custumers_Activitieslist = Session["custumers_actives"] as List<custumers_activity>;

                custumers_activity customeractives = new custumers_activity();
                customeractives.activity_id = Convert.ToInt32(activity_id);
                customeractives.customer_id = cust_id;
                customeractives.nots = nots;
                custumers_Activitieslist.Add(customeractives);
                List<activity> activitiesname = Session["activitiesname"] as List<activity>;
                activity activename = new activity();
                int id = Convert.ToInt32(activity_id);
                activename = db1.activities.Where(n => n.activity_id == id).FirstOrDefault();
                activitiesname.Add(activename);
                Session["activitiesname"] = activitiesname;
                Session["custumers_actives"] = custumers_Activitieslist;
            }
            else
            {
                List<custumers_activity> custumers_Activitieslist = db1.custumers_activity.Where(n => n.customer_id == 0).ToList();
                List<string> activity_name = new List<string>();
                custumers_activity customeractives = new custumers_activity();
                customeractives.activity_id = Convert.ToInt32(activity_id);
                customeractives.customer_id = cust_id;
                customeractives.nots = nots;
                custumers_Activitieslist.Add(customeractives);
                List<activity> activitiesname = new List<activity>();
                activity activename = new activity();
                int id = Convert.ToInt32(activity_id);
                activename = db1.activities.Where(n => n.activity_id == id).FirstOrDefault();
                activitiesname.Add(activename);
                Session["activitiesname"] = activitiesname;
                Session["custumers_actives"] = custumers_Activitieslist;
            }



            return RedirectToAction("add_customer", "customer");
        }
        public ActionResult add_custumers(string customer_name, string address, string phone, string tax_regsistration_number, string manger_name, string manger_assistant, string branche_id,string country,string governate,string regionCity, string street, string buildingNumber,string postalCode,string floor, string room ,string landmark,string additionalInformation)
        {
            List<customer> customers = db1.customers.ToList();
            customer cust = new customer();
            cust.customer_name = customer_name;
            cust.address = address;
            cust.phone = phone;
            cust.tax_regsistration_number = tax_regsistration_number;
            cust.manger_name = manger_name;
            cust.manger_assistant = manger_assistant;
            cust.branche_id = branche_id;
            cust.country = country;
            cust.governate = governate;
            cust.regionCity = regionCity;
            cust.street = street;
            cust.buildingNumber = buildingNumber;
            cust.postalCode = postalCode;
            cust.floor = floor;
            cust.room = room;
            cust.landmark = landmark;
            cust.additionalInformation = additionalInformation;
            db1.customers.Add(cust);
            db1.SaveChanges();
            int custmer_id = cust.customer_id;
            List<custumers_activity> custumers_Activitieslist = Session["custumers_actives"] as List<custumers_activity>;
            foreach (var item in custumers_Activitieslist)
            {
                item.customer_id = custmer_id;
            }
            db1.custumers_activity.AddRange(custumers_Activitieslist);
            db1.SaveChanges();
            Session["custumers_actives"] = null;
            Session["activitiesname"] = null;
            return RedirectToAction("customers", "customer");
        }
        public ActionResult customers()
        {
            Session["custumers_actives"] = null;
            Session["activitiesname"] = null;
            Session["custumers_actives_up"] = null;
            Session["activitiesname_up"] = null;
            List<customer> customerslist = db1.customers.ToList();
            ViewBag.customerslist = customerslist;
            return View();
        }
        public ActionResult update_customer(int id)
        {
            List<activity> activelis = db1.activities.ToList();
            ViewBag.actives = activelis;
           
            List<custumers_activity> custumers_actives = db1.custumers_activity.Include("activity").Where(n => n.customer_id == id).ToList();
            Session["custumers_actives_up"] = custumers_actives;

            
            return View(db1.customers.Find(id));
        }
        public ActionResult add_activity_on_update(string activity_id ,string nots)
        {
            var list = Session["custumers_actives_up"] as List<custumers_activity>;
            int customer_id=0;
            if (list != null)
            {
                List<custumers_activity> custumers_Activitieslist = Session["custumers_actives_up"] as List<custumers_activity>;

                customer_id = custumers_Activitieslist.ElementAt(0).customer_id;
                custumers_activity customeractives = new custumers_activity();
                customeractives.activity_id = Convert.ToInt32(activity_id);
                customeractives.customer_id = customer_id;
                customeractives.nots = nots;
                custumers_Activitieslist.Add(customeractives);
                //List<activity> activitiesname = Session["activitiesname_up"] as List<activity>;
                //activity activename = new activity();
                //int id = Convert.ToInt32(activity_id);
                //activename = db1.activities.Where(n => n.activity_id == id).FirstOrDefault();
                //activitiesname.Add(activename);
                //Session["activitiesname_up"] = activitiesname;
                db1.custumers_activity.Add(customeractives);
                db1.SaveChanges();
               
            }
            return RedirectToAction("update_customer","customer",new {id=customer_id });
        }
        public ActionResult delete_cust_activ(int id)
        {
            custumers_activity cus_act = db1.custumers_activity.Find(id);
            int customer_id = cus_act.customer_id;
            db1.custumers_activity.Remove(cus_act);
            db1.SaveChanges();
            return RedirectToAction("update_customer", "customer", new { id = customer_id });
        }
        public ActionResult edite_cust(customer cust) 
        {
            customer editecust = db1.customers.Find(cust.customer_id);
            editecust.customer_name = cust.customer_name;
            editecust.address = cust.address;
            editecust.phone = cust.phone;
            editecust.tax_regsistration_number = cust.tax_regsistration_number;
            editecust.manger_name = cust.manger_name;
            editecust.manger_assistant = cust.manger_assistant;
            editecust.branche_id = cust.branche_id;
            editecust.country = cust.country;
            editecust.governate = cust.governate;
            editecust.regionCity = cust.regionCity;
            editecust.street = cust.street;
            editecust.buildingNumber = cust.buildingNumber;
            editecust.postalCode = cust.postalCode;
            editecust.floor = cust.floor;
            editecust.room = cust.room;
            editecust.landmark = cust.landmark;
            editecust.additionalInformation = cust.additionalInformation;
            db1.SaveChanges();
            return RedirectToAction("customers", "customer");
        }
        public ActionResult delete_customer(int id) 
        {
            customer delcustomer = db1.customers.Find(id);
           
            List<custumers_activity> custumers_actives = db1.custumers_activity.Where(n => n.customer_id == id).ToList();
           // db1.custumers_activity.Remove("custumers_actives");
            db1.customers.Remove(delcustomer);
            db1.SaveChanges();
           
            return RedirectToAction("customers", "customer");
        }

    }
}