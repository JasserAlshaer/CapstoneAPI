
using CapstoneAPI.Entities;
using Microsoft.EntityFrameworkCore;
using CapstoneAPI.Helpers;

namespace CapstoneAPI.Context
{
    public class CapstoneDbContext : DbContext
    {
        public CapstoneDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }
        private void SeedData(ModelBuilder modelBuilder)
        {
            //LookupType
            modelBuilder.Entity<LookupType>().HasData(
                new LookupType { Id = 1, Name = "Nationality" },
                new LookupType { Id = 2, Name = "Role" },
                new LookupType { Id = 3, Name = "PaymentMethod" },
                new LookupType { Id = 4, Name = "Status" },
                new LookupType { Id = 5, Name = "CardType" }
                );
            //LookupItem
            modelBuilder.Entity<LookupItem>().HasData(
                new LookupItem { Id = 10, Name = "Jordanin", TypeId = 1 },
                new LookupItem { Id = 1, Name = "Client", TypeId = 2 },
                new LookupItem { Id = 2, Name = "Admin", TypeId = 2 },
                new LookupItem { Id = 3, Name = "Driver", TypeId = 2 },
                new LookupItem { Id = 100, Name = "Cash", TypeId = 3 },
                new LookupItem { Id = 101, Name = "Credit Card", TypeId = 3 },
                new LookupItem { Id = 200, Name = "Order Received", TypeId = 4 },
                new LookupItem { Id = 201, Name = "Cooking your order", TypeId = 4 },
                new LookupItem { Id = 202, Name = "In Way", TypeId = 4 },
                new LookupItem { Id = 203, Name = "Delivered", TypeId =4 },
                new LookupItem { Id = 204, Name = "Pending", TypeId = 4 },
                new LookupItem { Id = 300, Name = "Visa", TypeId = 5 },
                new LookupItem { Id = 301, Name = "Master Card", TypeId = 5 }
                );
            //User
            modelBuilder.Entity<Client>().HasData(
                new Client
                {
                    Id = 1,
                    Email = HashingHelper.HashValueWith384("joshaer17@gmail.com"),
                    Password = HashingHelper.HashValueWith384("Z3160@jase"),
                    RoleId = 1,
                    IsVerfied = true,
                    BirthDate = new DateOnly(1997, 7, 17),
                    CountryCodeId = 1,
                    CreatedBy = "System",
                    CreationDate = DateTime.Now,
                    FullName = "Jasser Alshaer",
                    IsActive = true
                },
                 new Client
                 {
                     Id = 3,
                     Email = HashingHelper.HashValueWith384("ahmad@gmail.com"),
                     Password = HashingHelper.HashValueWith384("Z3160@ahmad"),
                     RoleId = 3,
                     IsVerfied = true,
                     BirthDate = new DateOnly(1999, 8, 9),
                     CountryCodeId = 1,
                     CreatedBy = "System",
                     CreationDate = DateTime.Now,
                     FullName = "Ahmad AlAoush",
                     IsActive = true
                 }
                );
        }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Client> Clients { get; set; }

        public virtual DbSet<CountryCode> CountryCodes { get; set; }

        public virtual DbSet<Item> Items { get; set; }

        public virtual DbSet<Location> Locations { get; set; }

        public virtual DbSet<LookupItem> LookupItems { get; set; }

        public virtual DbSet<LookupType> LookupTypes { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }

        public virtual DbSet<PaymentCard> PaymentCards { get; set; }

        public virtual DbSet<WishList> WishLists { get; set; }
        public virtual DbSet<Discount> Discounts { get; set; }
        public virtual DbSet<DiscountCondition> DiscountConditions { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
    }
}
