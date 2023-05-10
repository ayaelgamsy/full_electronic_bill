namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class out_going_bills_details
    {
        [Key]
        [Display(Name = "مسلسل")]
        public int out_details_id { get; set; }
        [Display(Name = "رقم الفاتورة")]
        public int bill_id { get; set; }
        [Display(Name = "الخدمة")]
        public int services_id { get; set; }
        [Display(Name = "الكمية")]
        public double amount { get; set; }
        [Display(Name = "سعر الوحدة")]
        public double unite_price { get; set; }
        [Display(Name = "نسبة الخصم")]
        public double discount_percent { get; set; }
        [Display(Name = "قيمة الخصم")]
        public double discount_value { get; set; }
        [Display(Name = "الوحدة بعد الخصم")]
        public double unite_after_discount { get; set; }
        [Display(Name = "الإجمالى ")]
        public double total { get; set; }
        [Display(Name = "الخصم")]
        public double? total_discount { get; set; }
        [Display(Name = "الإجمالى بعد الخصم")]
        public double? total_units_after_discount { get; set; }

        public virtual out_going_billss out_going_billss { get; set; }

        public virtual service service { get; set; }
    }
}