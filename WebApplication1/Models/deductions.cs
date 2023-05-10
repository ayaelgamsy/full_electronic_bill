using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace WebApplication1.Models
{
  
    public class deductions

    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public deductions()
        {
            deduction_bill_details = new HashSet<deduction_bill_details>();
        }
        [Display(Name = "كود الإستقطاع")]
        [Key]
        public int deduction_id { get; set; }

        [Display(Name = "إسم الإستقطاع")]
        [Required(ErrorMessage = "*")]
        [StringLength(500)]
        public string deduction_name { get; set; }

        [Display(Name = "قابل للإسترجاع")]
        
        
        public bool returnable { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<deduction_bill_details> deduction_bill_details { get; set; }
    }



}
