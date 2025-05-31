using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Domain._Shared.ValueObjects;

namespace WatchListMovies.Application.IExternalApiServices._Shared
{
    public static class SharedMapper
    {
        public static SpokenLanguageValueObject Map(this SpokenLanguageApiModelDto spokenLanguageApiModelDto, Guid tvDetailId)
        {
            var result = new SpokenLanguageValueObject()
            {
                Name = spokenLanguageApiModelDto.Name,
                EnglishName = spokenLanguageApiModelDto.EnglishName,
                Iso6391 = spokenLanguageApiModelDto.Iso6391,
                MediaId = tvDetailId

            };
            return result;
        }

        public static List<SpokenLanguageValueObject> Map(this List<SpokenLanguageApiModelDto> spokenLanguageApiModelDtos, Guid tvDetailId)
        {
            var result = new List<SpokenLanguageValueObject>();

            foreach (var spokenLanguageApiModelDto in spokenLanguageApiModelDtos)
                result.Add(spokenLanguageApiModelDto.Map(tvDetailId));

            return result;
        }

        public static ProductionCompanyValueObject Map(this ProductionCompanyApiModelDto productionCompanyApi, Guid tvDetailId)
        {
            var result = new ProductionCompanyValueObject()
            {
                Name = productionCompanyApi.Name,
                LogoPath = productionCompanyApi.LogoPath,
                OriginCountry = productionCompanyApi.OriginCountry,
                ApiModelId = productionCompanyApi.ApiModelId,
                MediaId = tvDetailId

            };
            return result;
        }

        public static List<ProductionCompanyValueObject> Map(this List<ProductionCompanyApiModelDto> productionCompanyApis, Guid tvDetailId)
        {
            var result = new List<ProductionCompanyValueObject>();

            foreach (var productionCompanyApi in productionCompanyApis)
                result.Add(productionCompanyApi.Map(tvDetailId));

            return result;
        }

        public static ProductionCountryValueObject Map(this ProductionCountryApiModelDto seasonApi, Guid tvDetailId)
        {
            var result = new ProductionCountryValueObject()
            {
                Name = seasonApi.Name,
                Iso31661 = seasonApi.Iso31661,
                MediaId = tvDetailId

            };
            return result;
        }

        public static List<ProductionCountryValueObject> Map(this List<ProductionCountryApiModelDto> productionCountryApis, Guid tvDetailId)
        {
            var result = new List<ProductionCountryValueObject>();

            foreach (var productionCountryApi in productionCountryApis)
                result.Add(productionCountryApi.Map(tvDetailId));

            return result;
        }

        public static GenreValueObject Map(this GenreApiModelDto genre, Guid tvDetailId)
        {
            var result = new GenreValueObject()
            {
                ApiModelId = genre.ApiModelId,
                MediaId = tvDetailId,
                Name = genre.Name,
            };
            return result;
        }

        public static List<GenreValueObject> Map(this List<GenreApiModelDto> genres, Guid tvDetailId)
        {
            var result = new List<GenreValueObject>();

            foreach (var genre in genres)
                result.Add(genre.Map(tvDetailId));

            return result;
        }

    }
}
