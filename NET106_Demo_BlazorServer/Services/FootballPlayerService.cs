using NET106_Demo_BlazorServer.IServices;
using NET106_Demo_Shared;
using System.Collections.Generic;

namespace NET106_Demo_BlazorServer.Services
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly HttpClient httpClient;

        public FootballPlayerService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<FootballPlayer> GetFootballPlayer(int id)
        {
            return await httpClient.GetFromJsonAsync<FootballPlayer>($"api/FootballPlayers/{id}");
        }

        public async Task<IEnumerable<FootballPlayer>> GetFootballPlayers()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<FootballPlayer>>("api/FootballPlayers");
        }

        public async Task<FootballPlayer> UpdateFootballPlayer(FootballPlayer updateFootballPlayer)
        {
            var response = await httpClient.PutAsJsonAsync("api/FootballPlayers", updateFootballPlayer);
            return await response.Content.ReadFromJsonAsync<FootballPlayer>();
        }
    }
}
