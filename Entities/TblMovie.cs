using System;
using System.Collections.Generic;

namespace DeltaX.Entities
{
    public partial class TblMovie
    {
        public TblMovie()
        {
            TblMovieDetails = new HashSet<TblMovieDetail>();
        }

        public int MovieId { get; set; }
        public string MovieName { get; set; } = null!;
        public string? Plot { get; set; }
        public string Poster { get; set; } = null!;
        public DateTime? ReleaseDate { get; set; }
        public int ProducerId { get; set; }

        public virtual TblProducer Producer { get; set; } = null!;
        public virtual ICollection<TblMovieDetail> TblMovieDetails { get; set; }
    }
}
