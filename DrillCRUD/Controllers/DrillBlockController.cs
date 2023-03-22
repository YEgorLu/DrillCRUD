using DrillCRUD.Models;
using DrillCRUD.Services.DrillBlockService;
using DrillCRUD.Services.HoleService;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace DrillCRUD.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DrillBlockController : ControllerBase
    {
        private readonly IDrillBlockService drillBlockService;

        public DrillBlockController(IDrillBlockService drillBlockService)
        {
            this.drillBlockService = drillBlockService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DrillBlock>> GetAllBlocks()
        {
            return Ok(drillBlockService.GetAllDrillBlocks());
        }

        [HttpGet("{drillBlockId}")]
        public async Task<IActionResult> GetBlock(int drillBlockId)
        {
            DrillBlockDTO drillBlock;
            try
            {
                drillBlock = await drillBlockService.GetDrillBlock(drillBlockId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(drillBlock);
        }

        [HttpGet("{drillBlockId}/full")]
        public async Task<ActionResult<DrillBlockFullDTO>> GetBlockFull(int drillBlockId)
        {
            DrillBlockFullDTO drillBlock;
            try
            {
                drillBlock = await drillBlockService.GetFullInfo(drillBlockId);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }

            return Ok(drillBlock);
        }

        [HttpPost]
        public IActionResult CreateBlock(DrillBlockDTO drillBlock)
        {
            try
            {
                drillBlockService.CreateDrillBlock(drillBlock);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBlock(int drillBlockId)
        {
            try
            {
                await drillBlockService.DeleteDrillBlock(drillBlockId);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult<DrillBlockDTO>> UpdateBlock(DrillBlockDTO drillBlock)
        {
            DrillBlockDTO block;
            try
            {
                block = await drillBlockService.UpdateDrillBlock(drillBlock);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(block);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DrillBlockDTO>> PatchBlock(JsonPatchDocument<DrillBlock> drillBlock, int id)
        {
            DrillBlockDTO block;
            try
            {
                block = await drillBlockService.PatchDrillBlock(drillBlock, id);
            }
            catch (KeyNotFoundException e)
            {
                return BadRequest(e.Message);
            }
            return Ok(block);
        }
    }
}