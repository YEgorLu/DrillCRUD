using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.DrillBlockService
{
    public interface IDrillBlockService
    {
        Task<List<DrillBlockDTO>> GetAllDrillBlocks();
        Task<DrillBlockDTO> GetDrillBlock(int drillBlockId);
        Task CreateDrillBlock(DrillBlockDTO drillBlock);
        Task<DrillBlockDTO> UpdateDrillBlock(DrillBlockDTO drillBlock);
        Task DeleteDrillBlock(int drillBlockId);
        Task<DrillBlockDTO> PatchDrillBlock(JsonPatchDocument<DrillBlock> drillBlock, int id);
        Task AddHole(int drillBlockId, HoleDTO hole);
        Task<DrillBlockFullDTO> GetFullInfo(int drillBlockId);
    }
}
