using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.TvAgg.ValueObjects;

namespace WatchListMovies.Application.BackgroundJobs.Tv
{
    public static class TvMapper
    {
        public static List<Domain.TvAgg.Tv> Map(this PopularTvsApiModelDto tv)
        {
            var result = new List<Domain.TvAgg.Tv>();
            foreach (var item in tv.Results)
            {
                var model = new Domain.TvAgg.Tv()
                {
                    Adult = item.Adult,
                    ApiModelId = item.Id,
                    BackdropPath = item.BackdropPath,
                    OriginalLanguage = item.OriginalLanguage,
                    Overview = item.Overview,
                    Popularity = item.Popularity,
                    PosterPath = item.PosterPath,
                    VoteAverage = item.VoteAverage,
                    VoteCount = item.VoteCount,
                    Name = item.Name,
                    FirstAirDate = item.FirstAirDate,
                    OriginalName = item.OriginalName,
                };
                result.Add(model);
            }
            return result;
        }

        public static TvDetail Map(this TvDetailsApiModelDto tvDetails, Guid tvId)
        {
            var result = new TvDetail()
            {
                Adult = tvDetails.Adult,
                ApiModelId = tvDetails.Id,
                BackdropPath = tvDetails.BackdropPath,
                Homepage = tvDetails.Homepage,
                OriginalLanguage = tvDetails.OriginalLanguage,
                Popularity = tvDetails.Popularity,
                PosterPath = tvDetails.PosterPath,
                Overview = tvDetails.Overview,
                Status = tvDetails.Status,
                Tagline = tvDetails.Tagline,
                VoteCount = tvDetails.VoteCount,
                VoteAverage = tvDetails.VoteAverage,
                Name = tvDetails.Name,
                OriginalName = tvDetails.OriginalName,
                FirstAirDate = tvDetails.FirstAirDate,
                InProduction = tvDetails.InProduction,
                LastAirDate = tvDetails.LastAirDate,
                NumberOfEpisodes = tvDetails.NumberOfEpisodes,
                NumberOfSeasons = tvDetails.NumberOfSeasons,
                TvId = tvId,
                Type = tvDetails.Type,
                TvEpisodeRunTimes = tvDetails.EpisodeRunTime.Select(l => l.ToString()).ToList() ?? default,
            };

            if (tvDetails.Genres != null)
            {
                foreach (var item in tvDetails.Genres)
                {
                    result.Genres = new List<Domain._Shared.ValueObjects.Genre>()
                    {
                        new ()
                        {
                            ApiModelId = item.Id,
                            Name = item.Name,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (tvDetails.SpokenLanguages != null)
            {
                foreach (var item in tvDetails.SpokenLanguages)
                {
                    result.SpokenLanguages = new List<Domain._Shared.ValueObjects.SpokenLanguage>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            EnglishName = item.EnglishName,
                            Iso6391 = item.Iso6391,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (tvDetails.ProductionCompanies != null)
            {
                foreach (var item in tvDetails.ProductionCompanies)
                {
                    result.ProductionCompanies = new List<Domain._Shared.ValueObjects.ProductionCompany>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            LogoPath = item.LogoPath,
                            OriginCountry = item.OriginCountry,
                            ApiModelId = item.Id,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (tvDetails.ProductionCountries != null)
            {
                foreach (var item in tvDetails.ProductionCountries)
                {
                    result.ProductionCountries = new List<Domain._Shared.ValueObjects.ProductionCountry>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            Iso31661 = item.Iso31661,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (tvDetails.Seasons != null)
            {
                foreach (var item in tvDetails.Seasons)
                {
                    result.Seasons = new List<Domain.TvAgg.ValueObjects.Season>()
                    {
                        new ()
                        {
                            PosterPath = item.PosterPath,
                            ApiModelId = item.Id,
                            Name = item.Name,
                            AirDate = item.AirDate,
                            EpisodeCount = item.EpisodeCount,
                            MediaId=result.Id,
                            Overview = item.Overview,
                            SeasonNumber = item.SeasonNumber,
                            VoteAverage = item.VoteAverage,

                        }
                    };
                }
            }

            if (tvDetails.Networks != null)
            {
                foreach (var item in tvDetails.Networks)
                {
                    result.Networks = new List<Domain.TvAgg.ValueObjects.Network>()
                    {
                        new ()
                        {
                            ApiModelId = item.Id,
                            Name = item.Name,
                            MediaId=result.Id,
                            LogoPath = item.LogoPath,
                            OriginCountry = item.OriginCountry,
                        }
                    };
                }
            }

            if (tvDetails.CreatedBy != null)
            {
                foreach (var item in tvDetails.CreatedBy)
                {
                    result.CreatedBys = new List<Domain.TvAgg.ValueObjects.CreatedBy>()
                    {
                        new ()
                        {
                            ApiModelId = item.Id,
                            Name = item.Name,
                            MediaId=result.Id,
                            Gender = item.Gender,
                            OriginalName = item.OriginalName,
                            ProfilePath = item.ProfilePath
                        }
                    };
                }
            }


            if (tvDetails.NextEpisodeToAir != null)
            {
                result.EpisodeToAirs = new List<Domain.TvAgg.ValueObjects.Episode>()
                {
                    new()
                    {
                        EpisodeAirType = Domain.TvAgg.Enums.EpisodeAirType.NextEpisodeToAir,
                        AirDate = tvDetails.NextEpisodeToAir.AirDate,
                        ApiModelId = tvDetails.NextEpisodeToAir.Id,
                        EpisodeNumber = tvDetails.NextEpisodeToAir.EpisodeNumber ,
                        EpisodeType = tvDetails.NextEpisodeToAir.EpisodeType ,
                        MediaId = result.Id,
                        Name = tvDetails.NextEpisodeToAir.Name,
                        Overview = tvDetails.NextEpisodeToAir.Overview,
                        SeasonNumber = tvDetails.NextEpisodeToAir.SeasonNumber,
                        StillPath = tvDetails.NextEpisodeToAir.StillPath,
                        VoteAverage  =tvDetails.NextEpisodeToAir.VoteAverage,
                        VoteCount = tvDetails.NextEpisodeToAir.VoteCount,
                    }
                };

            }

            if (tvDetails.LastEpisodeToAir != null)
            {
                result.EpisodeToAirs = new List<Domain.TvAgg.ValueObjects.Episode>()
                {
                    new()
                    {
                        EpisodeAirType = Domain.TvAgg.Enums.EpisodeAirType.LastEpisodeToAir,
                        AirDate = tvDetails.LastEpisodeToAir.AirDate,
                        ApiModelId = tvDetails.LastEpisodeToAir.Id,
                        EpisodeNumber = tvDetails.LastEpisodeToAir.EpisodeNumber ,
                        EpisodeType = tvDetails.LastEpisodeToAir.EpisodeType ,
                        MediaId = result.Id,
                        Name = tvDetails.LastEpisodeToAir.Name,
                        Overview = tvDetails.LastEpisodeToAir.Overview,
                        SeasonNumber = tvDetails.LastEpisodeToAir.SeasonNumber,
                        StillPath = tvDetails.LastEpisodeToAir.StillPath,
                        VoteAverage  =tvDetails.LastEpisodeToAir.VoteAverage,
                        VoteCount = tvDetails.LastEpisodeToAir.VoteCount,
                    }
                };

            }

            return result;
        }
    }
}
