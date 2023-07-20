using NET106_Demo_Shared;

namespace NET106_Demo_API.IServices
{
    public interface IPositionService
    {
        Task<IEnumerable<Position>> GetPositions();
        Task<Position> GetPosition(int posiotionId);
    }
}
