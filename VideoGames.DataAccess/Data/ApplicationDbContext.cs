using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VideoGames.Models;


namespace VideoGames.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser> // the class inherited everything from package
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        // Adding Mapper
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ShoppingCart> shoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           base.OnModelCreating(modelBuilder); // configuration for identity

            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Action", DisplayOrder = 1},
                new Category { Id = 2, Name = "Adventure", DisplayOrder = 2 },
                new Category { Id = 3, Name = "Strategy", DisplayOrder = 3 }
                );

            modelBuilder.Entity<Product>().HasData(
             new Product { 
                 Id = 1, 
                 Title = "Fallout 4",
                 Description = "Survival in a post apocaliptic world",
                 SerialNumber = "345-F54-O11",
                 Publisher = "Bethesda Studios",
                 Price = 39.90,
                 CategoryId = 1,
                 ImageUrl = ""
             },
             new Product
             {
                 Id = 2,
                 Title = "Call of Duty Modern Warfare",
                 Description = "Action first person shooting",
                 SerialNumber = "367-C14-D45",
                 Publisher = "ACTIVITION",
                 Price = 59.90,
                 CategoryId = 1,
                 ImageUrl = ""
             },
             new Product
             {
                 Id = 3,
                 Title = "The Witcher 3",
                 Description = "Medival world with nights and wizards",
                 SerialNumber = "876-T23-W19",
                 Publisher = "CD Project",
                 Price = 29.90,
                 CategoryId = 1,
                 ImageUrl = ""
             },
             new Product
             {
                 Id = 4,
                 Title = "Elder Scrolls Skyrim",
                 Description = "RPG MMO viking game",
                 SerialNumber = "E45-S94-S41",
                 Publisher = "Bethesda Studios",
                 Price = 24.90,
                 CategoryId = 1,
                 ImageUrl = ""
             },
             new Product
             {
                 Id = 5,
                 Title = "Assassin Creed Odyssey",
                 Description = "Greek hellenic 300bc",
                 SerialNumber = "A85-C14-O77",
                 Publisher = "Ubisoft",
                 Price = 49.90,
                 CategoryId = 1,
                 ImageUrl = ""
             }
             );

            modelBuilder.Entity<Company>().HasData(
             new Company
             {
                 Id = 1,
                 Name = "PC GAMER",
                 StreetAddress = " Boulavard 12",
                 City = "New York",
                 State = "New York",
                 PostalCode = "2345241",
                 PhoneNumber = "00995672353"
             },
             new Company
             {
                 Id = 2,
                 Name = "ISHIMA GAMES",
                 StreetAddress = "Tokyo Street 76",
                 City = "Tokyo",
                 State = "Tokyo",
                 PostalCode = "3873234",
                 PhoneNumber = "0052564725"
             }
             );
        }
    }
}
