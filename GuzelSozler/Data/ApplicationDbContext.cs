using GuzelSozler.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GuzelSozler.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //composite primary key oluşturduk
            builder.Entity<KullaniciSoz>().HasKey(x => new { x.GuzelSozId, x.KullaniciId });

            base.OnModelCreating(builder);
        }

        public DbSet<GuzelSoz> GuzelSozler { get; set; }
        public DbSet<KullaniciSoz> KullaniciSozler { get; set; }
    }
}