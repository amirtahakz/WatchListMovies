using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.TvAgg.Enums;
using WatchListMovies.Domain.TvAgg.ValueObjects;

namespace WatchListMovies.Application.BackgroundJobs.Tv
{
    public static class TvMapper
    {
        public static List<Domain.TvAgg.Tv> Map(this PopularTvsApiModelDto popularTvsApiModelDto)
        {
            var result = new List<Domain.TvAgg.Tv>();

            foreach (var item in popularTvsApiModelDto.Tvs)
                result.Add(item.Map());

            return result;
        }

        public static Domain.TvAgg.Tv Map(this PopularTvsItemApiModelDto popularTvsItemApiModelDto)
        {
            var result = new Domain.TvAgg.Tv()
            {
                Adult = popularTvsItemApiModelDto.Adult,
                ApiModelId = popularTvsItemApiModelDto.Id,
                BackdropPath = popularTvsItemApiModelDto.BackdropPath,
                OriginalLanguage = popularTvsItemApiModelDto.OriginalLanguage,
                Overview = popularTvsItemApiModelDto.Overview,
                Popularity = popularTvsItemApiModelDto.Popularity,
                PosterPath = popularTvsItemApiModelDto.PosterPath,
                VoteAverage = popularTvsItemApiModelDto.VoteAverage,
                VoteCount = popularTvsItemApiModelDto.VoteCount,
                Name = popularTvsItemApiModelDto.Name,
                FirstAirDate = popularTvsItemApiModelDto.FirstAirDate,
                OriginalName = popularTvsItemApiModelDto.OriginalName,
                GenreIds = popularTvsItemApiModelDto.GenreIds,
            };
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
                TvEpisodeRunTimes = tvDetails.EpisodeRunTime,
            };

            if (tvDetails.Genres != null)
                result.GenreIds = tvDetails.Genres.Where(g => g.ApiModelId.HasValue).Select(g => g.ApiModelId.Value.ToString()).ToList().AsReadOnly();

            if (tvDetails.SpokenLanguages != null)
                result.LanguageIds = tvDetails.SpokenLanguages.Select(g => g.Iso6391).ToList();

            if (tvDetails.ProductionCompanies != null)
                result.CompanyIds = tvDetails.ProductionCompanies.Where(g => g.ApiModelId.HasValue).Select(g => g.ApiModelId.Value.ToString()).ToList().AsReadOnly();

            if (tvDetails.ProductionCountries != null)
                result.CountryIds = tvDetails.ProductionCountries.Select(g => g.Iso31661).ToList().AsReadOnly();

            if (tvDetails.Seasons != null)
                result.Seasons = tvDetails.Seasons.Map(result.Id);

            if (tvDetails.Networks != null)
                result.Networks = tvDetails.Networks.Map(result.Id);

            if (tvDetails.CreatedBy != null)
                result.CreatedBys = tvDetails.CreatedBy.Map(result.Id);

            if (tvDetails.LastEpisodeToAir != null)
                result.EpisodeToAirs = new List<EpisodeValueObject>() { tvDetails.LastEpisodeToAir.Map(result.Id, EpisodeAirType.LastEpisodeToAir) };

            if (tvDetails.NextEpisodeToAir != null)
                result.EpisodeToAirs = new List<EpisodeValueObject>() { tvDetails.NextEpisodeToAir.Map(result.Id, EpisodeAirType.NextEpisodeToAir) };


            return result;
        }


        public static SeasonValueObject Map(this SeasonApiModelDto seasonApi, Guid tvDetailId)
        {
            var result = new SeasonValueObject()
            {
                PosterPath = seasonApi.PosterPath,
                ApiModelId = seasonApi.Id,
                Name = seasonApi.Name,
                AirDate = seasonApi.AirDate,
                EpisodeCount = seasonApi.EpisodeCount,
                ParrentId = tvDetailId,
                Overview = seasonApi.Overview,
                SeasonNumber = seasonApi.SeasonNumber,
                VoteAverage = seasonApi.VoteAverage,

            };
            return result;
        }

        public static List<SeasonValueObject> Map(this List<SeasonApiModelDto> seasonApis, Guid tvDetailId)
        {
            var result = new List<SeasonValueObject>();

            foreach (var seasonApi in seasonApis)
                result.Add(seasonApi.Map(tvDetailId));

            return result;
        }

        public static NetworkValueObject Map(this NetworkApiModelDto networkApi, Guid tvDetailId)
        {
            var result = new NetworkValueObject()
            {
                ApiModelId = networkApi.Id,
                Name = networkApi.Name,
                ParrentId = tvDetailId,
                LogoPath = networkApi.LogoPath,
                OriginCountry = networkApi.OriginCountry,
            };
            return result;
        }

        public static List<NetworkValueObject> Map(this List<NetworkApiModelDto> networkApis, Guid tvDetailId)
        {
            var result = new List<NetworkValueObject>();

            foreach (var networkApi in networkApis)
                result.Add(networkApi.Map(tvDetailId));

            return result;
        }

        public static CreatedByValueObject Map(this CreatedByApiModelDto createdBy, Guid tvDetailId)
        {
            var result = new CreatedByValueObject()
            {
                ApiModelId = createdBy.Id,
                Name = createdBy.Name,
                ParrentId = tvDetailId,
                Gender = createdBy.Gender,
                OriginalName = createdBy.OriginalName,
                ProfilePath = createdBy.ProfilePath
            };
            return result;
        }

        public static List<CreatedByValueObject> Map(this List<CreatedByApiModelDto> createdBys, Guid tvDetailId)
        {
            var result = new List<CreatedByValueObject>();

            foreach (var createdBy in createdBys)
                result.Add(createdBy.Map(tvDetailId));

            return result;
        }




        public static EpisodeValueObject Map(this EpisodeApiModelDto episode, Guid tvDetailId, EpisodeAirType episodeAirType)
        {
            var result = new EpisodeValueObject()
            {
                EpisodeAirType = episodeAirType,
                AirDate = episode.AirDate,
                ApiModelId = episode.Id,
                EpisodeNumber = episode.EpisodeNumber,
                EpisodeType = episode.EpisodeType,
                ParrentId = tvDetailId,
                Name = episode.Name,
                Overview = episode.Overview,
                SeasonNumber = episode.SeasonNumber,
                StillPath = episode.StillPath,
                VoteAverage = episode.VoteAverage,
                VoteCount = episode.VoteCount,
            };
            return result;
        }

        public static List<EpisodeValueObject> Map(this List<EpisodeApiModelDto> episodes, Guid tvDetailId, EpisodeAirType episodeAirType)
        {
            var result = new List<EpisodeValueObject>();

            foreach (var episode in episodes)
                result.Add(episode.Map(tvDetailId, episodeAirType));

            return result;
        }
        
    }
}
