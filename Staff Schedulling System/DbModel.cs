namespace Staff_Schedulling_System
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=StaffSchedullingDbEntities2")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffWard> StaffWards { get; set; }
        public virtual DbSet<Ward> Wards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .Property(e => e.UserType)
                .IsUnicode(false);

            modelBuilder.Entity<Account>()
                .HasMany(e => e.Staffs)
                .WithRequired(e => e.Account)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.WardId)
                .IsUnicode(false);

            modelBuilder.Entity<Shift>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Shift>()
                .Property(e => e.StaffId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.AccountId)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.AccessLevel)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Fname)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Lname)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.Shifts)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Staff>()
                .HasMany(e => e.StaffWards)
                .WithRequired(e => e.Staff)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StaffWard>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<StaffWard>()
                .Property(e => e.StaffID)
                .IsUnicode(false);

            modelBuilder.Entity<StaffWard>()
                .Property(e => e.WardId)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .Property(e => e.Id)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.Settings)
                .WithRequired(e => e.Ward)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ward>()
                .HasMany(e => e.StaffWards)
                .WithRequired(e => e.Ward)
                .WillCascadeOnDelete(false);
        }
    }
}
