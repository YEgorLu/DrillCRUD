using DrillCRUD.Models;
using DrillCRUD.Services.DrillBlockPointService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrillCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockPointController: ControllerBase
    {
        private readonly IDrillBlockPointService drillBlockPointService;

        public DrillBlockPointController(IDrillBlockPointService drillBlockPointService)
        {
            this.drillBlockPointService = drillBlockPointService;
        }

        [HttpGet("{drillBlockPointId}")]
        public async Task<ActionResult<DrillBlockPointDTO>> GetPoint(int drillBlockPointId)
        {
            DrillBlockPointDTO point;
            try
            {
                point = await drillBlockPointService.GetDrillBlockPoint(drillBlockPointId);
            }
            catch (KeyNotFoundException e) {
                return NotFound(e.Message);
            }

            return Ok(point);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePoint(DrillBlockPointDTO pointDTO)
        {
            try
            {
                await drillBlockPointService.CreateDrillBlockPoint(pointDTO);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DrillBlockPointDTO>> UpdatePoint(JsonPatchDocument<DrillBlockPoint> pointDTO, int id)
        {
            DrillBlockPointDTO point;
            try
            {
                point = await drillBlockPointService.UpdateDrillBlockPoint(pointDTO, id);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(point);
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePoint(int drillBlockPointId)
        {
            try
            {
                await drillBlockPointService.DeleteDrillBlockPoint(drillBlockPointId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok();
        }
    }
}
