using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace WebApplication1.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<activity> activities { get; set; }
        public virtual DbSet<bill_type> bill_type { get; set; }
        public virtual DbSet<coins_type> coins_type { get; set; }
        public virtual DbSet<customer> customers { get; set; }
        public virtual DbSet<custumers_activity> custumers_activity { get; set; }
        public virtual DbSet<out_going_bills_details> out_going_bills_details { get; set; }
        public virtual DbSet<out_going_billss> out_going_billss { get; set; }
        public virtual DbSet<service> service { get; set; }
        public virtual DbSet<tax_types> tax_types { get; set; }
        public virtual DbSet<unit> units { get; set; }
        public virtual DbSet<users> users { get; set; }
        public virtual DbSet<user_activity> user_activity { get; set; }
        public virtual DbSet<deductions> deductions { get; set; }
        public virtual DbSet<deduction_bill_details> deduction_bill_details { get; set; }
        public virtual DbSet<deduction_bills> deduction_bills { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<activity>()
                .HasMany(e => e.custumers_activity)
                .WithRequired(e => e.activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<activity>()
                .HasMany(e => e.out_going_billss)
                .WithRequired(e => e.activity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<activity>()
                .HasMany(e => e.service)
                .WithRequired(e => e.activity)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<activity>()
               .HasMany(e => e.user_activity)
               .WithRequired(e => e.activity)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<bill_type>()
                .HasMany(e => e.out_going_billss)
                .WithRequired(e => e.bill_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<coins_type>()
                .HasMany(e => e.out_going_billss)
                .WithRequired(e => e.coins_type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.out_going_billss)
                .WithRequired(e => e.customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<customer>()
                .HasMany(e => e.custumers_activity)
                .WithRequired(e => e.customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<out_going_billss>()
                .HasMany(e => e.out_going_bills_details)
                .WithRequired(e => e.out_going_billss)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<service>()
                .HasMany(e => e.out_going_bills_details)
                .WithRequired(e => e.service)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<unit>()
                .HasMany(e => e.service)
                .WithRequired(e => e.unit)
                .HasForeignKey(e => e.unite_id)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<customer>()
               .HasMany(e => e.deduction_bills)
               .WithRequired(e => e.customer)
               .WillCascadeOnDelete(false);
            modelBuilder.Entity<deduction_bills>()
              .HasMany(e => e.deduction_bill_details)
              .WithRequired(e => e.deduction_bills)
              .WillCascadeOnDelete(false);

            modelBuilder.Entity<deductions>()
                .HasMany(e => e.deduction_bill_details)
                .WithRequired(e => e.deductions)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<customer>()
                .HasMany(e => e.deduction_bills)
                .WithRequired(e => e.customer)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<activity>()
                .HasMany(e => e.deduction_bills)
                .WithRequired(e => e.activity)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<deduction_bills>()
              .HasMany(e => e.deduction_bill_details)
              .WithRequired(e => e.deduction_bills)
              .WillCascadeOnDelete(false);
            modelBuilder.Entity<users>()
              .HasMany(e => e.user_activity)
              .WithRequired(e => e.user)
              .WillCascadeOnDelete(false);
        }
    }
}
