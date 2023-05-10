namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class out_going_billss
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public out_going_billss()
        {
            out_going_bills_details = new HashSet<out_going_bills_details>();
        }

        [Key]
        [Display(Name = "كود الفاتورة")]
        public int bill_id { get; set; }
        [Display(Name = " العميل")]
        public int customer_id { get; set; }
        [Display(Name = "نوع الفاتورة")]
        public int type_id { get; set; }
        [Display(Name = "العملة")]
        public int coin_id { get; set; }
        [Display(Name = "الشركة")]
        public int activity_id { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "تاريخ الاصدار")]
        public DateTime bill_date { get; set; }
        [Display(Name = "الإجمالى قبل الخصم")]
        public double total_before_discount { get; set; }
        [Display(Name = "الخصم")]
        public double discount { get; set; }
        [Display(Name = "الإجمالى بعد الخصم")]
        public double total_after_discount { get; set; }
        [Display(Name = "نسبة الضريبة")]
        public double tax_percent { get; set; }
        [Display(Name = "قيمة الضريبة")]
        public double tax_value { get; set; }
        [Display(Name = "الإجمالى بعد الضريبة")]
        public double final_total_plus_tax { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "من تاريخ")]
        public DateTime from_date { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "إلى  تاريخ")]
        public DateTime to_date { get; set; }
        [Display(Name = "كود الفاتورة الداخلى")]
        public int internal_codeto_activity { get; set; }
        public virtual activity activity { get; set; }

        public virtual bill_type bill_type { get; set; }

        public virtual coins_type coins_type { get; set; }

        public virtual customer customer { get; set; }
        [Display(Name = "UUID")]
        public string uuid { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<out_going_bills_details> out_going_bills_details { get; set; }
    }
}
