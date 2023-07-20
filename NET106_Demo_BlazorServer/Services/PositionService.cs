using NET106_Demo_BlazorServer.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.Services
{
    public class PositionService : IPositionService
    {
        private readonly HttpClient httpClient;

        public PositionService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Position> GetPosition(int id)
        {
            return await httpClient.GetFromJsonAsync<Position>($"api/Positions/{id}");
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Position>>("api/Positions");
        }
    }
}
