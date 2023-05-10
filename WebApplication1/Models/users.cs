namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    [Table("users")]
    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        [Key]
        [Display(Name = "كود المستخدم")]
        public int user_id { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [Display(Name = "اسم  المستخدم")]
        public string user_name { get; set; }
        [Required(ErrorMessage = "*")]
        [StringLength(50)]
        [Display(Name = "كلمة المرور")]
        public string password { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<user_activity> user_activity { get; set; }
    }
}