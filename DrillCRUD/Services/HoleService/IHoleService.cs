using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.HoleService
{
    public interface IHoleService
    {
        Task<List<HoleDTO>> GetAllHoles();
        Task<HoleDTO> GetHole(int holeId);
        Task CreateHole(HoleDTO hole);
        Task<HoleDTO> UpdateHole (HoleDTO hole);
        Task DeleteHole(int holeId);
        Task <HoleDTO> PatchHole(JsonPatchDocument<Hole> hole, int id);
    }
}
