using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.TodoItems.Commands.UpdateTodoItemDetail;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.RawVideos.Commands.CreateRawVideo;
public record CreateRawVideoCommand : IRequest
{
    public required string Directory { get; init; }
    public string CreateUser { get; init; } = "admin";
    public string UpdateUser { get; init; } = "admin";
}

public class CreateRawVideoCommandHandler : IRequestHandler<CreateRawVideoCommand>
{
    private readonly IApplicationDbContext _context;

    public CreateRawVideoCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(CreateRawVideoCommand request, CancellationToken cancellationToken)
    {
        var rawVideos = _context.RawVideos.Where(m => m.Isdelete != true).ToList();
        var listFileByDirectory = Directory.GetFiles(request.Directory);

        foreach (var file in listFileByDirectory)
        {
            FileInfo fi = new FileInfo(file);

            if (rawVideos.Exists(m => m.Filename == fi.Name && m.Directory == request.Directory))
            {
                continue;
            }

            var videoInfo = VideoHelper.GetVideoInfo(fi.FullName);

            RawVideo newItem = new RawVideo()
            {
                Directory = request.Directory,
                Filename = fi.Name,
                Rawvideoname = fi.Name,
                Ext = fi.Extension,
                Durationtime = videoInfo.Item1.TotalMinutes,
                Resolution = videoInfo.Item2,
                Createdate = DateTime.Now,
                Updatedate = DateTime.Now,
                Createuser = request.CreateUser,
                Updateuser = request.UpdateUser
            };

            _context.RawVideos.Add(newItem);
        }

        await _context.SaveChangesAsync(cancellationToken);
    }
}
