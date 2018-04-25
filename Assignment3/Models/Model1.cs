namespace Assignment3.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=DefaultConnections")
        {
        }

        public virtual DbSet<phones1> phones1 { get; set; }
        public virtual DbSet<phones2> phones2 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<phones1>()
                .Property(e => e.phones)
                .IsUnicode(false);

            modelBuilder.Entity<phones1>()
                .Property(e => e.color)
                .IsUnicode(false);

            modelBuilder.Entity<phones2>()
                .Property(e => e.brand)
                .IsUnicode(false);
        }
    }
}
