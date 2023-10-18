﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using huutokauppa.Data.context;

#nullable disable

namespace huutokauppa.Migrations
{
    [DbContext(typeof(Datacontext))]
    [Migration("20231018104103_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Api.Data.Models.Message", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsProductOwner")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Sender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "I want this",
                            IsProductOwner = true,
                            ProductId = 1,
                            Sender = "haggins",
                            Timestamp = new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7047),
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "how much",
                            IsProductOwner = false,
                            ProductId = 2,
                            Sender = "haggins",
                            Timestamp = new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7050),
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "do you sell winter tires",
                            IsProductOwner = true,
                            ProductId = 2,
                            Sender = "david",
                            Timestamp = new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7051),
                            UserId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "no more scams!",
                            IsProductOwner = false,
                            ProductId = 1,
                            Sender = "david",
                            Timestamp = new DateTime(2023, 10, 18, 10, 41, 3, 178, DateTimeKind.Utc).AddTicks(7053),
                            UserId = 2
                        });
                });

            modelBuilder.Entity("AuctionAuctionBidder", b =>
                {
                    b.Property<int>("AuctionBiddersId")
                        .HasColumnType("int");

                    b.Property<int>("AuctionsId")
                        .HasColumnType("int");

                    b.HasKey("AuctionBiddersId", "AuctionsId");

                    b.HasIndex("AuctionsId");

                    b.ToTable("AuctionAuctionBidder");
                });

            modelBuilder.Entity("AuctionBidderUser", b =>
                {
                    b.Property<int>("AuctionBiddersId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AuctionBiddersId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionBidderUser");
                });

            modelBuilder.Entity("AuctioneerUser", b =>
                {
                    b.Property<int>("AuctioneersId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AuctioneersId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctioneerUser");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("AuctionActive")
                        .HasColumnType("bit");

                    b.Property<string>("AuctionDetails")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("AuctionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("AuctioneerId")
                        .HasColumnType("int");

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FormattedAuctionStartDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuctioneerId");

                    b.HasIndex("ProductId");

                    b.ToTable("Auctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuctionActive = true,
                            AuctionDetails = "New event 1",
                            AuctionStartDate = new DateTime(2023, 10, 18, 13, 41, 3, 178, DateTimeKind.Local).AddTicks(6962),
                            AuctioneerId = 1,
                            Category = "Vechicle",
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuctionActive = false,
                            AuctionDetails = "New event 2",
                            AuctionStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AuctioneerId = 1,
                            Category = "Music",
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuctionActive = true,
                            AuctionDetails = "New event 3",
                            AuctionStartDate = new DateTime(2023, 10, 18, 13, 41, 3, 178, DateTimeKind.Local).AddTicks(7027),
                            AuctioneerId = 2,
                            Category = "Vechicle",
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            AuctionActive = false,
                            AuctionDetails = "New event 4",
                            AuctionStartDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            AuctioneerId = 2,
                            Category = "Electronic",
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.AuctionBidder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("AuctionBidders");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Auctioneer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Auctioneers");

                    b.HasData(
                        new
                        {
                            Id = 1
                        },
                        new
                        {
                            Id = 2
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Bid", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuctionBidderId")
                        .HasColumnType("int");

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionBidderId");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("Bids");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BidAmount = 100.00m,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            BidAmount = 150.00m,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("ReferenceId")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Photos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ReferenceId = 1,
                            Url = "https://example.com/1"
                        },
                        new
                        {
                            Id = 2,
                            ReferenceId = 2,
                            Url = "https://example.com/2"
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://www.vehiclehistory.com/uploads/2009-BMW-3-Series.jpg",
                            Name = "Product 1",
                            OwnerId = 1,
                            Price = 100000m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8M3x8cHJvZHVjdHxlbnwwfHwwfHx8MA%3D%3D&w=1000&q=80",
                            Name = "Product 2",
                            OwnerId = 1,
                            Price = 150000m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSL8kys3I1xOwZeHeL_X6ncKxXK2bDd8KtX74cWYB6n&s",
                            Name = "Product 3",
                            OwnerId = 2,
                            Price = 200000m,
                            Quantity = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Image = "https://purepng.com/public/uploads/large/purepng.com-ford-mustang-red-carcarvehicletransportford-961524665626mlrez.png",
                            Name = "Product 4",
                            OwnerId = 2,
                            Price = 500000m,
                            Quantity = 0
                        });
                });

            modelBuilder.Entity("huutokauppa.Data.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Region")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Vaasankatu1",
                            Email = "john@example.com",
                            Fname = "John",
                            Lname = "Doe",
                            Password = "test123",
                            Photo = "https://static.wikia.nocookie.net/lotr/images/e/e7/Gandalf_the_Grey.jpg/revision/latest?cb=20121110131754"
                        },
                        new
                        {
                            Id = 2,
                            Address = "nigstan1",
                            Email = "jane@example.com",
                            Fname = "Jane",
                            Lname = "Smith",
                            Password = "test",
                            Photo = "https://static.wikia.nocookie.net/lotr/images/c/cb/Galadriel.jpg/revision/latest?cb=20151015204512"
                        });
                });

            modelBuilder.Entity("Api.Data.Models.Message", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.Auction", null)
                        .WithMany("Messages")
                        .HasForeignKey("AuctionId");
                });

            modelBuilder.Entity("AuctionAuctionBidder", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.AuctionBidder", null)
                        .WithMany()
                        .HasForeignKey("AuctionBiddersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("huutokauppa.Data.Models.Auction", null)
                        .WithMany()
                        .HasForeignKey("AuctionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionBidderUser", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.AuctionBidder", null)
                        .WithMany()
                        .HasForeignKey("AuctionBiddersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("huutokauppa.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctioneerUser", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.Auctioneer", null)
                        .WithMany()
                        .HasForeignKey("AuctioneersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("huutokauppa.Data.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Auction", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.Auctioneer", null)
                        .WithMany("Auctions")
                        .HasForeignKey("AuctioneerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("huutokauppa.Data.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Bid", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.AuctionBidder", null)
                        .WithMany("MyBids")
                        .HasForeignKey("AuctionBidderId");

                    b.HasOne("huutokauppa.Data.Models.Auction", null)
                        .WithMany("Bids")
                        .HasForeignKey("AuctionId");

                    b.HasOne("huutokauppa.Data.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Photo", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.Product", null)
                        .WithMany("Photos")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Product", b =>
                {
                    b.HasOne("huutokauppa.Data.Models.User", null)
                        .WithMany("BuyHistory")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Auction", b =>
                {
                    b.Navigation("Bids");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.AuctionBidder", b =>
                {
                    b.Navigation("MyBids");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Auctioneer", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.Product", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("huutokauppa.Data.Models.User", b =>
                {
                    b.Navigation("BuyHistory");
                });
#pragma warning restore 612, 618
        }
    }
}