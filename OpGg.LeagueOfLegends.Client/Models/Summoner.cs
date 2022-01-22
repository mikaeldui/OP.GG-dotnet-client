using System;
using System.Collections.Generic;
using System.Text;

namespace OpGg.LeagueOfLegends
{
    public class Summoner : ISummonerId
    {
        public string Name { get; }
        public long? Id { get; }
        long? ISummonerId.SummonerId { get => Id; }
    }
}
