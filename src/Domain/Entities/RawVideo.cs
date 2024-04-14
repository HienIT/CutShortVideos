namespace CleanArchitecture.Domain.Entities;

public class RawVideo : BaseEntity
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

    //private bool _done;
    //public bool Done
    //{
    //    get => _done;
    //    set
    //    {
    //        if (value && !_done)
    //        {
    //            AddDomainEvent(new TodoItemCompletedEvent(this));
    //        }

    //        _done = value;
    //    }
    //}

    public RawVideo List { get; set; } = null!;
}
