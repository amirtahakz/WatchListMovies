using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Company.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Company
{
    public interface ICompanyApiService
    {
        Task<GetCompanyDetailsApiModelDto> GetCompanyDetails(long companyApiId);
    }
}
