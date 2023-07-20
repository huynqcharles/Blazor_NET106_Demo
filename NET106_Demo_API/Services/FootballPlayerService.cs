using Microsoft.EntityFrameworkCore;
using NET106_Demo_API.Data;
using NET106_Demo_API.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_API.Services
{
    public class FootballPlayerService : IFootballPlayerService
    {
        private readonly ApplicationDbContext appDbContext;

        public FootballPlayerService(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<FootballPlayer> AddFootballPlayer(FootballPlayer footballPlayer)
        {
            var result = await appDbContext.FootballPlayers.AddAsync(footballPlayer);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<FootballPlayer> DeleteFootballPlayer(int footballPlayerId)
        {
            var result = await appDbContext.FootballPlayers
                .FirstOrDefaultAsync(f => f.FootballPlayerId == footballPlayerId);
            if (result != null)
            {
                appDbContext.FootballPlayers.Remove(result);
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async Task<FootballPlayer> GetFootballPlayer(int footballPlayerId)
        {
            return await appDbContext.FootballPlayers.
                FirstOrDefaultAsync(f => f.FootballPlayerId == footballPlayerId);
        }

        public async Task<IEnumerable<FootballPlayer>> GetFootballPlayers()
        {
            return await appDbContext.FootballPlayers.ToListAsync();
        }

        public async Task<FootballPlayer> UpdateFootballPlayer(FootballPlayer footballPlayer)
        {
            var result = await appDbContext.FootballPlayers
                .FirstOrDefaultAsync(f => f.FootballPlayerId == footballPlayer.FootballPlayerId);

            if (result != null)
            {
                result.FullName = footballPlayer.FullName;
                result.Nationality = footballPlayer.Nationality;
                result.DateOfBirth = footballPlayer.DateOfBirth;
                result.PositionId = footballPlayer.PositionId;
                result.Photo = footballPlayer.Photo;

                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }
    }
}
