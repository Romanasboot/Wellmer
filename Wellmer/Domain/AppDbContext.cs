using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wellmer.Domain.Entities;

//DB context configuracija. Naudojama sistemine klase Identity.

namespace Wellmer.Domain
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<TextField> TextFields { get; set; }         //Puslapiu irasai i DB
        public DbSet<ServiceItem> ServiceItems { get; set; }     //Paslaugu irasai i DB.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(new IdentityRole   //Sukuriam role Admin
            {
                Id = "BE2E50FD-8BAF-4BFB-9C1B-5FB760D3E2CE",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser     //sukuriamas vartotojas
            {
                Id = "A2EC9D18-396D-4F8C-8D5B-9A90F874AFCD",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "rk@gmail.com",
                NormalizedEmail = "RK@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "superpassword"),
                SecurityStamp = string.Empty
            });
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>     //vartotojui priskiriama role Administrator
            {
                RoleId = "BE2E50FD-8BAF-4BFB-9C1B-5FB760D3E2CE",
                UserId = "A2EC9D18-396D-4F8C-8D5B-9A90F874AFCD"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("F12F2A8F-6F9B-4285-9107-707C3F656333"),
                CodeWord = "PageIndex",
                Title = "Pradinis"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("8DB85282-E68A-4E14-906B-B722D00FC4D6"),
                CodeWord = "PageServices",
                Title = "Musu Paslaugos"
            });
            builder.Entity<TextField>().HasData(new TextField
            {
                Id = new Guid("C5990ED2-AE4E-414D-88BE-542D606499C7"),
                CodeWord = "PageContacts",
                Title = "Kontaktai"
            });
        }


    }
}
