using System;
using System.Collections.Generic;

namespace DeltaX.Entities
{
    public partial class TblMaster
    {
        public int MasterId { get; set; }
        public string MasterName { get; set; } = null!;
        public string MasterType { get; set; } = null!;
    }
}
