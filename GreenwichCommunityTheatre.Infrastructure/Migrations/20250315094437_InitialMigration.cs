using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GreenwichCommunityTheatre.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSocialClub = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    TimeOfPlay = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    AvailableSeats = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<double>(type: "float", nullable: true),
                    HasPaid = table.Column<bool>(type: "bit", nullable: false),
                    ShippingOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservations_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    PlayId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reviews_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ReservationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PlayId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SeatId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    HasCheckedIn = table.Column<bool>(type: "bit", nullable: false),
                    TicketCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    UpdatedAt = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "Id", "AvailableSeats", "CreatedAt", "Description", "ImageUrl", "MainImageUrl", "Price", "TimeOfPlay", "Title", "TotalSeats", "UpdatedAt" },
                values: new object[,]
                {
                    { "207ab2d0-1c09-462c-ad0f-a3af507beaf6", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(4888), new TimeSpan(0, 0, 0, 0, 0)), "In The Curse of the Crimson Rose, a mysterious, blood-red rose holds a dark secret�one that brings misfortune to all who possess it. When a young scholar stumbles upon the cursed bloom in an abandoned manor, they are thrust into a web of ancient betrayals, forbidden love, and supernatural vengeance. As the curse tightens its grip, they must unravel its tragic origins before it consumes their soul forever.", "https://images.pexels.com/photos/593655/pexels-photo-593655.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/1187079/pexels-photo-1187079.jpeg?auto=compress&cs=tinysrgb&w=600", 10.0, new DateTimeOffset(new DateTime(2025, 3, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Curse of the Crimson Rose", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(4898), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "23071501-babe-451f-90de-b6ffb9c8345c", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 0, 0, 0, 0)), "Whispers in the Moonlight is a haunting tale of love, mystery, and the supernatural. When a lone traveler arrives in a secluded village, they begin hearing eerie whispers carried by the night breeze�voices that speak of long-buried secrets and unfinished fates. As they unravel the village�s dark history, they realize the whispers are leading them toward a truth that could change everything� or trap them in the moonlit shadows forever.", "https://images.pexels.com/photos/920534/pexels-photo-920534.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3489072/pexels-photo-3489072.jpeg?auto=compress&cs=tinysrgb&w=600", 8.5, new DateTimeOffset(new DateTime(2025, 3, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Whispers in the Moonlight", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "2f34bf6c-fed4-417c-a4b4-4294b486a6c2", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5236), new TimeSpan(0, 0, 0, 0, 0)), "The Queen�s Betrayal is a gripping tale of power, deception, and revenge. When a beloved queen uncovers a web of treachery within her own court, she must choose between loyalty to her kingdom and a dangerous secret that could shatter the throne. As whispers of betrayal grow louder and enemies close in from all sides, she must outwit those who seek to destroy her�before the crown slips from her grasp forever.", "https://images.pexels.com/photos/260024/pexels-photo-260024.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3095593/pexels-photo-3095593.jpeg?auto=compress&cs=tinysrgb&w=600", 20.0, new DateTimeOffset(new DateTime(2025, 3, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Queen�s Betrayal", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5237), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5d15acd2-b01c-4729-9e24-f7f5b436246f", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5324), new TimeSpan(0, 0, 0, 0, 0)), "Echoes of the Forbidden Love is a poignant tale of passion, sacrifice, and destiny. When two star-crossed lovers defy the laws that keep them apart, their forbidden romance sets off a chain of tragic events. Years later, their whispers still linger in the wind, haunting the ruins where they once met in secret. As a new pair of lovers uncovers their story, they find themselves drawn into the echoes of a love that refused to be silenced�one that may yet demand a final Price.", "https://images.prismic.io/royal-opera-house/021d3d96-e550-438c-93e9-712149c5fcfa_Carmen_ROH_3664-web.jpg?auto=compress,format&rect=172,337,3111,2333&w=960&h=720", "https://images.pexels.com/photos/1535288/pexels-photo-1535288.jpeg?auto=compress&cs=tinysrgb&w=600", 15.0, new DateTimeOffset(new DateTime(2025, 3, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Echoes of the Forbidden Love", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5326), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "74c9c3a1-7a9f-46ac-8369-6f4c66f30201", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5417), new TimeSpan(0, 0, 0, 0, 0)), "The Duke�s Vanishing Bride is a tale of mystery, romance, and dark secrets. On the eve of their grand wedding, the bride of the esteemed Duke of Ravencroft disappears without a trace. Whispers of betrayal and curses spread through the halls of his ancestral estate as the search begins. As the Duke delves into the truth, he uncovers a web of deception, forbidden love, and a past that refuses to stay buried. Will he find his bride before it�s too late, or was she never meant to be his at all?", "https://images.pexels.com/photos/341372/pexels-photo-341372.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/5379080/pexels-photo-5379080.jpeg?auto=compress&cs=tinysrgb&w=600", 12.0, new DateTimeOffset(new DateTime(2025, 3, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Duke�s Vanishing Bride", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5418), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "7fbb0b83-634d-495d-ae47-4f1cd222f6e3", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5574), new TimeSpan(0, 0, 0, 0, 0)), "The Last Song of Venezia is a tale of love, loss, and the fading echoes of a once-glorious past. In the heart of Venice, a gifted musician composes his final masterpiece as the city around him sinks into the depths of time. Haunted by memories of a lost love and a promise left unfulfilled, he pours his soul into one last melody�a song that carries the sorrow of the past and the hope of redemption. As the notes drift through the moonlit canals, will his final song reunite him with his beloved, or will it be lost to the waters of Venezia forever?", "https://images.pexels.com/photos/2179373/pexels-photo-2179373.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/16122200/pexels-photo-16122200/free-photo-of-couple-lying-on-the-ground-and-man-playing-the-guitar.jpeg?auto=compress&cs=tinysrgb&w=600", 10.0, new DateTimeOffset(new DateTime(2025, 3, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Last Song of Venezia", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5576), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "953d2a63-7692-40cd-af54-cc3b0be2198b", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5665), new TimeSpan(0, 0, 0, 0, 0)), "The Enchanted Harp is a spellbinding tale of music, magic, and destiny. Hidden deep within an ancient forest lies a harp of otherworldly beauty, said to be blessed�or cursed�by the spirits of old. When a young musician stumbles upon the instrument and plays its haunting melody, they awaken a power that can either bring harmony to the world or unleash a darkness long forgotten. As whispers of its enchantment spread, forces both good and evil seek to claim its magic. Will the musician master the harp�s true power, or will they become another lost soul in its tragic melody?", "https://images.pexels.com/photos/8659662/pexels-photo-8659662.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/12970722/pexels-photo-12970722.jpeg?auto=compress&cs=tinysrgb&w=600", 10.5, new DateTimeOffset(new DateTime(2025, 3, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Enchanted Harp", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5666), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "99f730fc-5cfc-4ab9-9904-475db277df8d", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5757), new TimeSpan(0, 0, 0, 0, 0)), "Shadows of the Ivory Tower is a tale of ambition, secrets, and forbidden knowledge. Within the grand halls of the Ivory Tower, the world�s greatest scholars pursue wisdom�but some truths were never meant to be uncovered. When a young researcher stumbles upon a hidden manuscript, they awaken a mystery buried for centuries. As whispers of lost magic and betrayal echo through the tower�s ancient walls, they must navigate a web of deceit and danger before the shadows consume them. Will they uncover the truth, or become just another forgotten name in the tower�s dark history?", "https://images.pexels.com/photos/247506/pexels-photo-247506.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/30857245/pexels-photo-30857245/free-photo-of-majestic-plaza-de-espana-tower-in-seville.jpeg?auto=compress&cs=tinysrgb&w=600", 15.0, new DateTimeOffset(new DateTime(2025, 3, 7, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Shadows of the Ivory Tower", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5758), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "9b2e8328-1597-45d2-a95c-93f992a244cb", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5849), new TimeSpan(0, 0, 0, 0, 0)), "A Symphony of Vengeance is a haunting tale of betrayal, justice, and the power of music. When a brilliant composer is wronged by those he once trusted, he crafts his final masterpiece�not as a gift to the world, but as a requiem for his enemies. As the notes of his dark symphony rise, so too does a chilling force that seeks retribution. Each movement plays out like fate itself, drawing the guilty toward an inescapable reckoning. But as the final crescendo nears, will vengeance bring him peace�or will he become trapped in the melody of his own creation?", "https://images.pexels.com/photos/5721137/pexels-photo-5721137.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/7095824/pexels-photo-7095824.jpeg?auto=compress&cs=tinysrgb&w=600", 25.0, new DateTimeOffset(new DateTime(2025, 3, 7, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A Symphony of Vengeance", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5850), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "c0d775b9-6f43-4277-9046-26237bd06812", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5984), new TimeSpan(0, 0, 0, 0, 0)), "The Little Boy from Rosario is a touching story of dreams, determination, and destiny. In the humble streets of Rosario, a young boy with a heart full of passion and a ball at his feet dreams of greatness. Against all odds, he rises from the dusty fields to the grandest stages of the world, carrying with him the hopes of his people. But beyond the fame and glory, his journey is one of sacrifice, resilience, and an unbreakable love for the game. Will he become the legend he was meant to be, or will the weight of expectation be too much to bear?", "https://images.pexels.com/photos/14482441/pexels-photo-14482441.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3662942/pexels-photo-3662942.jpeg?auto=compress&cs=tinysrgb&w=600", 20.699999999999999, new DateTimeOffset(new DateTime(2025, 3, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Little Boy from Rosario", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(5985), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "fc7acc1e-11af-4fee-a7bf-79780fdc0b74", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(6072), new TimeSpan(0, 0, 0, 0, 0)), "The Phantom's Lament is a tragic tale of unrequited love, loss, and the search for redemption. Hidden in the shadows of an opulent opera house, a mysterious figure�a tormented soul, once full of promise�now haunts the halls, longing for the love he can never have. His heart aches with the music he once created, now transformed into a haunting melody that echoes his sorrow. As a young singer arrives at the opera house, she unknowingly becomes the object of his obsession. But will her voice be the key to his salvation, or will it only deepen the phantom's pain?", "https://images.prismic.io/royal-opera-house/8e4cb083-cc7d-431a-ab21-01333633e294_Die+Walkure_1+%C2%A92024+Sebastian+Nevols.jpg?auto=format,compress&rect=232,0,4636,3477&w=960&h=720", "https://images.pexels.com/photos/4584283/pexels-photo-4584283.jpeg?auto=compress&cs=tinysrgb&w=600", 10.699999999999999, new DateTimeOffset(new DateTime(2025, 3, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Phantom's Lament", 100, new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(6074), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "CreatedAt", "Price", "SeatNumber", "UpdatedAt" },
                values: new object[,]
                {
                    { "05771f62-9e56-453d-a6cc-a4f343c15de2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1060), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B18", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1144), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "070f2f6a-aee4-456d-9490-ffd9cf98e53d", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1439), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C3", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1441), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "084c51a2-39bd-471a-b4e2-484135c79a0c", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1471), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C15", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1472), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "0b75488b-e4d9-4792-81d9-560166dfe818", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1498), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B16", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1500), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "0bbc571b-37b5-41b6-abf6-81510e9157e3", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1528), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B4", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1529), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "0cc3a3d9-1266-4c55-97a7-dd9bfaad8eb1", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1558), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1559), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "100567d5-7d10-43ba-820c-deec115a412e", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1584), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C8", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1585), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "1ad46c57-7536-4063-810d-5f55d42e62c3", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1610), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C19", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1611), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "1da78035-7f04-4904-b2eb-6202dd57dff0", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1635), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B3", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1636), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "252a4c14-429d-4526-9638-ff0586b53727", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1662), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A9", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1663), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "257f01af-668a-45c6-afea-57f803aefc73", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1692), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C18", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1693), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "27ab386d-e915-4366-b597-d34e2dc1ce90", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1717), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C16", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1719), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "319650e7-4f2f-4641-b2ba-29b68d86a974", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1744), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B24", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1745), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "3bda5522-14c3-4be2-ba45-30d570355ab6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1770), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C10", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1771), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "47613868-64af-49de-93d2-5a1e163465db", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1795), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A1", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1796), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "49a95b29-4e16-485e-9420-74321e186e2b", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1821), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1822), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "4f6f10b6-bebb-486c-8d9a-b282756027d2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1847), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B1", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1848), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "55948949-7bda-4cb0-ad4f-931199e5952b", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1873), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C20", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1874), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5d7d91ca-9c9c-463b-bf4f-a296cabc5e86", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1898), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C5", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1899), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5ed45f51-e6f3-4892-8701-142799f25e26", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1965), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B11", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1966), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5f3baacd-9dc9-4980-8945-ef64df1a6b7b", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1993), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B10", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(1994), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5f96db84-14cc-4d18-a0f2-78b52437c265", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2018), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B9", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2019), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5fc9d0e3-ca78-485e-aa42-a2e471d5aa8c", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2043), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A11", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2044), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "604b5b86-f040-47d2-b3db-d43142ce1046", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2069), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B13", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2070), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "664d4968-820f-462b-837f-3884d6dc1343", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2094), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C7", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2095), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "6872b638-99d3-4e77-a153-47a9eefa64c5", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2118), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B8", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2119), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "6fe1a212-b510-456e-87de-c6a4a7b0049c", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2144), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C17", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2145), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "71716d6c-2227-4d20-88c1-87272dff9ccf", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2171), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B12", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2172), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "756a3b14-a0d7-46d5-8e76-cbcd04881d7a", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2197), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A8", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2198), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "825ef9b6-b683-483f-9b70-88436720c0c1", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2223), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C1", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2224), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "882a1648-227e-405f-9267-4f941b4e0208", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2248), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B5", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2249), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "8b344e93-d010-4090-9715-99e42f854db6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B14", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2274), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "93d9ed5e-199e-44bb-a993-b887d0b7691e", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2299), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2300), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "99e43ddc-d09f-4474-81e9-47d5dc5e067e", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2325), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C11", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2326), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "9c44ad50-d3d4-4e58-8e3d-172cafba9898", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2352), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B19", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2353), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "a35988f2-1016-4bf7-b98f-3c30dc595db4", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2378), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B7", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2379), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "a733a79c-18c4-4915-92db-a15c0b6243d2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B23", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2405), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "a9bdc283-7c30-4b5d-a6de-4d9784822cb4", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2430), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A7", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2431), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "abd840bc-9b47-48fb-96ec-19455c0ff85d", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2456), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A10", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2457), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ac044671-42fe-4950-a676-3b0777284631", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2482), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A3", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2483), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "af840077-9f8b-427c-8337-dc7e0b445972", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2546), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C4", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2547), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "b1c9ddb0-aeb7-46a8-8347-97cdfaff20d9", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2572), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B22", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2573), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "b214f8af-86dd-46fd-a349-8df1f49c616d", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2599), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A12", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2600), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "b68f3656-5e95-4a8e-bb83-f87dbc3588bc", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2625), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C12", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2626), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "b96fa7b8-9c34-45bf-be7d-a38041505911", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2651), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2652), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "c0c54ccc-7b22-4cca-b718-fc53bc06c8dd", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2678), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B20", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2679), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "c55e447f-1fb2-4fdf-bd49-5376ee4d0732", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2704), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A5", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2705), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ccd00467-a01e-4838-8271-3d01ebee2ea6", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2730), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B15", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2731), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "d87963ec-d4e7-4945-81e8-81a54e86baee", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2756), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2757), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "de3fac7e-e5d9-4d2d-b57e-f90d21980eeb", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2783), new TimeSpan(0, 0, 0, 0, 0)), 10.800000000000001, "A4", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2784), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "e27555b2-d6fd-4e78-8636-ca31620b15ec", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2808), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C9", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2809), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "e33adca6-80a8-464c-a26a-6898cf2e3b93", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C13", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2834), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ea6f69d8-ad99-461b-82eb-406232bbae23", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2861), new TimeSpan(0, 0, 0, 0, 0)), 7.0, "C2", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2862), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "ef4176f9-349c-4eac-bc6b-c507f8f1ec88", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2887), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "C14", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2888), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "f72ef714-09d2-4008-9d9b-4d7c63f9230b", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2914), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B21", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2915), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "f7354388-8406-4073-b23f-cb717c607c73", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2940), new TimeSpan(0, 0, 0, 0, 0)), 9.0, "B17", new DateTimeOffset(new DateTime(2025, 3, 15, 9, 44, 37, 480, DateTimeKind.Unspecified).AddTicks(2941), new TimeSpan(0, 0, 0, 0, 0)) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UserId",
                table: "Reservations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_PlayId",
                table: "Reviews",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PlayId",
                table: "Tickets",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ReservationId",
                table: "Tickets",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SeatId",
                table: "Tickets",
                column: "SeatId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Plays");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
