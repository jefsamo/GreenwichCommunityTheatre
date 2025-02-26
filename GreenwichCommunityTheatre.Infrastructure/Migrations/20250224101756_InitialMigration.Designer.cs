﻿// <auto-generated />
using System;
using GreenwichCommunityTheatre.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GreenwichCommunityTheatre.Infrastructure.Migrations
{
    [DbContext(typeof(GctDbContext))]
    [Migration("20250224101756_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Play", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AvailableSeats")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<DateTimeOffset>("TimeOfPlay")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalSeats")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Plays");

                    b.HasData(
                        new
                        {
                            Id = "207ab2d0-1c09-462c-ad0f-a3af507beaf6",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "In The Curse of the Crimson Rose, a mysterious, blood-red rose holds a dark secret�one that brings misfortune to all who possess it. When a young scholar stumbles upon the cursed bloom in an abandoned manor, they are thrust into a web of ancient betrayals, forbidden love, and supernatural vengeance. As the curse tightens its grip, they must unravel its tragic origins before it consumes their soul forever.",
                            ImageUrl = "https://images.pexels.com/photos/593655/pexels-photo-593655.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/1187079/pexels-photo-1187079.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 10.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Curse of the Crimson Rose",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(1743), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "23071501-babe-451f-90de-b6ffb9c8345c",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Whispers in the Moonlight is a haunting tale of love, mystery, and the supernatural. When a lone traveler arrives in a secluded village, they begin hearing eerie whispers carried by the night breeze�voices that speak of long-buried secrets and unfinished fates. As they unravel the village�s dark history, they realize the whispers are leading them toward a truth that could change everything� or trap them in the moonlit shadows forever.",
                            ImageUrl = "https://images.pexels.com/photos/920534/pexels-photo-920534.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/3489072/pexels-photo-3489072.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 8.5,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Whispers in the Moonlight",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2165), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "2f34bf6c-fed4-417c-a4b4-4294b486a6c2",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Queen�s Betrayal is a gripping tale of power, deception, and revenge. When a beloved queen uncovers a web of treachery within her own court, she must choose between loyalty to her kingdom and a dangerous secret that could shatter the throne. As whispers of betrayal grow louder and enemies close in from all sides, she must outwit those who seek to destroy her�before the crown slips from her grasp forever.",
                            ImageUrl = "https://images.pexels.com/photos/260024/pexels-photo-260024.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/3095593/pexels-photo-3095593.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 20.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Queen�s Betrayal",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "5d15acd2-b01c-4729-9e24-f7f5b436246f",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Echoes of the Forbidden Love is a poignant tale of passion, sacrifice, and destiny. When two star-crossed lovers defy the laws that keep them apart, their forbidden romance sets off a chain of tragic events. Years later, their whispers still linger in the wind, haunting the ruins where they once met in secret. As a new pair of lovers uncovers their story, they find themselves drawn into the echoes of a love that refused to be silenced�one that may yet demand a final Price.",
                            ImageUrl = "https://images.prismic.io/royal-opera-house/021d3d96-e550-438c-93e9-712149c5fcfa_Carmen_ROH_3664-web.jpg?auto=compress,format&rect=172,337,3111,2333&w=960&h=720",
                            MainImageUrl = "https://images.pexels.com/photos/1535288/pexels-photo-1535288.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 15.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Echoes of the Forbidden Love",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "74c9c3a1-7a9f-46ac-8369-6f4c66f30201",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Duke�s Vanishing Bride is a tale of mystery, romance, and dark secrets. On the eve of their grand wedding, the bride of the esteemed Duke of Ravencroft disappears without a trace. Whispers of betrayal and curses spread through the halls of his ancestral estate as the search begins. As the Duke delves into the truth, he uncovers a web of deception, forbidden love, and a past that refuses to stay buried. Will he find his bride before it�s too late, or was she never meant to be his at all?",
                            ImageUrl = "https://images.pexels.com/photos/341372/pexels-photo-341372.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/5379080/pexels-photo-5379080.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 12.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Duke�s Vanishing Bride",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "7fbb0b83-634d-495d-ae47-4f1cd222f6e3",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Last Song of Venezia is a tale of love, loss, and the fading echoes of a once-glorious past. In the heart of Venice, a gifted musician composes his final masterpiece as the city around him sinks into the depths of time. Haunted by memories of a lost love and a promise left unfulfilled, he pours his soul into one last melody�a song that carries the sorrow of the past and the hope of redemption. As the notes drift through the moonlit canals, will his final song reunite him with his beloved, or will it be lost to the waters of Venezia forever?",
                            ImageUrl = "https://images.pexels.com/photos/2179373/pexels-photo-2179373.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/16122200/pexels-photo-16122200/free-photo-of-couple-lying-on-the-ground-and-man-playing-the-guitar.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 10.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Last Song of Venezia",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "953d2a63-7692-40cd-af54-cc3b0be2198b",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Enchanted Harp is a spellbinding tale of music, magic, and destiny. Hidden deep within an ancient forest lies a harp of otherworldly beauty, said to be blessed�or cursed�by the spirits of old. When a young musician stumbles upon the instrument and plays its haunting melody, they awaken a power that can either bring harmony to the world or unleash a darkness long forgotten. As whispers of its enchantment spread, forces both good and evil seek to claim its magic. Will the musician master the harp�s true power, or will they become another lost soul in its tragic melody?",
                            ImageUrl = "https://images.pexels.com/photos/8659662/pexels-photo-8659662.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/12970722/pexels-photo-12970722.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 10.5,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Enchanted Harp",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "99f730fc-5cfc-4ab9-9904-475db277df8d",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "Shadows of the Ivory Tower is a tale of ambition, secrets, and forbidden knowledge. Within the grand halls of the Ivory Tower, the world�s greatest scholars pursue wisdom�but some truths were never meant to be uncovered. When a young researcher stumbles upon a hidden manuscript, they awaken a mystery buried for centuries. As whispers of lost magic and betrayal echo through the tower�s ancient walls, they must navigate a web of deceit and danger before the shadows consume them. Will they uncover the truth, or become just another forgotten name in the tower�s dark history?",
                            ImageUrl = "https://images.pexels.com/photos/247506/pexels-photo-247506.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/30857245/pexels-photo-30857245/free-photo-of-majestic-plaza-de-espana-tower-in-seville.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 15.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 7, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "Shadows of the Ivory Tower",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "9b2e8328-1597-45d2-a95c-93f992a244cb",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "A Symphony of Vengeance is a haunting tale of betrayal, justice, and the power of music. When a brilliant composer is wronged by those he once trusted, he crafts his final masterpiece�not as a gift to the world, but as a requiem for his enemies. As the notes of his dark symphony rise, so too does a chilling force that seeks retribution. Each movement plays out like fate itself, drawing the guilty toward an inescapable reckoning. But as the final crescendo nears, will vengeance bring him peace�or will he become trapped in the melody of his own creation?",
                            ImageUrl = "https://images.pexels.com/photos/5721137/pexels-photo-5721137.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/7095824/pexels-photo-7095824.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 25.0,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 7, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "A Symphony of Vengeance",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2885), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "c0d775b9-6f43-4277-9046-26237bd06812",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Little Boy from Rosario is a touching story of dreams, determination, and destiny. In the humble streets of Rosario, a young boy with a heart full of passion and a ball at his feet dreams of greatness. Against all odds, he rises from the dusty fields to the grandest stages of the world, carrying with him the hopes of his people. But beyond the fame and glory, his journey is one of sacrifice, resilience, and an unbreakable love for the game. Will he become the legend he was meant to be, or will the weight of expectation be too much to bear?",
                            ImageUrl = "https://images.pexels.com/photos/14482441/pexels-photo-14482441.jpeg?auto=compress&cs=tinysrgb&w=600",
                            MainImageUrl = "https://images.pexels.com/photos/3662942/pexels-photo-3662942.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 20.699999999999999,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Little Boy from Rosario",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 0, 0, 0, 0))
                        },
                        new
                        {
                            Id = "fc7acc1e-11af-4fee-a7bf-79780fdc0b74",
                            AvailableSeats = 100,
                            CreatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 0, 0, 0, 0)),
                            Description = "The Phantom's Lament is a tragic tale of unrequited love, loss, and the search for redemption. Hidden in the shadows of an opulent opera house, a mysterious figure�a tormented soul, once full of promise�now haunts the halls, longing for the love he can never have. His heart aches with the music he once created, now transformed into a haunting melody that echoes his sorrow. As a young singer arrives at the opera house, she unknowingly becomes the object of his obsession. But will her voice be the key to his salvation, or will it only deepen the phantom's pain?",
                            ImageUrl = "https://images.prismic.io/royal-opera-house/8e4cb083-cc7d-431a-ab21-01333633e294_Die+Walkure_1+%C2%A92024+Sebastian+Nevols.jpg?auto=format,compress&rect=232,0,4636,3477&w=960&h=720",
                            MainImageUrl = "https://images.pexels.com/photos/4584283/pexels-photo-4584283.jpeg?auto=compress&cs=tinysrgb&w=600",
                            Price = 10.699999999999999,
                            TimeOfPlay = new DateTimeOffset(new DateTime(2025, 3, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)),
                            Title = "The Phantom's Lament",
                            TotalSeats = 100,
                            UpdatedAt = new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 0, 0, 0, 0))
                        });
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Reservation", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasPaid")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingOption")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Review", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("PlayId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.HasIndex("UserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Seat", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Ticket", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateOnly>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("HasCheckedIn")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlayId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ReservationId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("SeatId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("TicketCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.HasKey("Id");

                    b.HasIndex("PlayId");

                    b.HasIndex("ReservationId");

                    b.HasIndex("SeatId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTimeOffset>("CreatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset>("UpdatedAt")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Reservation", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Review", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Play", "Play")
                        .WithMany("Reviews")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Play");

                    b.Navigation("User");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Ticket", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Play", "Play")
                        .WithMany("Tickets")
                        .HasForeignKey("PlayId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Reservation", "Reservation")
                        .WithMany("Tickets")
                        .HasForeignKey("ReservationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Seat", "Seat")
                        .WithMany("Tickets")
                        .HasForeignKey("SeatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Play");

                    b.Navigation("Reservation");

                    b.Navigation("Seat");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("GreenwichCommunityTheatre.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Play", b =>
                {
                    b.Navigation("Reviews");

                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Reservation", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.Seat", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("GreenwichCommunityTheatre.Domain.Entities.User", b =>
                {
                    b.Navigation("Reservations");

                    b.Navigation("Reviews");
                });
#pragma warning restore 612, 618
        }
    }
}
