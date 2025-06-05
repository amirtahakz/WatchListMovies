using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Configuration;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.CountryAgg.Repository;
using WatchListMovies.Domain.LanguageAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Configuration
{
    public class ConfigurationJobs
    {
        private readonly IConfigurationApiService _configurationApiService;
        private readonly ILanguageRepository _languageRepository; 
        private readonly ICountryRepository _countryRepository;

        public ConfigurationJobs(
            IConfigurationApiService configurationApiService,
            ILanguageRepository languageRepository,
            ICountryRepository countryRepository)
        {
            _configurationApiService = configurationApiService;
            _languageRepository = languageRepository;
            _countryRepository = countryRepository;
        }

        public async Task SyncLanguages()
        {
            try
            {
                var languagesApi = await _configurationApiService.GetLanguagesList();

                if (languagesApi.Any())
                    await _languageRepository.AddRangeIfNotExistAsync(languagesApi.Map());
                    await _languageRepository.Save();


            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCountries()
        {
            try
            {
                var countriesApi = await _configurationApiService.GetCountriesList();

                if (countriesApi.Any())
                    await _countryRepository.AddRangeIfNotExistAsync(countriesApi.Map());
                    await _countryRepository.Save();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
