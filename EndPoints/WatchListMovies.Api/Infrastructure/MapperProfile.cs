using AutoMapper;
using AutoMapper.Execution;
using WatchListMovies.Api.ViewModels.Cast;
using WatchListMovies.Api.ViewModels.Favorite;
using WatchListMovies.Api.ViewModels.Genre;
using WatchListMovies.Api.ViewModels.List;
using WatchListMovies.Api.ViewModels.Movie;
using WatchListMovies.Api.ViewModels.Tv;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.Services.Cast.Create;
using WatchListMovies.Application.Services.Favorite.Create;
using WatchListMovies.Application.Services.Genre.Create;
using WatchListMovies.Application.Services.List.Create;
using WatchListMovies.Application.Services.Movie.Create;
using WatchListMovies.Application.Services.Tv.Create;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Api.Infrastructure;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<UserTokenDto, UserToken>().ReverseMap();
        CreateMap<CreateFavoriteViewModel, CreateFavoriteCommand>().ReverseMap();
        CreateMap<CreateListViewModel, CreateListCommand>().ReverseMap();
        CreateMap<CreateMovieViewModel, CreateMovieCommand>().ReverseMap();
        CreateMap<CreateTvViewModel, CreateTvCommand>().ReverseMap();
        CreateMap<CreateCastViewModel, CreateCastCommand>().ReverseMap();
        CreateMap<CreateGenreViewModel, CreateGenreCommand>().ReverseMap();
        CreateMap<Tv,TvDto>().ReverseMap();
        CreateMap<Movie,MovieDto>().ReverseMap();


        //CreateMap<Movie, PopularMoviesItemApiModelDto>().ReverseMap();
        //CreateMap<MovieDetail, MovieDetailsApiModelDto>()
        //    .ForMember(dest => dest.ApiModelId, opt => opt.MapFrom(src => src.ApiModelId))
        //    .ForMember(dest => dest.BelongsToCollectionValueObject, opt => opt.MapFrom(src => src.BelongsToCollectionValueObject))
        //    .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres))
        //    .ForMember(dest => dest.ProductionCompanies, opt => opt.MapFrom(src => src.ProductionCompanies))
        //    .ForMember(dest => dest.ProductionCountries, opt => opt.MapFrom(src => src.ProductionCountries))
        //    .ForMember(dest => dest.SpokenLanguages, opt => opt.MapFrom(src => src.SpokenLanguages))
        //    .ReverseMap();
        //CreateMap<GenreValueObject, Domain._Shared.ValueObjects.GenreValueObject>().ReverseMap();
        //CreateMap<BelongsToCollectionValueObject, Domain.MovieAgg.ValueObjects.BelongsToCollectionValueObject>().ReverseMap();
        //CreateMap<ProductionCompanyValueObject, Domain._Shared.ValueObjects.ProductionCompanyValueObject>().ReverseMap();
        //CreateMap<ProductionCountryValueObject, Domain._Shared.ValueObjects.ProductionCountryValueObject>().ReverseMap();
        //CreateMap<SpokenLanguageValueObject, Domain._Shared.ValueObjects.SpokenLanguageValueObject>().ReverseMap();

        
    }
}