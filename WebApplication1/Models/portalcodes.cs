using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CodeCategorization
    {
        public Level1 level1 { get; set; }
        public Level2 level2 { get; set; }
        public Level3 level3 { get; set; }
        public Level4 level4 { get; set; }
    }

    public class Level1
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class Level2
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class Level3
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class Level4
    {
        public int id { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class Metadata
    {
        public int totalPages { get; set; }
        public int totalCount { get; set; }
    }

    public class OwnerTaxpayer
    {
        public string rin { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class RequesterTaxpayer
    {
        public string rin { get; set; }
        public string name { get; set; }
        public string nameAr { get; set; }
    }

    public class Result
    {
        public int codeUsageRequestID { get; set; }
        public string codeTypeName { get; set; }
        public int codeID { get; set; }
        public string itemCode { get; set; }
        public string codeNamePrimaryLang { get; set; }
        public string codeNameSecondaryLang { get; set; }
        public string descriptionPrimaryLang { get; set; }
        public string descriptionSecondaryLang { get; set; }
        public int parentCodeID { get; set; }
        public string parentItemCode { get; set; }
        public string parentCodeNamePrimaryLang { get; set; }
        public string parentCodeNameSecondaryLang { get; set; }
        public string parentLevelName { get; set; }
        public string levelName { get; set; }
        public DateTime requestCreationDateTimeUtc { get; set; }
        public DateTime codeCreationDateTimeUtc { get; set; }
        public DateTime activeFrom { get; set; }
        public DateTime activeTo { get; set; }
        public bool active { get; set; }
        public string status { get; set; }
        public string statusReason { get; set; }
        public OwnerTaxpayer ownerTaxpayer { get; set; }
        public RequesterTaxpayer requesterTaxpayer { get; set; }
        public CodeCategorization codeCategorization { get; set; }
    }

    public class portalcodes
    {
        public List<Result> result { get; set; }
        public Metadata metadata { get; set; }
    }


    public class codetype
    {
        public string code_type_name { get; set; }
    }
}