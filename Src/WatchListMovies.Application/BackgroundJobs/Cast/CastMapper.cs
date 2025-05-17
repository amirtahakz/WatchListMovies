using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.ValueObjects;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Application.BackgroundJobs.Cast
{
    public static class CastMapper
    {
        public static List<Domain.CastAgg.Cast> Map(this PopularCastsApiModelDto cast)
        {
            var result = new List<Domain.CastAgg.Cast>();
            foreach (var castItem in cast.Results)
            {
                var model = new Domain.CastAgg.Cast()
                {
                    Adult = castItem.Adult,
                    ApiModelId = castItem.Id,
                    Popularity = castItem.Popularity,
                    Gender = castItem.Gender,
                    KnownForDepartment = castItem.KnownForDepartment,
                    Name = castItem.Name,
                    OriginalName = castItem.OriginalName,
                    ProfilePath = castItem.ProfilePath,
                };
                if (castItem.KnownFor != null)
                {
                    foreach (var knownForItem in castItem.KnownFor)
                    {
                        var castKnownForModel = new CastKnownFor()
                        {
                            Adult = knownForItem.Adult,
                            ApiModelId = knownForItem.Id,
                            BackdropPath = knownForItem.BackdropPath,
                            CastId = model.Id,
                            MediaType = knownForItem.MediaType,
                            OriginalLanguage = knownForItem.OriginalLanguage,
                            OriginalTitle = knownForItem.OriginalTitle,
                            Overview = knownForItem.Overview,
                            Popularity = knownForItem.Popularity,
                            PosterPath = knownForItem.PosterPath,
                            ReleaseDate = knownForItem.ReleaseDate,
                            Title = knownForItem.Title,
                            Video = knownForItem.Video,
                            VoteAverage = knownForItem.VoteAverage,
                            VoteCount = knownForItem.VoteCount,
                        };
                        if (knownForItem.GenreIds != null)
                        {
                            foreach (var genreIdsItem in knownForItem.GenreIds)
                            {
                                castKnownForModel.CastKnownForGenreIds = new List<Domain._Shared.ValueObjects.Genre>()
                                {
                                    new()
                                    {
                                        ApiModelId = genreIdsItem,
                                        MediaId = model.Id,
                                    }
                                };
                            }
                        }

                        model.CastKnownFors = new List<CastKnownFor>() { castKnownForModel };

                    }
                }
                result.Add(model);
            }
            return result;
        }

        public static CastDetail Map(this CastDetailsApiModelDto castDetails, Guid castId)
        {
            var result = new CastDetail()
            {
                Adult = castDetails.Adult,
                ApiModelId = castDetails.Id,
                Homepage = castDetails.Homepage,
                ImdbId = castDetails.ImdbId,
                Popularity = castDetails.Popularity,
                Biography = castDetails.Biography,
                Birthday = castDetails.Birthday,
                CastId = castId,
                Deathday = castDetails.Deathday,
                Gender = castDetails.Gender,
                KnownForDepartment = castDetails.KnownForDepartment,
                Name = castDetails.Name,
                PlaceOfBirth = castDetails.PlaceOfBirth,
                ProfilePath = castDetails.ProfilePath,
                CastAlsoKnownAss = castDetails.AlsoKnownAs

            };

            return result;
        }

        public static CastExternalId Map(this CastExternalIdsApiModelDto castExternalIds, Guid castId)
        {
            var result = new CastExternalId()
            {
                ApiModelId = castExternalIds.Id,
                CastId = castId,
                FacebookId = castExternalIds.FacebookId,
                FreebaseId = castExternalIds.FreebaseId,
                FreebaseMid = castExternalIds.FreebaseMid,
                ImdbId = castExternalIds.ImdbId,
                InstagramId = castExternalIds.InstagramId,
                TiktokId = castExternalIds.TiktokId,
                TvrageId = castExternalIds.TvrageId,
                TwitterId = castExternalIds.TwitterId,
                WikidataId = castExternalIds.WikidataId,
                YoutubeId = castExternalIds.YoutubeId,

            };

            return result;
        }

        public static List<CastImage> Map(this CastImagesApiModelDto castImages, Guid castId)
        {
            var result = new List<CastImage>();

            if (castImages.Profiles != null)
            {
                foreach (var item in castImages.Profiles)
                {
                    var model = new CastImage()
                    {
                        CastId = castId,
                        AspectRatio = item.AspectRatio,
                        FilePath = item.FilePath,
                        Height = item.Height,
                        Iso6391 = item.Iso6391,
                        VoteAverage = item.VoteAverage,
                        VoteCount = item.VoteCount,
                        Width = item.Width,
                    };
                    result.Add(model);
                }
            }

            return result;
        }
    }
}
