using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.FileParser
{
    public class BetItem
    {
        public BetItem(int customer,int _event, int participant, int stake, int win)
        {
            Customer = customer;
            Event = _event;
            Participant = participant;
            Stake = stake;
            Win = win;
        }

        public int Customer { get; set; }
        public int Event { get; set; }
        public int Participant { get; set; }
        public int Stake { get; set; }
        public int Win { get; set; }
    }
}
