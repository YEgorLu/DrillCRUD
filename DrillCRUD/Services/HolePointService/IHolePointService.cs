using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.HolePointService
{
    public interface IHolePointService
    {
        Task<HolePointDTO> GetHolePoint(int id);
        Task<HolePointDTO> UpdateHolePoint(JsonPatchDocument<HolePoint> holePoint, int id);
        Task DeleteHolePoint(int id);
        Task CreateHolePoint(HolePointDTO holePointDTO);
    }
}
