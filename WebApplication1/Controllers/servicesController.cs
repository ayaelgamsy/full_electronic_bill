using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace electronic_bill.Controllers
{
    public class servicesController : Controller
    {
        Model1 db1 = new Model1();
        public class Item
        {
            public string codeType { get; set; }
            public string parentCode { get; set; }
            public string itemCode { get; set; }
            public string codeName { get; set; }
            public string codeNameAr { get; set; }
            public DateTime activeFrom { get; set; }
            public DateTime activeTo { get; set; }
            public string description { get; set; }
            public string descriptionAr { get; set; }
            public string requestReason { get; set; }
        }

        public class Root
        {
            public List<Item> items { get; set; }
        }
       
        public ActionResult services()
        {
            if (Session["user_id"]!=null &&Session["token"] != null)
            {
                List<activity> activelis = db1.activities.ToList();
                SelectList activeselect = new SelectList(activelis, "activity_id", "activity_name", "0");
                ViewBag.actives = activeselect;
                List<codetype> codetypelist = new List<codetype>();
                codetype type1 = new codetype();
                type1.code_type_name = "EGS";
                codetypelist.Add(type1);
                codetype type2 = new codetype();
                type2.code_type_name = "GS1";
                codetypelist.Add(type1);
                codetypelist.Add(type2);
                SelectList codetypeselect = new SelectList(codetypelist, "code_type_name", "code_type_name");
                ViewBag.codetype = codetypeselect;
                List<unit> unitlist = db1.units.ToList();
                SelectList unitselect = new SelectList(unitlist, "unit_id", "unit_name", "0");
                ViewBag.units = unitselect;
                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        public async Task<ActionResult> save_service( service newserv)
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                if (newserv.activity_id != 0)
                {
                    if (ModelState.IsValid)
                    {
                        Item postitem = new Item();
                        postitem.codeType = newserv.codeType;
                        postitem.parentCode = newserv.service_GPC;
                        postitem.itemCode = newserv.service_EGS;
                        postitem.codeName = newserv.codeName;
                        postitem.codeNameAr = newserv.service_name;
                        postitem.activeFrom = newserv.activeFrom;
                        postitem.activeTo = newserv.activeTo;
                        postitem.description = newserv.description;
                        postitem.descriptionAr = newserv.service_discription;
                        postitem.requestReason = "Request reason text"+ newserv.service_discription;
                        List<Item> postedlist = new List<Item>();

                        postedlist.Add(postitem);

                        Root myroot = new Root();
                        myroot.items = postedlist;
                        string jsonstring = JsonConvert.SerializeObject(myroot);
                        HttpClient client = new HttpClient();

                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"].ToString());



                        client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                        //رابط فعلى
                         var request = new HttpRequestMessage(HttpMethod.Post, "https://api.invoicing.eta.gov.eg/api/v1.0/codetypes/requests/codes");

                        //رابط تجريبى
                        //   var request = new HttpRequestMessage(HttpMethod.Post, "https://api.preprod.invoicingeta.gov.eg/api/v1.0/codetypes/requests/codes");
                        request.Content = new StringContent(jsonstring, System.Text.Encoding.UTF8, "application/json");
                        var response = await client.SendAsync(request);

                        string stauscode = response.StatusCode.ToString();
                        string tokestring = await response.Content.ReadAsStringAsync();
                        ViewBag.token = tokestring;
                        ViewBag.stauscode = stauscode;
                        db1.service.Add(newserv);
                        db1.SaveChanges();
                    }
                }
                //البيئة الفعلية
                var clientdata = new RestClient("https://api.invoicing.eta.gov.eg/api/v1.0/codetypes/requests/my?PageNumber=2");


                var requestdata = new RestRequest("https://api.invoicing.eta.gov.eg/api/v1.0/codetypes/requests/my?pageSize=100&PageNumber=1", Method.Get);
                //ألبيئة التجريبية
                //var clientdata = new RestClient("https://api.preprod.invoicing.eta.gov.eg/api/v1.0/codetypes/requests/my?PageNumber=2");


                //var requestdata = new RestRequest("https://api.preprod.invoicing.eta.gov.eg/api/v1.0/codetypes/requests/my?pageSize=100&PageNumber=1", Method.Get);
                requestdata.Timeout = -1;
                requestdata.AddHeader("Accept-Language", "en");

                requestdata.AddHeader("Authorization", "Bearer " + Session["token"].ToString());


               var responsedata = await clientdata.GetAsync(requestdata);
                string jasondata = responsedata.Content;
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    MissingMemberHandling = MissingMemberHandling.Ignore
                };
                portalcodes portcodeslis = JsonConvert.DeserializeObject<portalcodes>(jasondata,settings);
               

                List<Result> rescodeslist = new List<Result>();
                rescodeslist = portcodeslis.result;
                //List<service> servicelistview = db1.service.Include("activity").Include("unit").ToList();

                //ViewBag.servicelistview = servicelistview.ToList();
                ViewBag.rescodeslist = rescodeslist.ToList();
             
                


                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        public ActionResult delete_service(int id)
        { 
            service serv = db1.service.Find(id);
            db1.service.Remove(serv);
            db1.SaveChanges();
            List<service> servicelistview = db1.service.ToList();
            ViewBag.servicelistview = servicelistview.ToList();
            return RedirectToAction("save_service","services");
        }
        public ActionResult update_service(int id)
        {
            List<activity> activelis = db1.activities.ToList();
            SelectList activeselect = new SelectList(activelis, "activity_id", "activity_name", "0");
            ViewBag.actives = activeselect;
            List<unit> unitlist = db1.units.ToList();
            SelectList unitselect = new SelectList(unitlist, "unit_id", "unit_name", "0");
            ViewBag.units = unitselect;
            return View(db1.service.Find(id));
        }
        public ActionResult edite_service(service serv)
        {
            service serv1 = db1.service.Find(serv.services_id);
            serv1.activity_id = serv.activity_id;
            serv1.service_name = serv.service_name;
            serv1.service_GPC = serv.service_GPC;
            serv1.service_EGS = serv.service_EGS;
            serv1.service_discription = serv.service_discription;
            serv.unite_id = serv.unite_id;
            db1.SaveChanges();
            return RedirectToAction("save_service", "services");
        }
    }
}