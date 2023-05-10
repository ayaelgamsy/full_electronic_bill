namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("activity")]
    public partial class activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public activity()
        {
            deduction_bills = new HashSet<deduction_bills>();
            custumers_activity = new HashSet<custumers_activity>();
            out_going_billss = new HashSet<out_going_billss>();
            service = new HashSet<service>();
            user_activity = new HashSet<user_activity>();
        }

        [Key]
        [Display(Name = "كود النشاط")]
        public int activity_id { get; set; }

        [Required(ErrorMessage = "*")]
      
        [Display(Name = "اسم  النشاط")]
        public string activity_name { get; set; }
        [Display(Name = "رقم التسجيل الضريبى")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string tax_registration_number { get; set; }
        [Display(Name = "رقم البطاقة الضريبية")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string tax_card { get; set; }
        [Display(Name = "رقم السحل التجارى")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string commercial_register { get; set; }
        [Display(Name = "رقم الهاتف")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string phone_number { get; set; }
        [Display(Name = "اسم المدير")]
        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string manger_name { get; set; }
        [Display(Name = "العنوان")]
        [Required(ErrorMessage = "*")]
        
        public string address { get; set; }
        [Display(Name = "البريد الالكترونى")]
        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string email { get; set; }
        [Display(Name = "رقم التسجيل الداخلى")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string internal_numberofcomp { get; set; }
        [Display(Name = "بداية مسلسل الفواتير")]

      
        public int? seed_number { get; set; }
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
        [Display(Name = "Client ID")]
        public string client_id { get; set; }
        [Display(Name = "Client Secret")]
        public string secret_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<custumers_activity> custumers_activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<out_going_billss> out_going_billss { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<service> service { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deduction_bills> deduction_bills { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_activity> user_activity { get; set; }
    }
}
