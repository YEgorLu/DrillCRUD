using DrillCRUD.Models;
using DrillCRUD.Services.HolePointService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrillCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HolePointController: ControllerBase
    {
        private readonly IHolePointService holePointService;

        public HolePointController(IHolePointService holePointService)
        {
            this.holePointService = holePointService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HolePointDTO>> GetHolePoint(int id)
        {
            HolePointDTO point;
            try
            {
                point = await holePointService.GetHolePoint(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(point);
        }

        [HttpPost]
        public async Task<IActionResult> CreateHolePoint(HolePointDTO holePointDTO)
        {
            try
            {
                await holePointService.CreateHolePoint(holePointDTO);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<HolePointDTO>> GetHolePoint(JsonPatchDocument<HolePoint> holePointDTO, int id)
        {
            HolePointDTO point;
            try
            {
                point = await holePointService.UpdateHolePoint(holePointDTO, id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(point);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHolePoint(int id)
        {
            try
            {
                await holePointService.DeleteHolePoint(id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }
    }
}
