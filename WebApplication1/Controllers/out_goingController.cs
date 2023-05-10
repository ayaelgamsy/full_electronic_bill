using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
//using MOJ;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Security.Cryptography.Xml;
using Org.BouncyCastle.X509;
using Chilkat;
using Jering.Javascript.NodeJS;
using System.Diagnostics;
using Newtonsoft.Json.Linq;

namespace electronic_bill.Controllers
{
    public class out_goingController : Controller
    {
        Model1 db1 = new Model1();
        // GET: out_going
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


    
    public ActionResult add_out_going_bills()
        {   
            //
            List<customer> custlist = db1.customers.ToList();
            SelectList custselect = new SelectList(custlist, "customer_id", "customer_name", "0");
            ViewBag.custselect = custselect;
            //
            List<bill_type> billtypelist = db1.bill_type.ToList();
            SelectList bill_type_select = new SelectList(billtypelist,"type_id","type_name","0");
            ViewBag.bill_type_select = bill_type_select;
            //
            List<coins_type> coins_Typeslist = db1.coins_type.ToList();
            SelectList coin_types_select = new SelectList(coins_Typeslist, "coin_id", "coin_name", "0");
            ViewBag.coin_types_select = coin_types_select;
            //
            List<activity> activitylist = db1.activities.ToList();
            SelectList activity_select = new SelectList(activitylist, "activity_id", "activity_name", "0");
            ViewBag.activity_select = activity_select;
            return View();
            
        }
        public ActionResult add_out_going_bill(int customer_id, int type_id, int coin_id,int activity_id, DateTime bill_date,double tax_percent ,DateTime from_date,DateTime to_date) 
        {
            List<customer> custlist = db1.customers.ToList();
            SelectList custselect = new SelectList(custlist, "customer_id", "customer_name", "0");
            ViewBag.custselect = custselect;
            //
            List<bill_type> billtypelist = db1.bill_type.ToList();
            SelectList bill_type_select = new SelectList(billtypelist, "type_id", "type_name", "0");
            ViewBag.bill_type_select = bill_type_select;
            //
            List<coins_type> coins_Typeslist = db1.coins_type.ToList();
            SelectList coin_types_select = new SelectList(coins_Typeslist, "coin_id", "coin_name", "0");
            ViewBag.coin_types_select = coin_types_select;
            //
            List<activity> activitylist = db1.activities.ToList();
            SelectList activity_select = new SelectList(activitylist, "activity_id", "activity_name", "0");
            ViewBag.activity_select = activity_select;
            //List<service> servlist = db1.service.ToList();
            List<service> servlist = db1.service.Where(n => n.activity_id == activity_id).ToList();
            ViewBag.servlist = servlist;

            out_going_billss add_bill = new out_going_billss();
           add_bill.customer_id = customer_id;
           add_bill.type_id = type_id;
           add_bill.coin_id = coin_id;
           add_bill.activity_id = activity_id;
            add_bill.bill_date = bill_date;
            add_bill.total_before_discount = 0;
            add_bill.discount = 0;
           add_bill.total_after_discount = 0;
           add_bill.tax_percent = tax_percent;
           add_bill.tax_value = 0;
           add_bill.final_total_plus_tax = 0;
           add_bill.from_date = from_date;
           add_bill.to_date = to_date;

            out_going_billss internal_codeto_activity = db1.out_going_billss.OrderByDescending(n => n.internal_codeto_activity).Where(n => n.activity_id == activity_id).FirstOrDefault();
            int? internal_code = 0;
            if (internal_codeto_activity != null)
            { internal_code = internal_codeto_activity.internal_codeto_activity; }
                   
             if (internal_code==0) { internal_code = db1.activities.Find(activity_id).seed_number; }
            else
            {
               internal_code = internal_code + 1;
            }
         add_bill.internal_codeto_activity = (int)internal_code;
            db1.out_going_billss.Add(add_bill);
            db1.SaveChanges();
            List<out_going_bills_details> bills_Details = db1.out_going_bills_details.Include("service").Where(n => n.bill_id == add_bill.bill_id).ToList();
           ViewBag.bills_Details = bills_Details;
           return View(add_bill);

           


        }
        public ActionResult add_bill_details(int bill_id,int services_id,double amount, double unite_price)
        {
            List<customer> custlist = db1.customers.ToList();
            SelectList custselect = new SelectList(custlist, "customer_id", "customer_name", "0");
            ViewBag.custselect = custselect;
            //
            List<bill_type> billtypelist = db1.bill_type.ToList();
            SelectList bill_type_select = new SelectList(billtypelist, "type_id", "type_name", "0");
            ViewBag.bill_type_select = bill_type_select;
            //
            List<coins_type> coins_Typeslist = db1.coins_type.ToList();
            SelectList coin_types_select = new SelectList(coins_Typeslist, "coin_id", "coin_name", "0");
            ViewBag.coin_types_select = coin_types_select;
            //
            List<activity> activitylist = db1.activities.ToList();
            SelectList activity_select = new SelectList(activitylist, "activity_id", "activity_name", "0");
            ViewBag.activity_select = activity_select;
            out_going_billss bill = db1.out_going_billss.Find(bill_id);
            int activity_id = bill.activity_id;
            List<service> servlist = db1.service.Where(n => n.activity_id == activity_id).ToList();
            ViewBag.servlist = servlist;

            out_going_bills_details newbilldetail = new out_going_bills_details();
            newbilldetail.bill_id = bill_id;
            newbilldetail.services_id = services_id;
            newbilldetail.amount = amount;
            newbilldetail.unite_price = unite_price;
            newbilldetail.discount_percent = 0;
            newbilldetail.discount_value = 0;
            newbilldetail.unite_after_discount = unite_price;
            db1.out_going_bills_details.Add(newbilldetail);
            db1.SaveChanges();
            double total = amount * unite_price;
            newbilldetail.total = total;
            newbilldetail.total_discount = 0;
            newbilldetail.total_units_after_discount = total;
           
            double total_before_dis = bill.total_before_discount;
            bill.total_before_discount = total_before_dis + total;
           bill.total_after_discount = total_before_dis + total;
            double tax_value = bill.tax_value;
            double tax_percent = bill.tax_percent;
            tax_value = tax_value + (total * tax_percent);
            bill.tax_value = tax_value;
            bill.final_total_plus_tax =bill.total_before_discount + tax_value;
            db1.SaveChanges();
            List<out_going_bills_details> bills_Details = db1.out_going_bills_details.Include("service").Where(n => n.bill_id == bill_id).ToList();
            ViewBag.bills_Details = bills_Details;
            ViewBag.bill_id = bill.bill_id;
            return View(bill);
        }
        public ActionResult print_outgoingbill(int id)
        {
            out_going_billss bill = db1.out_going_billss.Find(id);
            ViewBag.bill = bill;
            List<out_going_bills_details> bills_Details = db1.out_going_bills_details.Where(n => n.bill_id == id).ToList();
            ViewBag.bills_detalils = bills_Details;
            double number = bill.final_total_plus_tax;
            decimal numberd = Convert.ToDecimal(number);
            numberd = Math.Round(numberd, 2);
            int integerpart = (int)numberd;
            decimal fractionpart = numberd % 1;
            fractionpart = fractionpart * 100;
            //string integerletters = MOJ.General.ConvertToLetters(integerpart,"جنيه","قرش");
            //string fractionalletters = MOJ.General.ConvertToLetters(fractionpart, "قرش", "جنيه");
            string integerletters = integerpart.ToString();
           string fractionalletters = fractionpart.ToString();
            ViewBag.fraction = fractionalletters;
            ViewBag.letters = integerletters;
            return View();
        }

        public ActionResult all_bills()
        {
            List<out_going_billss> outgoingbills = db1.out_going_billss.OrderByDescending(n => n.bill_date).ToList();
            ViewBag.outgoingbills = outgoingbills;
            return View();
            }
        public ActionResult update_bill(int id)
        {
            List<customer> custlist = db1.customers.ToList();
            SelectList custselect = new SelectList(custlist, "customer_id", "customer_name", "0");
            ViewBag.custselect = custselect;
            //
            List<bill_type> billtypelist = db1.bill_type.ToList();
            SelectList bill_type_select = new SelectList(billtypelist, "type_id", "type_name", "0");
            ViewBag.bill_type_select = bill_type_select;
            //
            List<coins_type> coins_Typeslist = db1.coins_type.ToList();
            SelectList coin_types_select = new SelectList(coins_Typeslist, "coin_id", "coin_name", "0");
            ViewBag.coin_types_select = coin_types_select;
            //
            List<activity> activitylist = db1.activities.ToList();
            SelectList activity_select = new SelectList(activitylist, "activity_id", "activity_name", "0");
            ViewBag.activity_select = activity_select;
            out_going_billss bill = db1.out_going_billss.Find(id);
            int activity_id = bill.activity_id;
            List<service> servlist = db1.service.Where(n => n.activity_id == activity_id).ToList();
            ViewBag.servlist = servlist;

            List<out_going_bills_details> bills_Details = db1.out_going_bills_details.Include("service").Where(n => n.bill_id ==id).ToList();
            ViewBag.bills_Details = bills_Details;
            ViewBag.bill_id = bill.bill_id;


            ViewBag.bill_date = bill.bill_date;
            return View(bill);
        }
        public ActionResult edite_bill(out_going_billss bill)
        {
            out_going_billss edited_bill = db1.out_going_billss.Find(bill.bill_id);
            edited_bill.customer_id = bill.customer_id;
            edited_bill.type_id = bill.type_id;
            edited_bill.coin_id = bill.coin_id;
            edited_bill.activity_id = bill.activity_id;
            edited_bill.bill_date = bill.bill_date;
            edited_bill.total_before_discount = bill.total_before_discount;
            edited_bill.discount = bill.discount;
            edited_bill.total_after_discount = bill.total_after_discount;
            edited_bill.tax_value = bill.tax_value;
            edited_bill.final_total_plus_tax = bill.final_total_plus_tax;
            db1.SaveChanges();
            return RedirectToAction("update_bill","out_going", new { id = bill.bill_id });
        }
        public ActionResult delete_details(int id)
        {
            out_going_bills_details bill_det = db1.out_going_bills_details.Find(id);
            int bill_id = bill_det.bill_id;
            double total = bill_det.total;
            string total_discountstr = bill_det.total_discount.ToString();
            string total_units_after_discountstr = bill_det.total_units_after_discount.ToString();
            double total_discount = 0;
            double total_units_after_discount = 0;
            if (total_discountstr != "") { total_discount = Convert.ToDouble(total_discountstr); }
            if (total_units_after_discountstr != "") { total_units_after_discount= Convert.ToDouble(total_units_after_discountstr); }
            out_going_billss bill = db1.out_going_billss.Find(bill_id);
            double total_before_dis = bill.total_before_discount;
            bill.total_before_discount = total_before_dis - total;
            bill.total_after_discount = total_before_dis - total;
            double tax_value = bill.tax_value;
            double tax_percent = bill.tax_percent;
            tax_value = tax_value -(total * tax_percent);
            bill.tax_value = tax_value;
            bill.final_total_plus_tax = bill.total_before_discount - tax_value;
            db1.out_going_bills_details.Remove(bill_det);
            db1.SaveChanges();

            return RedirectToAction("update_bill", "out_going", new { id = bill.bill_id });
        }
        public ActionResult send_decument(int id)
        {
            if (Session["token"] != null)
            {
               out_going_billss bill = db1.out_going_billss.Find(id);
                Address issur_adress = new Address();
             activity issur1 = bill.activity;
                  customer bill_customer = bill.customer;
                // //  //issur_adress
                issur_adress.branchID = issur1.branche_id;
                issur_adress.country = issur1.country;
                issur_adress.governate = issur1.governate;
                issur_adress.regionCity = issur1.regionCity;
                issur_adress.street = issur1.street;
                issur_adress.buildingNumber = issur1.buildingNumber;
                issur_adress.postalCode = issur1.postalCode;
                issur_adress.floor = issur1.floor;
                issur_adress.room = issur1.room;
                issur_adress.landmark = issur1.landmark;
                issur_adress.additionalInformation = issur1.additionalInformation;
                // //issure
                Issuer theissure = new Issuer();
                theissure.address = issur_adress;
                theissure.id = issur1.tax_registration_number;
                theissure.type = "B";
                theissure.name = issur1.activity_name;
                // //reciever_address
                Address reciever_address = new Address();
                reciever_address.branchID = bill_customer.branche_id;
                reciever_address.country = bill_customer.country;
                reciever_address.governate = bill_customer.governate;
                reciever_address.regionCity = bill_customer.regionCity;
                reciever_address.street = bill_customer.street;
                reciever_address.buildingNumber = bill_customer.buildingNumber;
                reciever_address.postalCode = bill_customer.postalCode;
                reciever_address.floor = bill_customer.floor;
                reciever_address.room = bill_customer.room;
                reciever_address.landmark = bill_customer.landmark;
                reciever_address.additionalInformation = bill_customer.additionalInformation;
                // //reciver
                // Receiver therecevire = new Receiver();
                // therecevire.name = bill_customer.customer_name;
                // therecevire.address = reciever_address;
                // therecevire.id = bill_customer.tax_regsistration_number;
                // therecevire.type = "B";
                // //invoice_line
                // List<out_going_bills_details> outgoing_items = db1.out_going_bills_details.Include("service").Where(n => n.bill_id == id).ToList();
                // List<InvoiceLine> invoice_items = new List<InvoiceLine>();
                // foreach (var item in outgoing_items)
                // {
                //     InvoiceLine newinvoiceline = new InvoiceLine();
                //     newinvoiceline.description = item.service.description;
                //     newinvoiceline.itemType = "EGS";
                //     newinvoiceline.itemCode = item.service.service_EGS;
                //     newinvoiceline.unitType = item.service.unit.unit_name;
                //     newinvoiceline.quantity = Convert.ToInt32(item.amount);
                //     newinvoiceline.internalCode = item.service.services_id.ToString();
                //     newinvoiceline.salesTotal = Convert.ToDouble(item.total);
                //     newinvoiceline.total = Math.Round(Convert.ToDouble(bill.final_total_plus_tax), 5);
                //     newinvoiceline.valueDifference = Convert.ToDouble(item.total_discount);
                //     newinvoiceline.totalTaxableFees = 0;
                //     newinvoiceline.netTotal = item.total_units_after_discount;
                //     newinvoiceline.itemsDiscount = Convert.ToInt32(item.total_discount);
                //     UnitValue newunite = new UnitValue();
                //     newunite.currencySold = item.out_going_billss.coins_type.coin_name;
                //     newunite.amountEGP = item.unite_price;
                //     newinvoiceline.unitValue = newunite;
                //     Discount newdiscount = new Discount();
                //     newdiscount.amount = 0;
                //     newdiscount.rate = 0;
                //     newinvoiceline.discount = newdiscount;
                //     List<TaxableItem> itemtaxlist = new List<TaxableItem>();
                //     TaxableItem newtax = new TaxableItem();
                //     newtax.taxType = "T1";
                //     newtax.amount = Math.Round(bill.tax_value, 5);
                //     newtax.subType = "V001";
                //     newtax.rate = 14;
                //     itemtaxlist.Add(newtax);
                //     newinvoiceline.taxableItems = itemtaxlist;
                //     invoice_items.Add(newinvoiceline);
                // }
                // List<TaxTotal> newtaxtotal = new List<TaxTotal>();
                // TaxTotal taxTotalitem = new TaxTotal();
                // taxTotalitem.taxType = "T1";
                // taxTotalitem.amount = Math.Round(bill.tax_value, 5);
                // newtaxtotal.Add(taxTotalitem);
                // List<Signature> signs = new List<Signature>();
                // Signature newsignature = new Signature();



                // List<Document> newdocument_list = new List<Document>();
                // Document newdocument = new Document();
                // newdocument.issuer = theissure;
                // newdocument.receiver = therecevire;
                // newdocument.documentType = bill.bill_type.documentType;
                // newdocument.documentTypeVersion = bill.bill_type.documentTypeVersion;
                // newdocument.dateTimeIssued = bill.bill_date;
                // newdocument.taxpayerActivityCode = "6190";
                // newdocument.internalID = Convert.ToString(bill.internal_codeto_activity);
                // newdocument.invoiceLines = invoice_items;
                // newdocument.totalDiscountAmount = Convert.ToInt32(bill.discount);
                // newdocument.totalSalesAmount = bill.total_before_discount;
                // newdocument.netAmount = bill.total_after_discount;
                // newdocument.taxTotals = newtaxtotal;
                // newdocument.totalAmount = bill.final_total_plus_tax;
                // newdocument.signatures = signs;
                // newdocument_list.Add(newdocument);
                // //sign decument
                // Root newroot = new Root();
                // newroot.documents = newdocument_list;



                // string jasonstring = JsonConvert.SerializeObject(newroot);
                //string jasondocument = JsonConvert.SerializeObject(newdocument);
                // //  // var os = Required('os');
                // ////  Process
                // //  //if (os.platform() == 'win32')
                // //  //{
                // //  //    if (os.arch() == 'ia32')
                // //  //    {
                // //  //        var chilkat = require('@chilkat/ck-node17-win-ia32');
                // //  //    }
                // //  //    else
                // //  //    {
                // //  //        var chilkat = require('@chilkat/ck-node17-win64');
                // //  //    }
                // //  //}
                // //  //else if (os.platform() == 'linux')
                // //  //{
                // //  //    if (os.arch() == 'arm')
                // //  //    {
                // //  //        var chilkat = require('@chilkat/ck-node17-arm');
                // //  //    }
                // //  //    else if (os.arch() == 'x86')
                // //  //    {
                // //  //        var chilkat = require('@chilkat/ck-node17-linux32');
                // //  //    }
                // //  //    else
                // //  //    {
                // //  //        var chilkat = require('@chilkat/ck-node17-linux64');
                // //  //    }
                // //  //}
                // //  //else if (os.platform() == 'darwin')
                // //  //{
                // //  //    var chilkat = require('@chilkat/ck-node17-macosx');
                // //  //}
                // Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
                // crypt.VerboseLogging = true;
                // Chilkat.Cert cert = new Chilkat.Cert();
                // crypt.VerboseLogging = true;
                // bool success = cert.LoadFromSmartcard("");
                // string result = "";


                // if (success != true)
                // {
                //     result = cert.LastErrorText;

                // }
                // success = crypt.SetSigningCert(cert);
                // if (success != true)
                // {
                //     result = (crypt.LastErrorText);

                // }
                // Chilkat.JsonObject cmsOptions = new Chilkat.JsonObject();
                // cmsOptions.UpdateBool("DigestData", true);
                // cmsOptions.UpdateBool("OmitAlgorithmIdNull", true);
                // cmsOptions.UpdateBool("CanonicalizeITIDA", true);
                // crypt.CmsOptions = cmsOptions.Emit();
                // crypt.CadesEnabled = true;

                // crypt.HashAlgorithm = "sha256";

                // Chilkat.JsonObject jsonSigningAttrs = new Chilkat.JsonObject();
                // jsonSigningAttrs.UpdateInt("contentType", 1);
                // jsonSigningAttrs.UpdateInt("signingTime", 1);
                // jsonSigningAttrs.UpdateInt("messageDigest", 1);
                // jsonSigningAttrs.UpdateInt("signingCertificateV2", 1);
                // crypt.SigningAttributes = jsonSigningAttrs.Emit();
                // crypt.IncludeCertChain = false;
                // crypt.Charset = "utf-8";
                //  var jsonInvoice = jasonstring;
                // crypt.EncodingMode = "base64";
                // string sigBase64 = crypt.SignStringENC(jasondocument);
                // if (crypt.LastMethodSuccess == false)
                // {
                //     result = crypt.LastErrorText;

                // }
                // result = sigBase64;
                // //  #region hint
                // newsignature.signatureType = "I";
                // newsignature.value = result;

                // signs.Add(newsignature);
                // List<Document> newdocument_list_signed = new List<Document>();
                // Document newdocument_signed = new Document();
                // newdocument_signed.issuer = theissure;
                // newdocument_signed.receiver = therecevire;
                // newdocument_signed.documentType = bill.bill_type.documentType;
                // newdocument_signed.documentTypeVersion = bill.bill_type.documentTypeVersion;
                // newdocument_signed.dateTimeIssued = bill.bill_date;
                // newdocument_signed.taxpayerActivityCode = "6190";
                // newdocument_signed.internalID = Convert.ToString(bill.internal_codeto_activity);
                // newdocument_signed.invoiceLines = invoice_items;
                // newdocument_signed.totalDiscountAmount = Convert.ToInt32(bill.discount);
                // newdocument_signed.totalSalesAmount = bill.total_before_discount;
                // newdocument_signed.netAmount = bill.total_after_discount;
                // newdocument_signed.taxTotals = newtaxtotal;
                // newdocument_signed.totalAmount = bill.final_total_plus_tax;
                // newdocument_signed.signatures = signs;
                // newdocument_list_signed.Add(newdocument_signed);

                // Root newrootwithesign = new Root();
                // newrootwithesign.documents = newdocument_list_signed;



                // string jasonstringwithsign = JsonConvert.SerializeObject(newrootwithesign);
                // HttpClient client = new HttpClient();

                // client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Session["token"].ToString());



                // client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");
                // var request = new HttpRequestMessage(HttpMethod.Post, "https://api.invoicing.eta.gov.eg/api/v1/documentsubmissions");


                // request.Content = new StringContent(jasonstringwithsign, System.Text.Encoding.UTF8, "application/json");
                // var response = await client.SendAsync(request);

                // string stauscode = response.StatusCode.ToString();
                // string tokestring = await response.Content.ReadAsStringAsync();
                // ViewBag.token = tokestring;
                // ViewBag.stauscode = stauscode;
                //  #endregion
                //    var json = new Chilkat.JsonObject();
                // json.Load(jsonInvoice);
                //  json.UpdateString("signatures[0].signatureType", "I");
                //  json.UpdateString("signatures[0].value", sigBase64);
                //  json.EmitCompact = true;
                //  var sbToSend = new Chilkat.StringBuilder();
                //  sbToSend.Append("{\"documents\":[");
                //  sbToSend.Append(json.Emit());
                //  sbToSend.Append("]}");
                //  var clientId = issur1.client_id;

                //  var clientSecretKey = issur1.secret_id;

                //  var http = new Chilkat.Http();
                //  http.Login = clientId;
                //  http.Password = clientSecretKey;
                //  http.BasicAuth = true;
                //  var req = new Chilkat.HttpRequest();
                //  req.HttpVerb = "POST";
                //  req.Path = "/connect/token";
                //  req.ContentType = "application/x-www-form-urlencoded";
                //  req.AddParam("grant_type", "client_credentials");
                //  req.AddHeader("Connection", "close");

                //  http.Accept = "application/json";
                //  var resp = http.PostUrlEncoded("https://id.eta.gov.eg/connect/token", req);
                //  string lasteror = "";
                //  if (http.LastMethodSuccess == false)
                //  {
                //      lasteror = http.LastErrorText;

                //  }

                //  http.CloseAllConnections();

                // string statcode= resp.StatusCode.ToString();

                //  string reponce_body=resp.BodyStr;
                //  string suc = "";
                //  if (resp.StatusCode != 200)
                //  {
                //      suc="Failed.";


                //  }

                //  var jsonToken = new Chilkat.JsonObject();
                //  success = jsonToken.Load(resp.BodyStr);

                //  var accessToken = jsonToken.StringOf("access_token");
                // string acess=  accessToken;
                //  http.Login = "";
                //  http.Password = "";
                //  http.BasicAuth = false;
                //  http.AuthToken = accessToken;

                //  //resp = http.PostJson2("https://api.invoicing.eta.gov.eg/api/v1/documentsubmissions", "application/json; charset=utf-8", sbToSend.GetAsString());
                //  //if (http.LastMethodSuccess == false)
                //  //{
                //  //    lasteror = http.LastErrorText;

                //  //}

                //  statcode = resp.StatusCode.ToString();

                //  reponce_body=resp.BodyStr;
                //  ViewBag.lasteror = lasteror;
                //  ViewBag.statcode = statcode;
                //  ViewBag.reponce_body = reponce_body;
                //  ViewBag.suc = suc;
                //  ViewBag.result = sbToSend.GetAsString();

                Chilkat.Global glob = new Chilkat.Global();
                bool success1 = glob.UnlockBundle("Anything for 30-day trial");
                string globstr = "";
                if (success1 != true)
                {
                    globstr = glob.LastErrorText;
                    //return;
                }
                int status = glob.UnlockStatus;
                string glop_mode = "";
                if (status == 2)
                {
                    glop_mode="Unlocked using purchased unlock code.";
                }
                else
                {
                    glop_mode = "Unlocked in trial mode.";
                }
                var crypt = new   Chilkat.Crypt2();
                crypt.VerboseLogging = true;
                Chilkat.Cert cert = new Chilkat.Cert();
                crypt.VerboseLogging = true;
                bool success = cert.LoadFromSmartcard("");
                string result = "";


                if (success != true)
                {
                    result = cert.LastErrorText;

                }
                success = crypt.SetSigningCert(cert);
                if (success != true)
                {
                    result = (crypt.LastErrorText);

                }
                var cmsOptions = new Chilkat.JsonObject();
                cmsOptions.UpdateBool("DigestData", true);
                cmsOptions.UpdateBool("OmitAlgorithmIdNull", true);
                cmsOptions.UpdateBool("CanonicalizeITIDA", true);

                crypt.CmsOptions = cmsOptions.Emit();
                crypt.CadesEnabled = true;

                crypt.HashAlgorithm = "sha256";

                var jsonSigningAttrs = new Chilkat.JsonObject();
                jsonSigningAttrs.UpdateInt("contentType", 1);
                jsonSigningAttrs.UpdateInt("signingTime", 1);
                jsonSigningAttrs.UpdateInt("messageDigest", 1);
                jsonSigningAttrs.UpdateInt("signingCertificateV2", 1);
                crypt.SigningAttributes = jsonSigningAttrs.Emit();
                crypt.IncludeCertChain = false;
                var json = new Chilkat.JsonObject();
                json.UpdateString("issuer.address.branchID", issur1.branche_id);
                json.UpdateString("issuer.address.country", issur1.country);
                json.UpdateString("issuer.address.regionCity", issur1.regionCity);
                json.UpdateString("issuer.address.postalCode", issur1.postalCode);
                json.UpdateString("issuer.address.buildingNumber", issur1.buildingNumber);
                json.UpdateString("issuer.address.street", issur1.street);
                json.UpdateString("issuer.address.governate", issur1.governate);
                json.UpdateString("issuer.type", "B");
                json.UpdateString("issuer.id", issur1.tax_registration_number);
                json.UpdateString("issuer.name", issur1.activity_name);
                json.UpdateString("receiver.address.country", bill_customer.country);
                json.UpdateString("receiver.address.regionCity", bill_customer.regionCity);
                json.UpdateString("receiver.address.postalCode", bill_customer.postalCode);
                json.UpdateString("receiver.address.buildingNumber", bill_customer.buildingNumber);
                json.UpdateString("receiver.address.street", bill_customer.street);
                json.UpdateString("receiver.address.governate", bill_customer.governate);
                json.UpdateString("receiver.type", "B");
                json.UpdateString("receiver.id", bill_customer.tax_regsistration_number);
                json.UpdateString("receiver.name", bill_customer.customer_name);
                json.UpdateString("documentType", bill.bill_type.documentType);
                json.UpdateString("documentTypeVersion", bill.bill_type.documentTypeVersion);
                Chilkat.CkDateTime dateTime = new Chilkat.CkDateTime();
                dateTime.SetFromCurrentSystemTime();
                // json.UpdateString("dateTimeIssued", "2022-10-18T20:35:00Z");
                json.UpdateString("dateTimeIssued", bill.bill_date.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'"));
                json.UpdateString("taxpayerActivityCode", "6190");
                json.UpdateString("internalID", Convert.ToString(bill.internal_codeto_activity));
                json.UpdateString("purchaseOrderReference", "");
                json.UpdateString("salesOrderReference", "");
                json.UpdateString("payment.bankName", "");
                json.UpdateString("payment.bankAddress", "");
                json.UpdateString("payment.bankAccountNo", "");
                json.UpdateString("payment.bankAccountIBAN", "");
                json.UpdateString("payment.swiftCode", "");
                json.UpdateString("payment.terms", "");
                json.UpdateString("delivery.approach", "");
                json.UpdateString("delivery.packaging", "");
                json.UpdateString("delivery.dateValidity", "");
                json.UpdateString("delivery.exportPort", "");
                json.UpdateString("delivery.countryOfOrigin", "EG");
                json.UpdateInt("delivery.grossWeight", 0);
                json.UpdateInt("delivery.netWeight", 0);
                json.UpdateString("delivery.terms", "");
                List<out_going_bills_details> outgoing_items = db1.out_going_bills_details.Include("service").Where(n => n.bill_id == id).ToList();
                List<InvoiceLine> invoice_items = new List<InvoiceLine>();
                int i = 0;
                foreach (var item in outgoing_items)
                {
                    string discripe= "وذلك نظير" + " " + item.service.service_discription + " " + " عن الفترة من" + " " + bill.from_date.ToShortDateString() + " " + "إلى" + " " + bill.to_date.ToShortDateString();
                    
                    json.UpdateString("invoiceLines['" + i + "'].description", discripe);
                    json.UpdateString("invoiceLines['" + i + "'].itemType", "EGS");
                    json.UpdateString("invoiceLines['" + i + "'].itemCode", item.service.service_EGS);
                    json.UpdateString("invoiceLines['" + i + "'].unitType", item.service.unit.unit_name);
                    json.UpdateNumber("invoiceLines['" + i + "'].quantity", item.amount.ToString());
                    json.UpdateString("invoiceLines['" + i + "'].unitValue.currencySold", item.out_going_billss.coins_type.coin_name);
                    json.UpdateNumber("invoiceLines['" + i + "'].unitValue.amountEGP", item.unite_price.ToString());
                    // json.UpdateInt("invoiceLines[0].unitValue.amountSold", 0);
                    // json.UpdateInt("invoiceLines[0].unitValue.currencyExchangeRate", 0);
                    json.UpdateNumber("invoiceLines['" + i + "'].salesTotal", item.total.ToString());
                    json.UpdateNumber("invoiceLines['" + i + "'].total", Math.Round(Convert.ToDouble(bill.final_total_plus_tax), 5).ToString());
                    json.UpdateInt("invoiceLines['" + i + "'].valueDifference", Convert.ToInt32(item.total_discount));
                    json.UpdateInt("invoiceLines['" + i + "'].totalTaxableFees", 0);
                    json.UpdateNumber("invoiceLines['" + i + "'].netTotal", item.total_units_after_discount.ToString());
                    json.UpdateInt("invoiceLines['" + i + "'].itemsDiscount", Convert.ToInt32(item.total_discount));
                    json.UpdateNumber("invoiceLines['" + i + "'].discount.rate", "0");
                    json.UpdateNumber("invoiceLines['" + i + "'].discount.amount", "0");
                    json.UpdateString("invoiceLines['" + i + "'].taxableItems[0].taxType", "T1");
                    json.UpdateNumber("invoiceLines['" + i + "'].taxableItems[0].amount", Math.Round(bill.tax_value, 5).ToString());
                    json.UpdateString("invoiceLines['" + i + "'].taxableItems[0].subType", "V001");
                    json.UpdateNumber("invoiceLines['" + i + "'].taxableItems[0].rate", "14.00");
                    json.UpdateString("invoiceLines['" + i + "'].internalCode", item.service.services_id.ToString());
                    i++;
                }

                json.UpdateNumber("totalSalesAmount", bill.total_before_discount.ToString());
                json.UpdateNumber("totalDiscountAmount", Convert.ToInt32(bill.discount).ToString());
                json.UpdateNumber("netAmount", bill.total_after_discount.ToString());
                json.UpdateString("taxTotals[0].taxType", "T1");
                json.UpdateNumber("taxTotals[0].amount", Math.Round(bill.tax_value, 5).ToString());
                json.UpdateInt("extraDiscountAmount", 0);
                json.UpdateInt("totalItemsDiscountAmount", 0);
                json.UpdateNumber("totalAmount", bill.final_total_plus_tax.ToString());

                json.EmitCompact = true;
                var jsonToSign = json.Emit();
                crypt.EncodingMode = "base64";
                crypt.Charset = "utf-8";
                var sigBase64 = crypt.SignStringENC(jsonToSign);
                string signresult = "";
                if (crypt.LastMethodSuccess == false)
                {
                    signresult = crypt.LastErrorText;

                }
                string Base64_signature = sigBase64;
                json.UpdateString("signatures[0].signatureType", "I");
                json.UpdateString("signatures[0].value", sigBase64);
                var sbToSend = new Chilkat.StringBuilder();
                sbToSend.Append("{\"documents\":[");
                sbToSend.Append(json.Emit());
                sbToSend.Append("]}");

                var clientId = issur1.client_id;

                var clientSecretKey = issur1.secret_id;
                var http = new Chilkat.Http();
                http.Login = clientId;
                http.Password = clientSecretKey;
                http.BasicAuth = true;


                var req = new Chilkat.HttpRequest();
                req.HttpVerb = "POST";
                req.Path = "/connect/token";
                req.ContentType = "application/x-www-form-urlencoded";
                req.AddParam("grant_type", "client_credentials");
                req.AddHeader("Connection", "close");

                http.Accept = "application/json";
                var resp = http.PostUrlEncoded("https://id.eta.gov.eg/connect/token", req);
                string resp_result = "";
                if (http.LastMethodSuccess == false)
                {
                    resp_result = http.LastErrorText;

                }
                http.CloseAllConnections();

                string Response_status_code = resp.StatusCode.ToString();
                string Response_body = resp.BodyStr;

                string token_result = "";
                if (resp.StatusCode != 200)
                {
                    token_result = "Failed.";


                }

                var jsonToken = new Chilkat.JsonObject();
                success = jsonToken.Load(resp.BodyStr);

                var accessToken = jsonToken.StringOf("access_token");
                string access_tokenstr = accessToken;
                http.Login = "";
                http.Password = "";
                http.BasicAuth = false;
                http.AuthToken = accessToken;

                resp = http.PostJson2("https://api.invoicing.eta.gov.eg/api/v1/documentsubmissions", "application/json; charset=utf-8", sbToSend.GetAsString());
                string resp_res = "";
                if (http.LastMethodSuccess == false)
                {
                    resp_res = http.LastErrorText;

                }
                string post_Response_status_code = resp.StatusCode.ToString();
                string post_responce_body = resp.BodyStr;
                ViewBag.globstr = globstr;
                ViewBag.result = result;
                ViewBag.signresult = signresult;
                ViewBag.Base64_signature = Base64_signature;
                ViewBag.resp_result = resp_result;
                ViewBag.Response_status_code = Response_status_code;
                ViewBag.Response_body = Response_body;
                ViewBag.token_result = token_result;
                ViewBag.resp_res = resp_res;
                ViewBag.post_Response_status_code = post_Response_status_code;
                ViewBag.post_responce_body = post_responce_body;
                //var payload = JObject.Parse(post_responce_body);
                //var uuid = payload.Value<string>("uuid");
                //string uuidstring = uuid.ToString();
                //ViewBag.uuidstring = uuidstring;
                //bill.uuid = uuidstring;
                ViewBag.glop_mod = glop_mode;
                db1.SaveChanges();
                return View();
            }
            else { return RedirectToAction("loginpage", "login"); }
        }
    }
}