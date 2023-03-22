using AutoMapper;
using DrillCRUD.Data;
using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Adapters;
using Microsoft.AspNetCore.JsonPatch.Operations;
using System.Reflection.Metadata;

namespace DrillCRUD.Services.DrillBlockService
{
    public class DrillBlockService : IDrillBlockService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public DrillBlockService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }
        public async Task CreateDrillBlock(DrillBlockDTO drillBlock)
        {
            await dataContext.DrillBlocks
                .AddAsync(mapper
                .Map<DrillBlock>(drillBlock));
            await dataContext
                .SaveChangesAsync();
        }

        public async Task DeleteDrillBlock(int drillBlockId)
        {
            dataContext.DrillBlocks
                .Remove(await dataContext.DrillBlocks
                .FindAsync(drillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {drillBlockId} does not exist"));
            await dataContext
                .SaveChangesAsync();
        }

        public async Task<List<DrillBlockDTO>> GetAllDrillBlocks()
        {
            return mapper
                .Map<List<DrillBlockDTO>>(await dataContext.DrillBlocks
                                        .ToListAsync());
        }

        public async Task<DrillBlockDTO> GetDrillBlock(int drillBlockId)
        {
            return mapper
                .Map<DrillBlockDTO>(await dataContext.DrillBlocks
                                    .FindAsync(drillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {drillBlockId} does not exist"));
        }

        public async Task<DrillBlockDTO> PatchDrillBlock(JsonPatchDocument<DrillBlock> drillBlock, int id)
        {
            var block = await dataContext.DrillBlocks
                .FindAsync(id)
                ?? throw new KeyNotFoundException($"DrillBlock with id {id} does not exist");
            drillBlock.ApplyTo(block);
            await dataContext
                .SaveChangesAsync();
            return mapper
                .Map<DrillBlockDTO>(block);
        }

        public async Task<DrillBlockDTO> UpdateDrillBlock(DrillBlockDTO drillBlock)
        {
            var block = await dataContext.DrillBlocks
                .FindAsync(drillBlock.Id)
                ?? throw new KeyNotFoundException($"DrillBlock with id {drillBlock.Id} does not exist");
            var newBlock = mapper
                .Map(drillBlock, block);
            await dataContext
                .SaveChangesAsync();
            return mapper
                .Map<DrillBlockDTO>(newBlock);
        }

        public async Task AddHole(int drillBlockId, HoleDTO _hole)
        {
            var block = await dataContext.DrillBlocks
                .Include(b => b.Holes)
                .FirstOrDefaultAsync(b => b.Id == drillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {drillBlockId} does not exist");
            var hole = await dataContext.Holes
                .FindAsync(_hole.Id)
                ?? throw new KeyNotFoundException($"Hole with id {_hole.Id} does not exist");
            block.Holes
                .Add(hole);
            hole.DrillBlock = block;
            hole.DrillBlockId = drillBlockId;
            await dataContext
                .SaveChangesAsync();
        }

        public async Task<DrillBlockFullDTO> GetFullInfo(int drillBlockId)
        {
            return mapper
                .Map<DrillBlockFullDTO>(await dataContext
                .DrillBlocks
                .Include(block => block.DrillBlockPoints)
                .Include(block => block.Holes)
                .FirstOrDefaultAsync(block => block.Id == drillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {drillBlockId} does not exist")
                );
        }
    }
}
