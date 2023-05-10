namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public customer()
        {
            out_going_billss = new HashSet<out_going_billss>();
            custumers_activity = new HashSet<custumers_activity>();
            deduction_bills = new HashSet<deduction_bills>();
        }
        [Display(Name = "كود العميل")]
        [Key]
        public int customer_id { get; set; }

        [Display(Name = "إسم العميل")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string customer_name { get; set; }

        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string address { get; set; }

        [Display(Name = "الهاتف")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string phone { get; set; }

        [Display(Name = "رقم التسجيل الضريبى")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string tax_regsistration_number { get; set; }
        [Display(Name = "إسم المدير")]
        
        [StringLength(100)]
        public string manger_name { get; set; }
        [Display(Name = "إسم نائب المدير")]

        [StringLength(100)]
        public string manger_assistant { get; set; }

        [Display(Name = "الفرع")]
        [StringLength(50)]

        public string branche_id { get; set; }
        [Display(Name = "الدولة")]
        public string country { get; set; }
        [Display(Name = "المحافظة")]
        public string governate { get; set; }
        [Display(Name = "المدينة/المنطقة")]
        public string regionCity { get; set; }
        [Display(Name = "الشارع")]
        public string street { get; set; }
        [Display(Name = "رقم المبنى")]
        public string buildingNumber { get; set; }
        [Display(Name = "الرقم البريدى")]
        public string postalCode { get; set; }
        [Display(Name = "الطابق")]
        public string floor { get; set; }
        [Display(Name = "الغرفة")]
        public string room { get; set; }
        [Display(Name = "علامة مميزة")]
        public string landmark { get; set; }
        [Display(Name = "معلومة إضافية")]
        public string additionalInformation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<out_going_billss> out_going_billss { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custumers_activity> custumers_activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deduction_bills> deduction_bills { get; set; }
    }
}
