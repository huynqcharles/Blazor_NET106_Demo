using Microsoft.EntityFrameworkCore;
using NET106_Demo_API.Data;
using NET106_Demo_API.IServices;
using NET106_Demo_Shared;

namespace NET106_Demo_API.Services
{
    public class PositionService : IPositionService
    {
        private readonly ApplicationDbContext appDbContext;

        public PositionService(ApplicationDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Position> GetPosition(int posiotionId)
        {
            return await appDbContext.Positions
                .FirstOrDefaultAsync(p => p.PositionId == posiotionId);
        }

        public async Task<IEnumerable<Position>> GetPositions()
        {
            return await appDbContext.Positions.ToListAsync();
        }
    }
}
