using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Security.Cryptography.Xml;

namespace WebApplication1.Controllers
{
    public class accesstokenController : Controller
    {
        // GET: accesstoken
        public ActionResult digital_signature()
        {

            X509Store store = new X509Store(StoreLocation.CurrentUser);
            store.Open(OpenFlags.ReadOnly);
            X509CertificateCollection certificates = X509Certificate2UI.SelectFromCollection(store.Certificates,
                                                                                "الشهادات المعروفة",
                                                                                "الرجاء تحديد الشهادة التي تريد التوقيع بها",
                                                                                X509SelectionFlag.SingleSelection
                                                                                );
            store.Close();

            X509Certificate2 certificate = null;
            string result = "";
            if (certificates.Count != 0)
            {
                //The selected certificate
                certificate = (X509Certificate2)certificates[0];
            }
            else
            {
                //The user didn't select a certificate
                result= "ألغى المستخدم اختيار شهادة";
            }
            //Check certificate's atributes to identify the type of certificate (censored)
            if (certificate.Issuer != "CN=............................., OU=................., O=..., C=US")
            {
                //The selected certificate is not of the needed type
               result = "الشهادة المحددة لا تتوافق مع رمز مميز ...";
            }
            //Check if the certificate is issued to the current user
            //if (!certificate.Subject.ToUpper().Contains(("E=" + pUserADLogin + "@censoreddomain.com").ToUpper()))
            //{
            //    return "El certificado seleccionado no corresponde al usuario actual";
            //}
            //Check if the token is currently plugged in
            XmlDocument xmlDoc = new XmlDocument();
            XmlElement element = xmlDoc.CreateElement("Content", SignedXml.XmlDsigNamespaceUrl.ToString());
            element.InnerText = "comodin";
            xmlDoc.AppendChild(element);
            SignedXml signedXml = new SignedXml();
            try
            {
                signedXml.SigningKey = certificate.PrivateKey;
            }
            catch
            {
                //USB Token is not plugged in
               result= "الرمز المميز غير متصل بالجهاز";
            }
            DataObject dataObject = new DataObject();
            dataObject.Data = xmlDoc.ChildNodes;
            dataObject.Id = "CONTENT";
            signedXml.AddObject(dataObject);
            Reference reference = new Reference();
            reference.Uri = "#CONTENT";
            signedXml.AddReference(reference);
            //Attempt to sign the data. The user will be prompted to enter his PIN
            try
            {
                signedXml.ComputeSignature();
            }
            catch
            {
                //User didn't enter the correct PIN
               result= "حدث خطأ أثناء تأكيد هوية المستخدم";
            }
            //The user has signed with the correct token
          string  SerialNumber = certificate.SerialNumber;
            string SignatureAlgorithm = certificate.SignatureAlgorithm.Value;
            string FriendlyName = certificate.FriendlyName;
            string m = certificate.Subject;
            string x = certificate.Thumbprint;
            ViewBag.SerialNumber = SerialNumber;
            ViewBag.SignatureAlgorithm = SignatureAlgorithm;
            ViewBag.FriendlyName = FriendlyName;
            ViewBag.x = x;
            return View();
        }
    }
}