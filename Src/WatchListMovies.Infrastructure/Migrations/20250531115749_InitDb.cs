using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WatchListMovies.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "movie");

            migrationBuilder.EnsureSchema(
                name: "cast");

            migrationBuilder.EnsureSchema(
                name: "tv");

            migrationBuilder.EnsureSchema(
                name: "user");

            migrationBuilder.CreateTable(
                name: "Casts",
                schema: "cast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<long>(type: "bigint", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SubjectId = table.Column<long>(type: "bigint", nullable: true),
                    ListId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FavoriteType = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GenreType = table.Column<int>(type: "int", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ListType = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Video = table.Column<bool>(type: "bit", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<int>(type: "int", nullable: true),
                    IsRecommendedByAdmin = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    GenreIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tvs",
                schema: "tv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    IsRecommendedByAdmin = table.Column<bool>(type: "bit", nullable: true, defaultValue: false),
                    GenreIds = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tvs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Family = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AvatarName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CastDetails",
                schema: "cast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Birthday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deathday = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastAlsoKnownAss = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastDetails_Casts_CastId",
                        column: x => x.CastId,
                        principalSchema: "cast",
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastExternalId",
                schema: "cast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    FreebaseMid = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FreebaseId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvrageId = table.Column<long>(type: "bigint", nullable: true),
                    WikidataId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FacebookId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstagramId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TiktokId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwitterId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YoutubeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastExternalId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastExternalId_Casts_CastId",
                        column: x => x.CastId,
                        principalSchema: "cast",
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastImages",
                schema: "cast",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AspectRatio = table.Column<double>(type: "float", nullable: true),
                    Height = table.Column<long>(type: "bigint", nullable: true),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    Width = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CastImages_Casts_CastId",
                        column: x => x.CastId,
                        principalSchema: "cast",
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastKnownFors",
                schema: "cast",
                columns: table => new
                {
                    CastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MediaType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Video = table.Column<bool>(type: "bit", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastKnownFors", x => new { x.CastId, x.Id });
                    table.ForeignKey(
                        name: "FK_CastKnownFors_Casts_CastId",
                        column: x => x.CastId,
                        principalSchema: "cast",
                        principalTable: "Casts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetails",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Budget = table.Column<long>(type: "bigint", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    ImdbId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Revenue = table.Column<long>(type: "bigint", nullable: true),
                    Runtime = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Video = table.Column<bool>(type: "bit", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDetails_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "movie",
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvDetails",
                schema: "tv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TvId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstAirDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Homepage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InProduction = table.Column<bool>(type: "bit", nullable: true),
                    LastAirDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumberOfEpisodes = table.Column<long>(type: "bigint", nullable: true),
                    NumberOfSeasons = table.Column<long>(type: "bigint", nullable: true),
                    OriginalLanguage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<double>(type: "float", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    TvEpisodeRunTimes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvDetails_Tvs_TvId",
                        column: x => x.TvId,
                        principalSchema: "tv",
                        principalTable: "Tvs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                schema: "user",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HashJwtToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    HashRefreshToken = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    TokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RefreshTokenExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Device = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "user",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CastKnownForGenreIds",
                schema: "cast",
                columns: table => new
                {
                    CastKnownForValueObjectCastId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CastKnownForValueObjectId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CastKnownForGenreIds", x => new { x.CastKnownForValueObjectCastId, x.CastKnownForValueObjectId, x.Id });
                    table.ForeignKey(
                        name: "FK_CastKnownForGenreIds_CastKnownFors_CastKnownForValueObjectCastId_CastKnownForValueObjectId",
                        columns: x => new { x.CastKnownForValueObjectCastId, x.CastKnownForValueObjectId },
                        principalSchema: "cast",
                        principalTable: "CastKnownFors",
                        principalColumns: new[] { "CastId", "Id" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BelongsToCollections",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BackdropPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BelongsToCollections", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_BelongsToCollections_MovieDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_Genres_MovieDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCasts",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastId = table.Column<long>(type: "bigint", nullable: true),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    MovieDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCasts_MovieDetails_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCrews",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MovieDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCrews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieCrews_MovieDetails_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieKeyYoutubeTrailers",
                schema: "movie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApiModelId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Site = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Official = table.Column<bool>(type: "bit", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MovieDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieKeyYoutubeTrailers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieKeyYoutubeTrailers_MovieDetails_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_MovieDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCountries_MovieDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "movie",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => new { x.CreationDate, x.MediaId, x.EnglishName });
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_MovieDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "movie",
                        principalTable: "MovieDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreatedBys",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreatedBys", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_CreatedBys_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EpisodeToAirs",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true),
                    VoteCount = table.Column<long>(type: "bigint", nullable: true),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EpisodeNumber = table.Column<long>(type: "bigint", nullable: true),
                    EpisodeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    StillPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeAirType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodeToAirs", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_EpisodeToAirs_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_Genres_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Networks",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Networks", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_Networks_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCompanies",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    LogoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginCountry = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCompanies", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCompanies_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso31661 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_ProductionCountries_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seasons",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EpisodeCount = table.Column<long>(type: "bigint", nullable: true),
                    SeasonNumber = table.Column<long>(type: "bigint", nullable: true),
                    AirDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PosterPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VoteAverage = table.Column<float>(type: "real", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seasons", x => new { x.CreationDate, x.MediaId, x.Name });
                    table.ForeignKey(
                        name: "FK_Seasons_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpokenLanguages",
                schema: "tv",
                columns: table => new
                {
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MediaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnglishName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Iso6391 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpokenLanguages", x => new { x.CreationDate, x.MediaId, x.EnglishName });
                    table.ForeignKey(
                        name: "FK_SpokenLanguages_TvDetails_MediaId",
                        column: x => x.MediaId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvCasts",
                schema: "tv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CastId = table.Column<long>(type: "bigint", nullable: true),
                    Character = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Order = table.Column<int>(type: "int", nullable: true),
                    TvDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvCasts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvCasts_TvDetails_TvDetailId",
                        column: x => x.TvDetailId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TvCrews",
                schema: "tv",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MovieDetailsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Adult = table.Column<bool>(type: "bit", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: true),
                    ApiModelId = table.Column<long>(type: "bigint", nullable: true),
                    KnownForDepartment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginalName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Popularity = table.Column<double>(type: "float", nullable: true),
                    ProfilePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Job = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TvDetailId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvCrews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TvCrews_TvDetails_TvDetailId",
                        column: x => x.TvDetailId,
                        principalSchema: "tv",
                        principalTable: "TvDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BelongsToCollections_MediaId",
                schema: "movie",
                table: "BelongsToCollections",
                column: "MediaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastDetails_ApiModelId",
                schema: "cast",
                table: "CastDetails",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CastDetails_CastId",
                schema: "cast",
                table: "CastDetails",
                column: "CastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastExternalId_ApiModelId",
                schema: "cast",
                table: "CastExternalId",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CastExternalId_CastId",
                schema: "cast",
                table: "CastExternalId",
                column: "CastId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CastImages_CastId",
                schema: "cast",
                table: "CastImages",
                column: "CastId");

            migrationBuilder.CreateIndex(
                name: "IX_CastKnownFors_ApiModelId",
                schema: "cast",
                table: "CastKnownFors",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CastKnownFors_CastId",
                schema: "cast",
                table: "CastKnownFors",
                column: "CastId");

            migrationBuilder.CreateIndex(
                name: "IX_CastKnownFors_OriginalTitle",
                schema: "cast",
                table: "CastKnownFors",
                column: "OriginalTitle");

            migrationBuilder.CreateIndex(
                name: "IX_CastKnownFors_Title",
                schema: "cast",
                table: "CastKnownFors",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_ApiModelId",
                schema: "cast",
                table: "Casts",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_Gender",
                schema: "cast",
                table: "Casts",
                column: "Gender");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_Name",
                schema: "cast",
                table: "Casts",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Casts_OriginalName",
                schema: "cast",
                table: "Casts",
                column: "OriginalName");

            migrationBuilder.CreateIndex(
                name: "IX_CreatedBys_MediaId",
                schema: "tv",
                table: "CreatedBys",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_EpisodeToAirs_MediaId",
                schema: "tv",
                table: "EpisodeToAirs",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_ApiModelId",
                table: "Genres",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_GenreType",
                table: "Genres",
                column: "GenreType");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Name",
                table: "Genres",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MediaId",
                schema: "movie",
                table: "Genres",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_MediaId",
                schema: "tv",
                table: "Genres",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_ApiModelId",
                schema: "movie",
                table: "MovieCasts",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCasts_MovieDetailId",
                schema: "movie",
                table: "MovieCasts",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrews_ApiModelId",
                schema: "movie",
                table: "MovieCrews",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCrews_MovieDetailId",
                schema: "movie",
                table: "MovieCrews",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_ApiModelId",
                schema: "movie",
                table: "MovieDetails",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetails_MovieId",
                schema: "movie",
                table: "MovieDetails",
                column: "MovieId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyYoutubeTrailers_ApiModelId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieKeyYoutubeTrailers_MovieDetailId",
                schema: "movie",
                table: "MovieKeyYoutubeTrailers",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ApiModelId",
                schema: "movie",
                table: "Movies",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_OriginalTitle",
                schema: "movie",
                table: "Movies",
                column: "OriginalTitle");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ReleaseDate",
                schema: "movie",
                table: "Movies",
                column: "ReleaseDate");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_Title",
                schema: "movie",
                table: "Movies",
                column: "Title");

            migrationBuilder.CreateIndex(
                name: "IX_Networks_MediaId",
                schema: "tv",
                table: "Networks",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_MediaId",
                schema: "movie",
                table: "ProductionCompanies",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCompanies_MediaId",
                schema: "tv",
                table: "ProductionCompanies",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCountries_MediaId",
                schema: "movie",
                table: "ProductionCountries",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCountries_MediaId",
                schema: "tv",
                table: "ProductionCountries",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_MediaId",
                schema: "tv",
                table: "Seasons",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_MediaId",
                schema: "movie",
                table: "SpokenLanguages",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_SpokenLanguages_MediaId",
                schema: "tv",
                table: "SpokenLanguages",
                column: "MediaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                schema: "user",
                table: "Tokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TvCasts_ApiModelId",
                schema: "tv",
                table: "TvCasts",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TvCasts_TvDetailId",
                schema: "tv",
                table: "TvCasts",
                column: "TvDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TvCrews_ApiModelId",
                schema: "tv",
                table: "TvCrews",
                column: "ApiModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TvCrews_TvDetailId",
                schema: "tv",
                table: "TvCrews",
                column: "TvDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_TvDetails_ApiModelId",
                schema: "tv",
                table: "TvDetails",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TvDetails_TvId",
                schema: "tv",
                table: "TvDetails",
                column: "TvId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tvs_ApiModelId",
                schema: "tv",
                table: "Tvs",
                column: "ApiModelId",
                unique: true,
                filter: "[ApiModelId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Tvs_Name",
                schema: "tv",
                table: "Tvs",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Tvs_OriginalName",
                schema: "tv",
                table: "Tvs",
                column: "OriginalName");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "user",
                table: "Users",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                schema: "user",
                table: "Users",
                column: "PhoneNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BelongsToCollections",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "CastDetails",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "CastExternalId",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "CastImages",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "CastKnownForGenreIds",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "CreatedBys",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "EpisodeToAirs",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "MovieCasts",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "MovieCrews",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "MovieKeyYoutubeTrailers",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Networks",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "ProductionCompanies",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "ProductionCompanies",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "ProductionCountries",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "ProductionCountries",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Seasons",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "SpokenLanguages",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Tokens",
                schema: "user");

            migrationBuilder.DropTable(
                name: "TvCasts",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "TvCrews",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "CastKnownFors",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "MovieDetails",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "user");

            migrationBuilder.DropTable(
                name: "TvDetails",
                schema: "tv");

            migrationBuilder.DropTable(
                name: "Casts",
                schema: "cast");

            migrationBuilder.DropTable(
                name: "Movies",
                schema: "movie");

            migrationBuilder.DropTable(
                name: "Tvs",
                schema: "tv");
        }
    }
}
