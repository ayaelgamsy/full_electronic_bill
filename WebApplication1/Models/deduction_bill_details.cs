namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class deduction_bill_details
    {
        [Key]
        public int deduction_det_id { get; set; }

        public int deduction_bill_id { get; set; }

        public int deduction_id { get; set; }

        public double value { get; set; }

        public virtual deduction_bills deduction_bills { get; set; }

        public virtual deductions deductions { get; set; }
    }
}
