using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Models;
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

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<Auctioneer> Auctioneers { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Message> Messages { get; set; }

        public DbSet<Participate> Participates { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define seed data here
            modelBuilder.Entity<User>().HasData(
        new User { Id = 1, Fname = "John", Lname = "Doe", Email = "john@example.com", Address = "Vaasankatu1", Photo = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754", Password = "test123" },
        new User { Id = 2, Fname = "Jane", Lname = "Smith", Email = "jane@example.com", Address = "nigstan1", Photo = "https://static.wikia.nocookie.net/lotr/images/c/cb/Galadriel.jpg/revision/latest?cb=20151015204512", Password = "test" }
// Add more user data as needed


);

            modelBuilder.Entity<Auctioneer>().HasData(
        new Auctioneer { Id = 1 },
        new Auctioneer { Id = 2 }
    // Add more Auctioneer data as needed
    );
            modelBuilder.Entity<Auction>().HasData(
                new Auction { Id = 1, AuctionActive = true, AuctionDetails = "New event 1", AuctionStartDate = DateTime.Now, ProductId = 1, Category = "Vechicle", AuctioneerId = 1 },
                new Auction { Id = 2, AuctionActive = false, AuctionDetails = "New event 2", ProductId = 2, Category = "Music", AuctioneerId = 1 },
                new Auction { Id = 3, AuctionActive = true, AuctionDetails = "New event 3", AuctionStartDate = DateTime.Now, ProductId = 3, Category = "Vechicle", AuctioneerId = 2 },
                new Auction { Id = 4, AuctionActive = false, AuctionDetails = "New event 4", ProductId = 4, Category = "Electronic", AuctioneerId = 2 }
            );
            modelBuilder.Entity<Message>().HasData(
                new Message { Id = 1, Sender = "haggins", Content = "I want this", UserId = 1, IsAuctionOwner = true, AuctionId = 1 },
                new Message { Id = 2, Sender = "haggins", Content = "how much", UserId = 1, IsAuctionOwner = false, AuctionId = 2 },
                new Message { Id = 3, Sender = "david", Content = "do you sell winter tires", UserId = 2, IsAuctionOwner = true, AuctionId = 2 },
                new Message { Id = 4, Sender = "david", Content = "no more scams!", UserId = 2, IsAuctionOwner = false, AuctionId = 1 }
            );



            modelBuilder.Entity<Product>().HasData(
             new Product { Id = 1, Name = "Product 1", Price = 100000, OwnerId = 1, Image = "https://www.vehiclehistory.com/uploads/2009-BMW-3-Series.jpg" },
             new Product { Id = 2, Name = "Product 2", Price = 150000, OwnerId = 1, Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80" },
             new Product { Id = 3, Name = "Product 3", Price = 200000, OwnerId = 2, Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL8kys3I1xOwZeHeL_X6ncKxXK2bDd8KtX74cWYB6n&s" },
             new Product { Id = 4, Name = "Product 4", Price = 500000, OwnerId = 2, Image = "https://purepng.com/public/uploads/large/purepng.com-ford-mustang-red-carcarvehicletransportford-961524665626mlrez.png" }
         // Add more Product data as needed
         );

            modelBuilder.Entity<Bid>().HasData(
       new Bid { Id = 1, UserId = 1, BidAmount = 100.00m },
       new Bid { Id = 2, UserId = 2, BidAmount = 150.00m }
   // Add more Bid data as needed
   );

            modelBuilder.Entity<Photo>().HasData(
         new Photo { Id = 1, Url = "https://example.com/1", ReferenceId = 1 },
         new Photo { Id = 2, Url = "https://example.com/2", ReferenceId = 2 }
     // Add more instances of YourEntity as needed
     );

        }
    }
}
