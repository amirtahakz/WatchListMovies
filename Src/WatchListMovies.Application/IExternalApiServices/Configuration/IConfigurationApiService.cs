using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Configuration
{
    public interface IConfigurationApiService
    {
        Task<List<LanguagesApiModelDto>> GetLanguagesList();
        Task<List<CountriesApiModelDto>> GetCountriesList();
    }
}
