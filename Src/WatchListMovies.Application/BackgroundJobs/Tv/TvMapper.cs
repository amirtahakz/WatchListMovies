using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;
using WatchListMovies.Domain.TvAgg;


namespace WatchListMovies.Application.BackgroundJobs.Tv
{
    public static class TvMapper
    {
        public static List<Domain.TvAgg.Tv> Map(this List<PopularTvsItemApiModelDto> tvsApi)
        {
            var result = new List<Domain.TvAgg.Tv>();

            foreach (var item in tvsApi)
                result.Add(item.Map());

            return result;
        }

        public static Domain.TvAgg.Tv Map(this PopularTvsItemApiModelDto tvApi)
        {
            var result = new Domain.TvAgg.Tv()
            {
                Adult = tvApi.Adult,
                ApiModelId = tvApi.Id,
                BackdropPath = tvApi.BackdropPath,
                OriginalLanguage = tvApi.OriginalLanguage,
                Overview = tvApi.Overview,
                Popularity = tvApi.Popularity,
                PosterPath = tvApi.PosterPath,
                VoteAverage = tvApi.VoteAverage,
                VoteCount = tvApi.VoteCount,
                Name = tvApi.Name,
                FirstAirDate = tvApi.FirstAirDate,
                OriginalName = tvApi.OriginalName,
                GenreIds = tvApi.GenreIds,
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

            if (tvDetails.Networks != null)
                result.NetworkIds = tvDetails.Networks.Where(g => g.Id.HasValue).Select(g => g.Id.Value.ToString()).ToList().AsReadOnly();

            if (tvDetails.CreatedBy != null)
                result.CreatedByIds = tvDetails.CreatedBy.Where(g => g.Id.HasValue).Select(g => g.Id.Value.ToString()).ToList().AsReadOnly();


            return result;
        }
        
    }
}
