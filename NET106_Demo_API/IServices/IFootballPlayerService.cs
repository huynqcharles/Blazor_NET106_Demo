using NET106_Demo_Shared;

namespace NET106_Demo_API.IServices
{
    public interface IFootballPlayerService
    {
        Task<IEnumerable<FootballPlayer>> GetFootballPlayers();
        Task<FootballPlayer> GetFootballPlayer(int footballPlayerId);
        Task<FootballPlayer> AddFootballPlayer(FootballPlayer footballPlayer);
        Task<FootballPlayer> UpdateFootballPlayer(FootballPlayer footballPlayer);
        Task<FootballPlayer> DeleteFootballPlayer(int footballPlayerId);
    }
}
