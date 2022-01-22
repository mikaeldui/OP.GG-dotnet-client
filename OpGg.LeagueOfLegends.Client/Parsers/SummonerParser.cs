using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpGg.LeagueOfLegends
{
    internal static class SummonerParser
    {
        public static async Task<Summoner> ParserAsync(string html) => await Task.Run(() =>
        {
            HtmlDocument doc = new();
            doc.LoadHtml(html);

            long? summonerId = long.Parse(doc.DocumentNode.SelectSingleNode("//*[id='SummonerRrefrshButton']").Attributes["onclick"].Value);


            return new Summoner();
        });
    }
}
