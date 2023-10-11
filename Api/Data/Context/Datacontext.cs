using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using huutokauppa.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace huutokauppa.Data.context
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<AuctionBidder> AuctionBidders { get; set; }
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Auctioneer> Auctioneers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define seed data here
            modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Fname = "John", Lname = "Doe", Email = "john@example.com", Address = "Vaasankatu1", Photo = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754", Password = "test123" },
        new User { Id = 2, Fname = "Jane", Lname = "Smith", Email = "jane@example.com", Address = "nigstan1", Photo = "https://static.wikia.nocookie.net/lotr/images/c/cb/Galadriel.jpg/revision/latest?cb=20151015204512", Password = "test" }
// Add more user data as needed


);


            modelBuilder.Entity<AuctionBidder>().HasData(
                new AuctionBidder { Id = 1 },
                new AuctionBidder { Id = 2 }
            // Add more AuctionBidder data as needed
            );

            modelBuilder.Entity<Auctioneer>().HasData(
       new Auctioneer { Id = 1 },
       new Auctioneer { Id = 2 }
   // Add more Auctioneer data as needed
   );

            modelBuilder.Entity<Product>().HasData(
             new Product { Id = 1, Name = "Product 1", Price = 19.99m, OwnerId = 1, Image = "https://www.vehiclehistory.com/uploads/2009-BMW-3-Series.jpg" },
             new Product { Id = 2, Name = "Product 2", Price = 29.99m, OwnerId = 2, Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80" }
         // Add more Product data as needed
         );

            modelBuilder.Entity<Bid>().HasData(
       new Bid { Id = 1, UserId = 1, BidAmount = 100.00m },
       new Bid { Id = 2, UserId = 2, BidAmount = 150.00m }
   // Add more Bid data as needed
   );

            modelBuilder.Entity<Auction>().HasData(
              new Auction { Id = 1, AuctioneerId = 1, ProductId = 1 },
              new Auction { Id = 2, AuctioneerId = 2, ProductId = 2 }
          // Add more Auction data as needed
          );

            modelBuilder.Entity<Photo>().HasData(
         new Photo { Id = 1, Url = "https://example.com/1", UserId = 1, ProductId = 1 },
         new Photo { Id = 2, Url = "https://example.com/2", UserId = 2, ProductId = 2 }
     // Add more instances of YourEntity as needed
     );

        }
    }
}
