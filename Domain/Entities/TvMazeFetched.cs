using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Doselete.Domain.Entity
{
    public class TvMazeFetched : TvMaze
    {
        [JsonPropertyName("schedule")]
        public Schedule Schedule;

        [JsonPropertyName("rating")]
        public Rating Rating;

        [JsonPropertyName("network")]
        public Network Network;

        [JsonPropertyName("externals")]
        public Externals Externals;

        [JsonPropertyName("image")]
        public Image Image;

        [JsonPropertyName("_links")]
        public Links _Links;
    }
}
