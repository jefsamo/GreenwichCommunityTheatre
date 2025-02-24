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
                    AvailableSeats = table.Column<int>(type: "int", nullable: false),
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
                    { "207ab2d0-1c09-462c-ad0f-a3af507beaf6", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(1655), new TimeSpan(0, 0, 0, 0, 0)), "In The Curse of the Crimson Rose, a mysterious, blood-red rose holds a dark secret�one that brings misfortune to all who possess it. When a young scholar stumbles upon the cursed bloom in an abandoned manor, they are thrust into a web of ancient betrayals, forbidden love, and supernatural vengeance. As the curse tightens its grip, they must unravel its tragic origins before it consumes their soul forever.", "https://images.pexels.com/photos/593655/pexels-photo-593655.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/1187079/pexels-photo-1187079.jpeg?auto=compress&cs=tinysrgb&w=600", 10.0, new DateTimeOffset(new DateTime(2025, 3, 23, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Curse of the Crimson Rose", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(1743), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "23071501-babe-451f-90de-b6ffb9c8345c", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2163), new TimeSpan(0, 0, 0, 0, 0)), "Whispers in the Moonlight is a haunting tale of love, mystery, and the supernatural. When a lone traveler arrives in a secluded village, they begin hearing eerie whispers carried by the night breeze�voices that speak of long-buried secrets and unfinished fates. As they unravel the village�s dark history, they realize the whispers are leading them toward a truth that could change everything� or trap them in the moonlit shadows forever.", "https://images.pexels.com/photos/920534/pexels-photo-920534.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3489072/pexels-photo-3489072.jpeg?auto=compress&cs=tinysrgb&w=600", 8.5, new DateTimeOffset(new DateTime(2025, 3, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Whispers in the Moonlight", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2165), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "2f34bf6c-fed4-417c-a4b4-4294b486a6c2", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, 0, 0, 0, 0)), "The Queen�s Betrayal is a gripping tale of power, deception, and revenge. When a beloved queen uncovers a web of treachery within her own court, she must choose between loyalty to her kingdom and a dangerous secret that could shatter the throne. As whispers of betrayal grow louder and enemies close in from all sides, she must outwit those who seek to destroy her�before the crown slips from her grasp forever.", "https://images.pexels.com/photos/260024/pexels-photo-260024.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3095593/pexels-photo-3095593.jpeg?auto=compress&cs=tinysrgb&w=600", 20.0, new DateTimeOffset(new DateTime(2025, 3, 23, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Queen�s Betrayal", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2262), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "5d15acd2-b01c-4729-9e24-f7f5b436246f", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2348), new TimeSpan(0, 0, 0, 0, 0)), "Echoes of the Forbidden Love is a poignant tale of passion, sacrifice, and destiny. When two star-crossed lovers defy the laws that keep them apart, their forbidden romance sets off a chain of tragic events. Years later, their whispers still linger in the wind, haunting the ruins where they once met in secret. As a new pair of lovers uncovers their story, they find themselves drawn into the echoes of a love that refused to be silenced�one that may yet demand a final Price.", "https://images.prismic.io/royal-opera-house/021d3d96-e550-438c-93e9-712149c5fcfa_Carmen_ROH_3664-web.jpg?auto=compress,format&rect=172,337,3111,2333&w=960&h=720", "https://images.pexels.com/photos/1535288/pexels-photo-1535288.jpeg?auto=compress&cs=tinysrgb&w=600", 15.0, new DateTimeOffset(new DateTime(2025, 3, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Echoes of the Forbidden Love", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2350), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "74c9c3a1-7a9f-46ac-8369-6f4c66f30201", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2484), new TimeSpan(0, 0, 0, 0, 0)), "The Duke�s Vanishing Bride is a tale of mystery, romance, and dark secrets. On the eve of their grand wedding, the bride of the esteemed Duke of Ravencroft disappears without a trace. Whispers of betrayal and curses spread through the halls of his ancestral estate as the search begins. As the Duke delves into the truth, he uncovers a web of deception, forbidden love, and a past that refuses to stay buried. Will he find his bride before it�s too late, or was she never meant to be his at all?", "https://images.pexels.com/photos/341372/pexels-photo-341372.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/5379080/pexels-photo-5379080.jpeg?auto=compress&cs=tinysrgb&w=600", 12.0, new DateTimeOffset(new DateTime(2025, 3, 7, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Duke�s Vanishing Bride", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2485), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "7fbb0b83-634d-495d-ae47-4f1cd222f6e3", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2575), new TimeSpan(0, 0, 0, 0, 0)), "The Last Song of Venezia is a tale of love, loss, and the fading echoes of a once-glorious past. In the heart of Venice, a gifted musician composes his final masterpiece as the city around him sinks into the depths of time. Haunted by memories of a lost love and a promise left unfulfilled, he pours his soul into one last melody�a song that carries the sorrow of the past and the hope of redemption. As the notes drift through the moonlit canals, will his final song reunite him with his beloved, or will it be lost to the waters of Venezia forever?", "https://images.pexels.com/photos/2179373/pexels-photo-2179373.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/16122200/pexels-photo-16122200/free-photo-of-couple-lying-on-the-ground-and-man-playing-the-guitar.jpeg?auto=compress&cs=tinysrgb&w=600", 10.0, new DateTimeOffset(new DateTime(2025, 3, 13, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Last Song of Venezia", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2576), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "953d2a63-7692-40cd-af54-cc3b0be2198b", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2668), new TimeSpan(0, 0, 0, 0, 0)), "The Enchanted Harp is a spellbinding tale of music, magic, and destiny. Hidden deep within an ancient forest lies a harp of otherworldly beauty, said to be blessed�or cursed�by the spirits of old. When a young musician stumbles upon the instrument and plays its haunting melody, they awaken a power that can either bring harmony to the world or unleash a darkness long forgotten. As whispers of its enchantment spread, forces both good and evil seek to claim its magic. Will the musician master the harp�s true power, or will they become another lost soul in its tragic melody?", "https://images.pexels.com/photos/8659662/pexels-photo-8659662.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/12970722/pexels-photo-12970722.jpeg?auto=compress&cs=tinysrgb&w=600", 10.5, new DateTimeOffset(new DateTime(2025, 3, 17, 20, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Enchanted Harp", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2669), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "99f730fc-5cfc-4ab9-9904-475db277df8d", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2760), new TimeSpan(0, 0, 0, 0, 0)), "Shadows of the Ivory Tower is a tale of ambition, secrets, and forbidden knowledge. Within the grand halls of the Ivory Tower, the world�s greatest scholars pursue wisdom�but some truths were never meant to be uncovered. When a young researcher stumbles upon a hidden manuscript, they awaken a mystery buried for centuries. As whispers of lost magic and betrayal echo through the tower�s ancient walls, they must navigate a web of deceit and danger before the shadows consume them. Will they uncover the truth, or become just another forgotten name in the tower�s dark history?", "https://images.pexels.com/photos/247506/pexels-photo-247506.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/30857245/pexels-photo-30857245/free-photo-of-majestic-plaza-de-espana-tower-in-seville.jpeg?auto=compress&cs=tinysrgb&w=600", 15.0, new DateTimeOffset(new DateTime(2025, 3, 7, 17, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "Shadows of the Ivory Tower", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2762), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "9b2e8328-1597-45d2-a95c-93f992a244cb", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2883), new TimeSpan(0, 0, 0, 0, 0)), "A Symphony of Vengeance is a haunting tale of betrayal, justice, and the power of music. When a brilliant composer is wronged by those he once trusted, he crafts his final masterpiece�not as a gift to the world, but as a requiem for his enemies. As the notes of his dark symphony rise, so too does a chilling force that seeks retribution. Each movement plays out like fate itself, drawing the guilty toward an inescapable reckoning. But as the final crescendo nears, will vengeance bring him peace�or will he become trapped in the melody of his own creation?", "https://images.pexels.com/photos/5721137/pexels-photo-5721137.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/7095824/pexels-photo-7095824.jpeg?auto=compress&cs=tinysrgb&w=600", 25.0, new DateTimeOffset(new DateTime(2025, 3, 7, 15, 30, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "A Symphony of Vengeance", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2885), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "c0d775b9-6f43-4277-9046-26237bd06812", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2975), new TimeSpan(0, 0, 0, 0, 0)), "The Little Boy from Rosario is a touching story of dreams, determination, and destiny. In the humble streets of Rosario, a young boy with a heart full of passion and a ball at his feet dreams of greatness. Against all odds, he rises from the dusty fields to the grandest stages of the world, carrying with him the hopes of his people. But beyond the fame and glory, his journey is one of sacrifice, resilience, and an unbreakable love for the game. Will he become the legend he was meant to be, or will the weight of expectation be too much to bear?", "https://images.pexels.com/photos/14482441/pexels-photo-14482441.jpeg?auto=compress&cs=tinysrgb&w=600", "https://images.pexels.com/photos/3662942/pexels-photo-3662942.jpeg?auto=compress&cs=tinysrgb&w=600", 20.699999999999999, new DateTimeOffset(new DateTime(2025, 3, 20, 18, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Little Boy from Rosario", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(2977), new TimeSpan(0, 0, 0, 0, 0)) },
                    { "fc7acc1e-11af-4fee-a7bf-79780fdc0b74", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(3064), new TimeSpan(0, 0, 0, 0, 0)), "The Phantom's Lament is a tragic tale of unrequited love, loss, and the search for redemption. Hidden in the shadows of an opulent opera house, a mysterious figure�a tormented soul, once full of promise�now haunts the halls, longing for the love he can never have. His heart aches with the music he once created, now transformed into a haunting melody that echoes his sorrow. As a young singer arrives at the opera house, she unknowingly becomes the object of his obsession. But will her voice be the key to his salvation, or will it only deepen the phantom's pain?", "https://images.prismic.io/royal-opera-house/8e4cb083-cc7d-431a-ab21-01333633e294_Die+Walkure_1+%C2%A92024+Sebastian+Nevols.jpg?auto=format,compress&rect=232,0,4636,3477&w=960&h=720", "https://images.pexels.com/photos/4584283/pexels-photo-4584283.jpeg?auto=compress&cs=tinysrgb&w=600", 10.699999999999999, new DateTimeOffset(new DateTime(2025, 3, 20, 15, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)), "The Phantom's Lament", 100, new DateTimeOffset(new DateTime(2025, 2, 24, 10, 17, 56, 341, DateTimeKind.Unspecified).AddTicks(3066), new TimeSpan(0, 0, 0, 0, 0)) }
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
