﻿using Beauty.Entity.Entities;
using Beauty.Repository.Configuration.DataSeeding;
using Beauty.Repository.Configuration.EntityConfig;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Repository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new BookingConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RoleSeeding());

            modelBuilder.Entity<UserRole>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }

        public DbSet<Role>? Roles { get; set; }
        public DbSet<Room>? Rooms { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Booking>? Bookings { get; set; }
        public DbSet<Discount>? Discounts { get; set; }
        public DbSet<UserRole>? UserRoles { get; set; }
        public DbSet<Appointment>? Appointments { get; set; }
        public DbSet<AppointmentType>? AppointmentTypes { get; set; }
    }
}
