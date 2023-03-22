using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.DrillBlockPointService
{
    public interface IDrillBlockPointService
    {
        Task CreateDrillBlockPoint(DrillBlockPointDTO _point);
        Task DeleteDrillBlockPoint(int id);
        Task<DrillBlockPointDTO> UpdateDrillBlockPoint(JsonPatchDocument<DrillBlockPoint> _point, int id);
        Task<DrillBlockPointDTO> GetDrillBlockPoint(int id);
    }
}
