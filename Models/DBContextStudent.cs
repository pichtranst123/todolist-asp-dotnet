using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace entityframeworkStudent.Models
{
    public partial class DBContextStudent : DbContext
    {
        public DBContextStudent()
            : base("name=DBContextStudent")
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.name)
                .IsFixedLength();

            modelBuilder.Entity<Student>()
                .Property(e => e._class)
                .IsFixedLength();
        }
    }
}
