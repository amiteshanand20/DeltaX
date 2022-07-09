using System;
using System.Collections.Generic;

namespace DeltaX.Entities
{
    public partial class TblProducer
    {
        public TblProducer()
        {
            TblMovies = new HashSet<TblMovie>();
        }

        public int ProducerId { get; set; }
        public string ProducerName { get; set; } = null!;
        public string Bio { get; set; } = null!;
        public DateTime? DateOfBirth { get; set; }
        public int? Gender { get; set; }
        public string ProductionHouse { get; set; } = null!;

        public virtual ICollection<TblMovie> TblMovies { get; set; }
    }
}
