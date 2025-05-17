using AutoMapper;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.UserTokens.GetByRefreshToken;

internal class GetUserTokenByRefreshTokenQueryHandler : IQueryHandler<GetUserTokenByRefreshTokenQuery, UserTokenDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserTokenByRefreshTokenQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    public async Task<UserTokenDto> Handle(GetUserTokenByRefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var token = _context.UserTokens.FirstOrDefault(x => x.HashRefreshToken == request.HashRefreshToken);
        return _mapper.Map<UserTokenDto>(token);
    }
}