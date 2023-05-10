namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public service()
        {
            out_going_bills_details = new HashSet<out_going_bills_details>();
        }

        [Key]
        [Display(Name = "كود الخدمة")]

        public int services_id { get; set; }
        [Display(Name = "كود النشاط")]

        [Required(ErrorMessage = "*")]
        public int activity_id { get; set; }

        [Display(Name = "إسم الخدمة")]

        [Required(ErrorMessage = "*")]
        [StringLength(50)]

        public string service_name { get; set; }

        [Display(Name = "GPC code")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string service_GPC { get; set; }
        [Display(Name = " EGS code")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string service_EGS { get; set; }
        [Display(Name = " الوصف التفصيلى")]
        [Required(ErrorMessage = "*")]
        public string service_discription { get; set; }
        [Display(Name = " الوحدة")]
        public int unite_id { get; set; }
       
        [Display(Name = " نوع التكويد")]
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string codeType { get; set; }
        [Display(Name = " الإسم بالإنجليزية")]
        [Required(ErrorMessage = "*")]
       
        public string codeName { get; set; }
        [Display(Name = " نشط من")]
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "*")]
        public DateTime activeFrom { get; set; }
        [Display(Name = " نشط إلى")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime activeTo { get; set; }
        [Display(Name = " الوصف بالإنجليزية")]
        [Required(ErrorMessage = "*")]

        public string description { get; set; }
        public virtual activity activity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<out_going_bills_details> out_going_bills_details { get; set; }

        public virtual unit unit { get; set; }
    }
}
