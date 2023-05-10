using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class invoicingtoken
    {
        public string access_token { get; set; }
        public string tokent_type { get; set; }
        public string expires_in { get; set; }
        public string refresh_token { get; set; }
    }
}