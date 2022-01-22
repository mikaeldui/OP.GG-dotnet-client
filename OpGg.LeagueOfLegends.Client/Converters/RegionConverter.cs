using Camille.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpGg.LeagueOfLegends
{
    internal static class RegionConverter
    {
        private static readonly IReadOnlyDictionary<string, string> _regionMap = new Dictionary<string, string>
        {
            { "LA1", "LAN" },
            { "LA1", "LAS" },
            { "OC1", "OCE" }
        };

        public static string ConvertToOpGgRegion(string region) =>
            region.ToUpper().Replace(_regionMap).TrimEnd("0123456789".ToArray());

        public static string ToOpGgRegion(this PlatformRoute platform) =>
            ConvertToOpGgRegion(platform.ToString());
    }
}
