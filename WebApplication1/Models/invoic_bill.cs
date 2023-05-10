using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
   
        public class FreezeStatus
        {
            public bool frozen { get; set; }
            public object type { get; set; }
            public object actionDate { get; set; }
            public object auCode { get; set; }
            public object auName { get; set; }
        }

        public class Metadatabill
        {
            public int totalPages { get; set; }
            public int totalCount { get; set; }
        }

        public class Resultbill
        {
            public string publicUrl { get; set; }
            public string uuid { get; set; }
            public string submissionUUID { get; set; }
            public string longId { get; set; }
            public string internalId { get; set; }
            public string typeName { get; set; }
            public string documentTypeNamePrimaryLang { get; set; }
            public string documentTypeNameSecondaryLang { get; set; }
            public string typeVersionName { get; set; }
            public string issuerId { get; set; }
            public string issuerName { get; set; }
            public string receiverId { get; set; }
            public string receiverName { get; set; }
            public DateTime dateTimeIssued { get; set; }
            public DateTime dateTimeReceived { get; set; }
            public double totalSales { get; set; }
            public double totalDiscount { get; set; }
            public double netAmount { get; set; }
            public double total { get; set; }
            public int maxPercision { get; set; }
            public object invoiceLineItemCodes { get; set; }
            public DateTime? cancelRequestDate { get; set; }
            public object rejectRequestDate { get; set; }
            public DateTime? cancelRequestDelayedDate { get; set; }
            public object rejectRequestDelayedDate { get; set; }
            public object declineCancelRequestDate { get; set; }
            public object declineRejectRequestDate { get; set; }
            public string documentStatusReason { get; set; }
            public string status { get; set; }
            public string createdByUserId { get; set; }
            public FreezeStatus freezeStatus { get; set; }
        }

        public class invoic_bill
    {
            public List<Resultbill> result { get; set; }
        public Metadatabill metadata { get; set; }
        }

    
}