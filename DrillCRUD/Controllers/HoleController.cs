using DrillCRUD.Models;
using DrillCRUD.Services.HoleService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrillCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HoleController : ControllerBase
    {
        private IHoleService holeService;

        public HoleController(IHoleService holeService)
        {
            this.holeService = holeService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Hole>> GetAllHoles()
        {
            return Ok(holeService.GetAllHoles());
        }

        [HttpGet("{holeId}")]
        public async Task<IActionResult> GetHole(int holeId)
        {
            HoleDTO hole;
            try
            {
                hole = await holeService.GetHole(holeId);
            }
            catch (KeyNotFoundException e) 
            {
                return NotFound(e.Message);
            }

            return Ok(hole);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHole(HoleDTO hole)
        {
            try
            {
                await holeService.CreateHole(hole);
            }
            catch(KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHole(int holeId)
        {
            try
            {
                await holeService.DeleteHole(holeId);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHole(HoleDTO holeDTO)
        {
            try
            {
                await holeService.UpdateHole(holeDTO);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchHole(JsonPatchDocument<Hole> holeDTO, int id)
        {
            try
            {
                await holeService.PatchHole(holeDTO, id);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }
    }
}