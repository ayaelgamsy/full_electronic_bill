using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class usersController : Controller
    {
        Model1 db1 = new Model1();
        // GET: users
        public ViewResult add_user()
        {
            
            return View();
        }
        public ActionResult save_users( users newuser)
        {
            users add_us = new users();
            add_us.user_name = newuser.user_name;
            add_us.password = newuser.password;
            db1.users.Add(add_us);
            db1.SaveChanges();
            return View();
                }
        public ActionResult add_users_activity(users newuser)
        {
            users add_us = new users();
            add_us.user_name = newuser.user_name;
            add_us.password = newuser.password;
            db1.users.Add(add_us);
            db1.SaveChanges();
            int id = add_us.user_id;
            List<activity> activelis = db1.activities.ToList();
            ViewBag.actives = activelis;
        // var users_actives = db1.user_activity.Include("activity").Where(n => n.user_id == id).ToList();
         //   ViewBag.users_actives = users_actives;
            ViewBag.user_id = id;

            return View(db1.users.Find(id));
           
        }
        public ActionResult add_new_users_activity(int user_id,int activity_id)
        {
            if (activity_id != 0)
            {
                user_activity add_us_act = new user_activity();
                add_us_act.user_id = user_id;
                add_us_act.activity_id = activity_id;
                db1.user_activity.Add(add_us_act);
                db1.SaveChanges();
            }
            int id = user_id;
            ViewBag.user_id = id;
            List<activity> activelis = db1.activities.ToList();
            ViewBag.actives = activelis;
            List<user_activity> users_actives = db1.user_activity.Include("activity").Where(n => n.user_id == id).ToList();
          ViewBag.users_actives = users_actives;


            return View(db1.users.Find(id));
        
        }
        public ActionResult delete_user_activ(int id)
        {
            user_activity del_us_activity = db1.user_activity.Find(id);
            int user_id = del_us_activity.user_id;
            
            db1.user_activity.Remove(del_us_activity);
            db1.SaveChanges();
            return RedirectToAction("add_new_users_activity", "users", new { user_id = user_id , activity_id = 0});
        }

        }
}