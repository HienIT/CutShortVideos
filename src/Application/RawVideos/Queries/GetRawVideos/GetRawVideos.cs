using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Security;

namespace CleanArchitecture.Application.TodoItems.Queries.GetRawVideosWithPagination;

[Authorize]
public record GetRawVideosQuery : IRequest<IList<RawVideoDto>>;

public class GetRawVideosQueryHandler : IRequestHandler<GetRawVideosQuery, IList<RawVideoDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRawVideosQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IList<RawVideoDto>> Handle(GetRawVideosQuery request, CancellationToken cancellationToken)
    {
        return await _context.RawVideos
                .AsNoTracking()
                .ProjectTo<RawVideoDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(t => t.Updatedate)
                .ToListAsync(cancellationToken);
    }
}
