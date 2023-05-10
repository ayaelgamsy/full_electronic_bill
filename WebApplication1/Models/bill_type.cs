namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class bill_type
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public bill_type()
        {
            out_going_billss = new HashSet<out_going_billss>();
        }

        [Key]
        [Display(Name = "كود النوع")]

        [Required(ErrorMessage = "*")]
        public int type_id { get; set; }

        [Display(Name = "إسم النوع")]

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string type_name { get; set; }
        [Display(Name = "documentType")]

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string documentType { get; set; }
        [Display(Name = "documentTypeVersion")]

        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        public string documentTypeVersion { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<out_going_billss> out_going_billss { get; set; }
    }
}