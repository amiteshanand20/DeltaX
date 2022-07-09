using System;
using System.Collections.Generic;

namespace DeltaX.Entities
{
    public partial class TblActor
    {
        public TblActor()
        {
            TblMovieDetails = new HashSet<TblMovieDetail>();
        }

        public int ActorId { get; set; }
        public string ActorName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }

        public virtual ICollection<TblMovieDetail> TblMovieDetails { get; set; }
    }
}
