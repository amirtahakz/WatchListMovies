using MediatR;

namespace WatchListMovies.Common.Query;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : class?
{

}