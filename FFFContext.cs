namespace FFFWebApplication
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FFFContext : DbContext
    {
        public FFFContext()
            : base("name=FFFContext")
        {
        }

        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Result>()
                .Property(e => e.Q1Correct)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Q2Correct)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Q3Correct)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Q4Correct)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Q5Correct)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.AccessLevel)
                .IsUnicode(false);
        }
    }
}
