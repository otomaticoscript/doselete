using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Doselete.Domain.Entity
{
    public class Country
    {
        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("code")]
        public string Code;

        [JsonPropertyName("timezone")]
        public string Timezone;
    }

    public class Externals
    {
        [JsonPropertyName("tvrage")]
        public int Tvrage;

        [JsonPropertyName("thetvdb")]
        public int Thetvdb;

        [JsonPropertyName("imdb")]
        public string Imdb;
    }

    public class Image
    {
        [JsonPropertyName("medium")]
        public string Medium;

        [JsonPropertyName("original")]
        public string Original;
    }

    public class Links
    {
        [JsonPropertyName("self")]
        public Self Self { get; set; }

        [JsonPropertyName("previousepisode")]
        public Previousepisode Previousepisode { get; set; }

        [JsonPropertyName("nextepisode")]
        public Nextepisode Nextepisode { get; set; }
    }

    public class Network
    {
        [JsonPropertyName("id")]
        public int Id;

        [JsonPropertyName("name")]
        public string Name;

        [JsonPropertyName("country")]
        public Country Country;

        [JsonPropertyName("officialSite")]
        public string OfficialSite;
    }

    public class Self
    {
        [JsonPropertyName("href")]
        public string Href;
    }
    public class Previousepisode : Self
    {

        [JsonPropertyName("name")]
        public string Name;
    }
    public class Nextepisode : Self
    {
        [JsonPropertyName("name")]
        public string Name;
    }

    public class Rating
    {
        [JsonPropertyName("average")]
        public double Average;
    }

    public class Schedule
    {
        [JsonPropertyName("time")]
        public string Time;

        [JsonPropertyName("days")]
        public List<string> Days;
    }

}
