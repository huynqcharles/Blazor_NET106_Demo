using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.IServices
{
    public interface IFootballPlayerService
    {
        Task<IEnumerable<FootballPlayer>> GetFootballPlayers();
        Task<FootballPlayer> GetFootballPlayer(int id);
        Task<FootballPlayer> UpdateFootballPlayer(FootballPlayer updateFootballPlayer);
    }
}
