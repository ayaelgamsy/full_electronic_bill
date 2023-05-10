using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class loginController : Controller
    {
        Model1 db1 = new Model1();
        // GET: login
        public ActionResult loginpage()
        {
            return View();
        }
        public ActionResult choose_activity( string user_name, string password)
        {
            var thisusert = (from userlist in db1.users where userlist.user_name == user_name && userlist.password == password select userlist.user_id).SingleOrDefault();

            int id = Convert.ToInt32(thisusert);
           List<user_activity> user_activity_list = db1.user_activity.Where(n => (n.user_id == 0)).ToList();
          if (id== 0 )
            { Session["message"] = "تأكد من إسم المستخدم وكلمة المرور";
                
                return RedirectToAction("loginpage", "login");
            }
            else
           {
               user_activity_list= db1.user_activity.Where(n =>( n.user_id == id)).ToList();
                ViewBag.user_activity_li = user_activity_list;
                Session["user_id"] = id;

                return View();
            }
            
        }
        public async Task<ActionResult> register_log( int user_activity)
        {

            string client_id = (from activit_data in db1.activities where activit_data.activity_id == user_activity select activit_data.client_id).SingleOrDefault();
            string client_secret = (from activit_data in db1.activities where activit_data.activity_id == user_activity select activit_data.secret_id).SingleOrDefault();
            if (client_id != null && client_secret != null)
            {
                HttpClient client = new HttpClient();
                //رابط البيئة التجريبية
               // var request = new HttpRequestMessage(HttpMethod.Post, "https://id.preprod.eta.gov.eg/connect/token");
               var request = new HttpRequestMessage(HttpMethod.Post, "https://id.eta.gov.eg/connect/token");
                request.Content = new FormUrlEncodedContent(new Dictionary<string, string> {
                //روابط البيئة التجريبية
                //{ "client_id", "2d20fc8b-1cc6-443b-a76f-76dec0ce7f00" },
                //{ "client_secret", "3ee9d03b-8991-41f7-a5a1-e2cef3278c90" },
                //{ "grant_type", "client_credentials" }
                //روابط البيئة الفعلية
                //{ "client_id", "4e36f155-a1c5-4700-a8d4-e12bb3543054" },
                //{ "client_secret", "07c5fef0-7b2b-4951-acff-ac7c0a7a2f55" },
                //{ "grant_type", "client_credentials" }
                //روابط البيئة الفعلية 22-6
                { "client_id", client_id },
                     { "client_secret", client_secret },
                     { "grant_type", "client_credentials" }
                //روابط سمارت سيرفس
                //    { "client_id", "964d0ffc-0619-41db-9a8f-80f8f3c9ce91" },
                //        { "client_secret", "f9609b65-825a-48a3-b0e6-561ca6fe6cff" },
                //       { "grant_type", "client_credentials" }
                }

                );

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var payload = JObject.Parse(await response.Content.ReadAsStringAsync());
                var token = payload.Value<string>("access_token");
                string tokestring = token.ToString();
                ViewBag.token = tokestring;
                Session["token"] = tokestring;
                return RedirectToAction("Index", "Home");
            }
            else {
                Session["token"] = "الأكواد الخاصة بدافع الضرائب غير متوفرة";
                return RedirectToAction("loginpage", "login");
            }
            
        }
    }
}