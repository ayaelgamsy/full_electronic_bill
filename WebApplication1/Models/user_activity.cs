

namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("user_activity")]
    public partial class user_activity
    {
        [Key]
        [Display(Name = "كود نشاط المستخدم")]
        public int Id { get; set; }
        [Required(ErrorMessage = "*")]

        [Display(Name = "المستخدم")]
        public int user_id { get; set; }
        [Required(ErrorMessage = "*")]

        [Display(Name = "النشاط")]
        public int activity_id { get; set; }

        public virtual activity activity { get; set; }

        public virtual users user { get; set; }
    }
}