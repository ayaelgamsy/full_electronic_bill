namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class deduction_bills
    {
        public deduction_bills()
        {
            deduction_bill_details = new HashSet<deduction_bill_details>();
        }
        [Key]
        public int deduction_bill_id { get; set; }

        public DateTime date { get; set; }

        public int bill_code { get; set; }

        public int customer_id { get; set; }
        public int activity_id { get; set; }
        [Required]
        public string decument_number { get; set; }

        public virtual activity activity { get; set; }

        public virtual customer customer { get; set; }
      
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deduction_bill_details> deduction_bill_details { get; set; }
    }
}