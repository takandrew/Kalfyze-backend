using Kalfyze_backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Kalfyze_backend.Data
{
    public class KalfyzeDbContext : DbContext
    {
        public KalfyzeDbContext(DbContextOptions<KalfyzeDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User_Role> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Content_Type> ContentTypes { get; set; }
        public DbSet<Franchise> Franchises { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<User_Content_Status> UserContentStatuses { get; set; }
        public DbSet<User_Content_Record> UserContentRecords { get; set; }
        public DbSet<User_Content_Record_Log> UserContentRecordLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User_Role>().HasKey(key => key.Id);

            modelBuilder.Entity<User>().HasKey(key => key.Id);
            modelBuilder.Entity<User>().HasOne(key => key.Role).WithMany(ukey => ukey.Users)
                .HasForeignKey(fkey => fkey.RoleId);

            modelBuilder.Entity<Content_Type>().HasKey(key => key.Id);

            modelBuilder.Entity<Franchise>().HasKey(key => key.Id);

            modelBuilder.Entity<Content>().HasKey(key => key.Id);
            modelBuilder.Entity<Content>().HasOne(key => key.Franchise).WithMany(ukey => ukey.Contents)
                .HasForeignKey(fkey => fkey.FranchiseId);
            modelBuilder.Entity<Content>().HasOne(key => key.Type).WithMany(ukey => ukey.Contents)
                .HasForeignKey(fkey => fkey.TypeId);

            modelBuilder.Entity<User_Content_Status>().HasKey(key => key.Id);

            modelBuilder.Entity<User_Content_Record>().HasKey(key => new { key.UserId, key.ContentId, key.StatusId });
            modelBuilder.Entity<User_Content_Record>().HasOne(key => key.User).WithMany(ukey => ukey.ContentRecords)
                .HasForeignKey(fkey => fkey.UserId);
            modelBuilder.Entity<User_Content_Record>().HasOne(key => key.Content).WithMany(ukey => ukey.ContentRecords)
                .HasForeignKey(fkey => fkey.ContentId);
            modelBuilder.Entity<User_Content_Record>().HasOne(key => key.Status).WithMany(ukey => ukey.ContentRecords)
                .HasForeignKey(fkey => fkey.StatusId);

            modelBuilder.Entity<User_Content_Record_Log>().HasKey(key => key.Id);
            modelBuilder.Entity<User_Content_Record_Log>().HasOne(key => key.Record).WithMany(ukey => ukey.Logs)
                .HasForeignKey(fkey => new { fkey.UserId, fkey.ContentId, fkey.StatusId });
        }
    }
}
