using System;
using System.Collections.Generic;

namespace DeltaX.Entities
{
    public partial class TblMovieDetail
    {
        public int MovieDetailsId { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }

        public virtual TblActor Actor { get; set; } = null!;
        public virtual TblMovie Movie { get; set; } = null!;
    }
}
