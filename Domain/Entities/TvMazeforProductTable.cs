using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Doselete.Domain.Entity
{
    public class TvMazeforProductTable
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("languege")]
        public string Language { get; set; }
        [JsonPropertyName("genres")]
        public List<string> Genres { get; set; }
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("runtime")]
        public int Runtime { get; set; }
    }
    public class TvMazeProduct : TvMazeforProductTable
    {
        public int? IdRoot { get; set; } = null;
        public string Country { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;

        public static TvMazeProduct Cast(TvMazeforProductTable element)
        {
            return new TvMazeProduct()
            {
                Id = element.Id,
                Name = element.Name,
                Type = element.Type,
                Language = element.Language,
                Genre = String.Join(",", element.Genres),
                Status = element.Status,
                Runtime = element.Runtime,
            };
        }
    }
}
