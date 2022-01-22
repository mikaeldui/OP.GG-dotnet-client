using Camille.Enums;
using System;
using System.Net;
using System.Reflection;

namespace OpGg.LeagueOfLegends
{
    public class OpGgLeagueOfLegendsClient : OpGgClientBase
    {
        #region User-Agent

        private static readonly string USER_AGENT;

        static OpGgClient()
        {
            var opGgUa = UserAgent.From(typeof(OpGgClient).Assembly);
            opGgUa.DependentProduct = UserAgent.From(Assembly.GetEntryAssembly());
            USER_AGENT = opGgUa.ToString();
        }

        #endregion User-Agent

        #region Construction

        public OpGgLeagueOfLegendsClient(string region) : base(region)
        {
        }

        public OpGgLeagueOfLegendsClient(PlatformRoute region) : base(region.ToOpGgRegion())
        {
        }

        #endregion Construction

        public async Task<Summoner> GetSummonerAsync(string summonerName)
        {
            var response = await HttpClient.GetStringAsync($"/summoner/?userName={summonerName}");
            return await SummonerParser.ParseAsync(response);
        }

        public void Dispose() => HttpClient.Dispose();
    }
}