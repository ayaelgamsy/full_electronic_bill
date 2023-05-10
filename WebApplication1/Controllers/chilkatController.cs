using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Chilkat;

namespace WebApplication1.Controllers
{
    public class chilkatController : Controller
    {
        // GET: chilkat
        public ActionResult chilkat_mono()
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2();
            Chilkat.Cert cert = new Chilkat.Cert();
            bool success = cert.LoadFromSmartcard("");
            string result = "";


            if (success != true)
            {
             result=  cert.LastErrorText;
                
            }
            success = crypt.SetSigningCert(cert);
            if (success != true)
            {
               result=(crypt.LastErrorText);
              
            }
            Chilkat.JsonObject cmsOptions = new Chilkat.JsonObject();
            cmsOptions.UpdateBool("DigestData", true);
            cmsOptions.UpdateBool("OmitAlgorithmIdNull", true);
            crypt.CmsOptions = cmsOptions.Emit();
            crypt.CadesEnabled = true;

            crypt.HashAlgorithm = "sha256";

            Chilkat.JsonObject jsonSigningAttrs = new Chilkat.JsonObject();
            jsonSigningAttrs.UpdateInt("contentType", 1);
            jsonSigningAttrs.UpdateInt("signingTime", 1);
            jsonSigningAttrs.UpdateInt("messageDigest", 1);
            jsonSigningAttrs.UpdateInt("signingCertificateV2", 1);
            crypt.SigningAttributes = jsonSigningAttrs.Emit();
            crypt.IncludeCertChain = false;
            crypt.Charset = "utf-8";
            string textToSign = "\"issuer\"\"address\"\"branchID\"\"0\"\"country\"\"EG\"\"regionCity...";
            crypt.EncodingMode = "base64";
            string sigBase64 = crypt.SignStringENC(textToSign);
            if (crypt.LastMethodSuccess == false)
            {
               result=crypt.LastErrorText;
               
            }
            result = sigBase64;
            ViewBag.result = result;
            return View();
        }
    }
}