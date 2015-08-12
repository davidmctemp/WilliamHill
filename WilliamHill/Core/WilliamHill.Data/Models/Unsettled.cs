using System;
using System.Collections.Generic;

namespace WilliamHill.Data.Models
{
    public partial class Unsettled
    {
        public int ID { get; set; }
        public int Customer { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }
    }
}
