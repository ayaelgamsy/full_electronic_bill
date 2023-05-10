namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class custumers_activity
    {
        [Display(Name = "كود")]
        [Required(ErrorMessage = "*")]
        [Key]
        public int relation_id { get; set; }
        [Display(Name = "العميل")]
        [Required(ErrorMessage = "*")]
        public int customer_id { get; set; }
        [Display(Name = "النشاط")]
        [Required(ErrorMessage = "*")]
        public int activity_id { get; set; }

        [Display(Name = "ملاحظات")]
        [Required(ErrorMessage = "*")]
        public string nots { get; set; }

        public virtual activity activity { get; set; }

        public virtual customer customer { get; set; }
    }
}