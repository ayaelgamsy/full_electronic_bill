using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text.Encodings;
using System.Net.Http.Headers;

namespace WebApplication1.Controllers
{
    public class getaccessController : Controller
    {
        public static string application_name = "smart app";
        public static string Client_id = "2d20fc8b-1cc6-443b-a76f-76dec0ce7f00";
        public static string Client_Secret = "3ee9d03b-8991-41f7-a5a1-e2cef3278c90";
        public static string redirect_uri = "https://localhost:44389";
        public static string authuri_uri = "https://id.preprod.eta.gov.eg/connect/token";
        public static string token_uri = "https://id.preprod.eta.gov.eg/connect/token";
        public static string scopes = "InvoicingAPI";
        public static string getoauthuri (string extraparam)
        {
            StringBuilder sburi = new StringBuilder(authuri_uri);
            sburi.Append("client_id=" + Client_id);
            sburi.Append("&redirct_uri=" + redirect_uri);
            sburi.Append("&response_type=" + "code");
            sburi.Append("&scope=" +scopes);
            sburi.Append("&access_type=" + "offline");
            sburi.Append("&state=" + extraparam);
            return sburi.ToString();

        }
        public static async Task<invoicingtoken> gettokenbycode()
            //(string code)
        {
            invoicingtoken token = null;
            var postdata = new
        {
          //  code = code,
            client_id = Client_id,
            client_serect=Client_Secret,
            redirct_uri=redirect_uri,
            grant_type= "client_credentials"
        };
            using (var httpclient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(postdata), Encoding.UTF8, "application/json");
                using (var response =await httpclient.PostAsync(token_uri, content)) 
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK) 
                    {
                        string responstring =await response.Content.ReadAsStringAsync();
                        token = JsonConvert.DeserializeObject<invoicingtoken>(responstring);
                        
                    }
                }
            }
            return token;
        }
        public async Task<ActionResult> getaccess()
        {
         var token=   await gettokenbycode();
            ViewBag.access_token = token.access_token;
            ViewBag.refresh = token.refresh_token;
            return View();
        }
    }
}