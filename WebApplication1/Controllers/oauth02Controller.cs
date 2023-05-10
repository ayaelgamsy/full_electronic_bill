using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Controllers;
using System.Text;

namespace WebApplication1.Controllers
{
   
    public class oauth02Controller : Controller
    {

        public static string application_name = "smart app";
        public static string Client_id = "2d20fc8b-1cc6-443b-a76f-76dec0ce7f00";
        public static string Client_Secret = "3ee9d03b-8991-41f7-a5a1-e2cef3278c90";
        public static string redirect_uri = "https://localhost:44389";
        public static string authuri_uri = "https://id.preprod.eta.gov.eg/connect/token";
        public static string token_uri = "https://id.preprod.eta.gov.eg/connect/token";
        public static string scopes = "InvoicingAPI";
        public ActionResult gettoken()
        {
          //  //string grant_type = "client_credentials";
          //  //string client_id = "2d20fc8b - 1cc6 - 443b - a76f - 76dec0ce7f00";
          //  //string client_secret = "3ee9d03b-8991-41f7-a5a1-e2cef3278c90";
            HttpClient client = new HttpClient();
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, "https://id.preprod.eta.gov.eg/connect/token");
            req.Headers.Add("cache-control", "no-cache");
            ////  req.Headers.Add("content-type", "application/x-www-form-urlencoded");


            //  // This is the important part:
            // req.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            // {
            //   { "grant_type", "client_credentials" },
            //      { "client_id", "2d20fc8b-1cc6-443b-a76f-76dec0ce7f00" },
            //    { "client_secret", "3ee9d03b-8991-41f7-a5a1-e2cef3278c90" },
            //{ "scope", "InvoicingAPI" },

            // });
            var postdata = new
            {
                //  code = code,
                client_id = Client_id,
                client_serect = Client_Secret,
                redirct_uri = redirect_uri,
                grant_type = "client_credentials"
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(postdata), Encoding.ASCII, "application/x-www-form-urlencoded");
            HttpResponseMessage resp = client.PostAsync("https://id.preprod.eta.gov.eg/connect/token",content).Result;
          //  //if (resp.IsSuccessStatusCode)
          //  //{
              string testtoken =resp.Content.ReadAsAsync<string>().Result;
          //      ViewBag.token = testtoken;
          //  //}
          //  //else { ViewBag.token = "noresponse"; }
         
            
            return View();
            
        }
    }

   
}