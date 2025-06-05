using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Cast
{
    public interface ICastApiService
    {
        Task<PopularCastsApiModelDto> GetPopularCasts(int page = 1);

        Task<CastDetailsApiModelDto> GetCastDetails(long? castApiId);

        Task<CastExternalIdsApiModelDto> GetCastExternalIds(long? castApiId);
        Task<ImagesApiModelDto> GetCastImages(long? castApiId);

        Task<GetCreditsOfCastApiModelDto> GetMovieCreditsOfCast(long? castApiId);
        Task<GetCreditsOfCastApiModelDto> GetTvCreditsOfCast(long? castApiId);
    }
}
