using AutoMapper;
using Dapper;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.UserTokens.GetByJwtToken;

internal class GetUserTokenByJwtTokenQueryHandler : IQueryHandler<GetUserTokenByJwtTokenQuery, UserTokenDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetUserTokenByJwtTokenQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserTokenDto> Handle(GetUserTokenByJwtTokenQuery request, CancellationToken cancellationToken)
    {
        var token = _context.UserTokens.FirstOrDefault(x => x.HashJwtToken == request.HashJwtToken);
        return _mapper.Map<UserTokenDto>(token);
    }
}