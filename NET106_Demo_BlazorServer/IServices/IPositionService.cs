using NET106_Demo_Shared;

namespace NET106_Demo_BlazorServer.IServices
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(int id);
    }
}
