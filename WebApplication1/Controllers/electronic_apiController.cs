using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;

namespace WebApplication1.Controllers
{
    public class electronic_apiController : Controller
    {
        public static string token="";
        // GET: electronic_api
        public ActionResult Index()
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage resp = client.GetAsync("").Result;
            if (resp.IsSuccessStatusCode) { }
           // else {resp.Content.ReadAsAsync }
            return View();
        }
        public ActionResult gettoken()
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage resp = client.GetAsync("https://api.preprod.invoicing.eta.gov.eg/connect/token").Result;
            if (resp.IsSuccessStatusCode)
            {
               string testtoken = resp.Content.ReadAsAsync<string>().Result;
                ViewBag.token = testtoken;
            }
            else { ViewBag.token = "noresponse"; }
            return View();
        }
        public ActionResult usetoken()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage resp = client.GetAsync("").Result;
            if (resp.IsSuccessStatusCode)
            { string tx= resp.Content.ReadAsAsync<string>().Result; }
            return View();
        }
    }
}