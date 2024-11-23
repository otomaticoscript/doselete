using Doselete.Domain.Entity;
using Newtonsoft.Json;

namespace Doselete.Domain.Repository.Service
{
    public interface ITvMazeService {
        public Task<TvMazeFetched> FetchTvMazeAsync(int Id);
    }
    public class TvMazeService : ITvMazeService
    {
        private readonly HttpClient _httpClient;

        public TvMazeService( HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TvMazeFetched> FetchTvMazeAsync(int id)
        {
            var response = await _httpClient.GetAsync($"https://api.tvmaze.com/shows/{id}");
            response.EnsureSuccessStatusCode();

            String content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TvMazeFetched>(content)!; 


        }
    }

}
