using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class get_decumentsController : Controller
    {
        // GET: get_decuments
        public async Task<ActionResult> getdecuments_list()
        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                var clientdata = new RestClient("https://api.invoicing.eta.gov.eg/api/v1.0/documents/recent?pageNo=1&pageSize=300");

                var requestdata = new RestRequest("https://api.invoicing.eta.gov.eg/api/v1.0/documents/recent?pageNo=1&pageSize=300", Method.Get);
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
                invoic_bill invoice_bill_lis = JsonConvert.DeserializeObject<invoic_bill>(jasondata, settings);
                List<Resultbill> rest_bill_list = new List<Resultbill>();
                rest_bill_list = invoice_bill_lis.result;
                ViewBag.rest_bill_list = rest_bill_list.ToList();


                
                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        public  async Task <ActionResult> print_out(string id)

        {
            if (Session["user_id"] != null && Session["token"] != null)
            {
                // var clientdata = new RestClient("https://api.invoicing.eta.gov.eg/api/v1.0/documents/"+id+"/pdf");

                // var requestdata = new RestRequest("https://api.invoicing.eta.gov.eg/api/v1.0/documents/"+id+"/pdf", Method.Get);
                //requestdata.Timeout = -1;
                // requestdata.AddHeader("Accept-Language", "en");

                // requestdata.AddHeader("Authorization", "Bearer " + Session["token"].ToString());


                // var responsedata = await clientdata.GetAsync(requestdata);
                // string jasondata = responsedata.Content;
                // var settings = new JsonSerializerSettings
                // {
                //     NullValueHandling = NullValueHandling.Ignore,
                //     MissingMemberHandling = MissingMemberHandling.Ignore
                // };

                //using (var file = System.IO.File.Create("somePathHere.pdf"))
                //{ // create a new file to write to
                //    //var contentStream = await responsedata.ReadAsStreamAsync(); // get the actual content stream
                //    //await contentStream.CopyToAsync(file); // copy that stream to the file stream
                //}
                // ViewBag.print_pdf = jasondata;
                HttpClient client = new HttpClient();

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"].ToString());



                client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");

                var NewResponse = await client.GetAsync ("https://api.invoicing.eta.gov.eg/api/v1.0/documents/" + id + "/pdf");

                System.Net.Http.HttpContent content = NewResponse.Content; // actually a System.Net.Http.StreamContent instance but you do not need to cast as the actual type does not matter in this case

                using (var file = System.IO.File.Create("somePathHere.pdf"))
                { // create a new file to write to
                    var contentStream = await content.ReadAsStreamAsync(); // get the actual content stream
                    await contentStream.CopyToAsync(file); // copy that stream to the file stream
                }


                ///   ViewBag.coInit = window.open(/get_decuments/GetReport,"_blank")";


                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
        public FileResult GetReport()
        {
            string ReportURL = "C:/Program Files (x86)/IIS Express/somePathHere.pdf";
            byte[] FileBytes = System.IO.File.ReadAllBytes(ReportURL);
            return File(FileBytes, "application/pdf");
        }


    }
}
