namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tax_types
    {
        [Key]
        [Display(Name = "كود الضريبة")]
        public int tax_id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "اسم الضريبة")]
        public string tax_name { get; set; }
        [StringLength(50)]
        [Display(Name = "الكود الضريبى")]
        public string tax_name_code { get; set; }
        [StringLength(50)]
        [Display(Name = "كود تصنيف الضريبة")]
        public string tax_cat_system_id { get; set; }
        [Required]
        [Display(Name = "النسبة الضريبية")]
        public double percent { get; set; }
    }
}
