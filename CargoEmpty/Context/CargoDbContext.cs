using CargoEmpty.Models.App;
using CargoEmpty.Models.Balance;
using CargoEmpty.Models.General;
using CargoEmpty.Models.General.Bundel;
using CargoEmpty.Models.General.Decleration;
using CargoEmpty.Models.General.Order;
using CargoEmpty.Models.General.User;
using CargoEmpty.Models.Pages;
using CargoEmpty.Models.Pages.About;
using CargoEmpty.Models.Pages.Carusel;
using CargoEmpty.Models.Pages.Faq;
using CargoEmpty.Models.Pages.Menyu;
using CargoEmpty.Models.Pages.News;
using CargoEmpty.Models.Pages.Shop;
using CargoEmpty.Models.Pages.Tarif;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CargoEmpty.Context
{
    public class CargoDbContext : DbContext
    {
        public CargoDbContext() : base("CargoDb")
        {
        }

        public DbSet<CaruselDb> Carusels { get; set; }
        public DbSet<NewsDbModel> News { get; set; }
        public DbSet<FaqDb> Faqs { get; set; }
        public DbSet<AboutDb> Abouts { get; set; }
        public DbSet<ShopDb> Shops { get; set; }
        public DbSet<Menyu> Menyus { get; set; }
        public DbSet<Tarif> Tarifs { get; set; }


        public DbSet<UserDb> Users { get; set; }
        public DbSet<OrderDb> Orders { get; set; }
        public DbSet<BundelsDb> Bundels{ get; set; }
        public DbSet<BundelProducts> BundelProducts{ get; set; }
        public DbSet<DeclerationDb> Declerations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<MyAddress> MyAddresses { get; set; }
        public DbSet<BalanceOperator> BalanceOperators { get; set; }

    }
    
}