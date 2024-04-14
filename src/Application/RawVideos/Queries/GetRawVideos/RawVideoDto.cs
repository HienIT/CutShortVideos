using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.TodoItems.Queries.GetRawVideosWithPagination;

public class RawVideoDto
{
    public int Rawvideoid { get; set; }

    public required string Rawvideoname { get; set; }

    public double Durationtime { get; set; }

    public required string Filename { get; set; }

    public required string Directory { get; set; }

    public required string Ext { get; set; }

    public required string Resolution { get; set; }

    public required DateTime Createdate { get; set; }

    public required DateTime Updatedate { get; set; }

    public required string Createuser { get; set; }

    public required string Updateuser { get; set; }

    public bool? Isdelete { get; set; }

    public DateTime? Deletedate { get; set; }

    public string? Deleteuser { get; set; }

    private class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<RawVideo, RawVideoDto>();
        }
    }
}
