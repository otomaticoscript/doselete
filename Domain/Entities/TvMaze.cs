using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Doselete.Domain.Entity
{
    public class TvMaze : TvMazeforProductTable
    {

        [JsonPropertyName("url")]
        public string Url;

        [JsonPropertyName("averageRuntime")]
        public int AverageRuntime;

        [JsonPropertyName("premiered")]
        public string Premiered;

        [JsonPropertyName("ended")]
        public string Ended;

        [JsonPropertyName("officialSite")]
        public string OfficialSite;

        [JsonPropertyName("weight")]
        public int Weight;

        [JsonPropertyName("webChannel")]
        public object WebChannel = null;

        [JsonPropertyName("dvdCountry")]
        public object DvdCountry = null;

        [JsonPropertyName("summary")]
        public string Summary;

        [JsonPropertyName("updated")]
        public int Updated;

        public static TvMaze Cast(TvMazeFetched productoBase)
        {
            return new TvMaze()
            {

                Id = productoBase.Id,
                Name = productoBase.Name,
                Type = productoBase.Type,
                Language = productoBase.Language,
                Genres = productoBase.Genres,
                Status = productoBase.Status,
                Runtime = productoBase.Runtime,
                Url = productoBase.Url,
                AverageRuntime = productoBase.AverageRuntime,
                Premiered = productoBase.Premiered,
                Ended = productoBase.Ended,
                OfficialSite = productoBase.OfficialSite,
                Weight = productoBase.Weight,
                WebChannel = productoBase.WebChannel,
                DvdCountry = productoBase.DvdCountry,
                Summary = productoBase.Summary,
                Updated = productoBase.Updated
            };
        }
    }
}
