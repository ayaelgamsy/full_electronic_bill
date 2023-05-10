using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Interop.Excel;

namespace WebApplication1.Controllers
{
    public class excel_uploadController : Controller
    {
        public class Address
        {
            public string branchID { get; set; }
            public string country { get; set; }
            public string governate { get; set; }
            public string regionCity { get; set; }
            public string street { get; set; }
            public string buildingNumber { get; set; }
            public string postalCode { get; set; }
            public string floor { get; set; }
            public string room { get; set; }
            public string landmark { get; set; }
            public string additionalInformation { get; set; }
        }

        public class Delivery
        {
            public string approach { get; set; }
            public string packaging { get; set; }
            public DateTime dateValidity { get; set; }
            public string exportPort { get; set; }
            public double grossWeight { get; set; }
            public double netWeight { get; set; }
            public string terms { get; set; }
        }

        public class Discount
        {
            public int rate { get; set; }
            public int amount { get; set; }
        }

        public class Document
        {
            public Issuer issuer { get; set; }
            public Receiver receiver { get; set; }
            public string documentType { get; set; }
            public string documentTypeVersion { get; set; }
            public DateTime dateTimeIssued { get; set; }
            public string taxpayerActivityCode { get; set; }
            public string internalID { get; set; }
            public string purchaseOrderReference { get; set; }
            public string purchaseOrderDescription { get; set; }
            public string salesOrderReference { get; set; }
            public string salesOrderDescription { get; set; }
            public string proformaInvoiceNumber { get; set; }
            public Payment payment { get; set; }
            public Delivery delivery { get; set; }
            public List<InvoiceLine> invoiceLines { get; set; }
            public int totalDiscountAmount { get; set; }
            public double totalSalesAmount { get; set; }
            public double netAmount { get; set; }
            public List<TaxTotal> taxTotals { get; set; }
            public double totalAmount { get; set; }
            public int extraDiscountAmount { get; set; }
            public int totalItemsDiscountAmount { get; set; }
            public List<Signature> signatures { get; set; }
        }

        public class InvoiceLine
        {
            public string description { get; set; }
            public string itemType { get; set; }
            public string itemCode { get; set; }
            public string unitType { get; set; }
            public int quantity { get; set; }
            public string internalCode { get; set; }
            public double salesTotal { get; set; }
            public double total { get; set; }
            public double valueDifference { get; set; }
            public double totalTaxableFees { get; set; }
            public object netTotal { get; set; }
            public int itemsDiscount { get; set; }
            public UnitValue unitValue { get; set; }
            public Discount discount { get; set; }
            public List<TaxableItem> taxableItems { get; set; }
        }

        public class Issuer
        {
            public Address address { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Payment
        {
            public string bankName { get; set; }
            public string bankAddress { get; set; }
            public string bankAccountNo { get; set; }
            public string bankAccountIBAN { get; set; }
            public string swiftCode { get; set; }
            public string terms { get; set; }
        }

        public class Receiver
        {
            public Address address { get; set; }
            public string type { get; set; }
            public string id { get; set; }
            public string name { get; set; }
        }

        public class Root
        {
            public List<Document> documents { get; set; }
        }

        public class Signature
        {
            public string signatureType { get; set; }
            public string value { get; set; }
        }

        public class TaxableItem
        {
            public string taxType { get; set; }
            public double amount { get; set; }
            public string subType { get; set; }
            public int rate { get; set; }
        }

        public class TaxTotal
        {
            public string taxType { get; set; }
            public double amount { get; set; }
        }

        public class UnitValue
        {
            public string currencySold { get; set; }
            public double amountEGP { get; set; }
        }
        [HttpGet]
        public ActionResult upload_file()
        {


            return View();
        }
        [HttpPost]
        public ActionResult upload_file(HttpPostedFileBase file)
        {
            string _FileName = "";
            try
            {
                if (file.ContentLength > 0)
                {
                    _FileName = Path.GetFileName(file.FileName);
                    string _path = Path.Combine(Server.MapPath("~/uploaded_files"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";

            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }

            Application xlApp = new Application();

            Worksheet xlWorkSheet = new Worksheet();
            Range range;
            string serverpath = Server.MapPath("~/uploaded_files/" + _FileName);
            Workbook xlWorkBook = xlApp.Workbooks.Open(serverpath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            xlWorkSheet = (Worksheet)xlWorkBook.Worksheets.get_Item(1);
            range = xlWorkSheet.UsedRange;
            int rw = range.Rows.Count;

            int cl = 41;
            string cheked_bill = "";
            string priviews_bill = "";
            
            for (int rCnt = 3; rCnt <= rw; rCnt++)
            {
                
                if ((range.Cells[rCnt, 1] as Range).Value2 != null)
                {
                    cheked_bill = ((range.Cells[rCnt, 1] as Range).Value2).ToString();

                    if (cheked_bill != priviews_bill)
                    {
                        Document newdoc = new Document();
                        priviews_bill = cheked_bill;
                        ViewBag.cheked_bill = cheked_bill;
                        double dateTimeIssued = (range.Cells[rCnt, 2] as Range).Value2;
                        DateTime conv= DateTime.FromOADate(dateTimeIssued);
                        ViewBag.dateTimeIssued = conv;
                        string bill_discount = ((range.Cells[rCnt, 3] as Range).Value2).ToString();
                        ViewBag.bill_discount = bill_discount;
                        string total_befor_discount = ((range.Cells[rCnt, 4] as Range).Value2).ToString();
                        ViewBag.total_befor_discount = total_befor_discount;



                    }

                        
                }
                break;

            }
            xlWorkBook.Close(true, null, null);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);
            return View();
        }
    }
}