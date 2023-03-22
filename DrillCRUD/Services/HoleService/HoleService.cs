using DrillCRUD.Data;
using AutoMapper;
using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.HoleService
{
    public class HoleService : IHoleService
    {
        private readonly DataContext dataContext;
        private readonly IMapper mapper;

        public HoleService(DataContext dataContext, IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<HoleDTO> GetHole(int holeId)
        {
            var hole = await dataContext.Holes.FindAsync(holeId)
                ?? throw new KeyNotFoundException($"Hole with id {holeId} does not exist");
            return mapper.Map<HoleDTO>(hole);
        }

        public async Task CreateHole(HoleDTO hole)
        {
            var _hole = mapper.Map<Hole>(hole);
            var block = await dataContext.DrillBlocks.Include(b => b.Holes).FirstOrDefaultAsync(b => b.Id == _hole.DrillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {_hole.DrillBlockId} does not exist");
            block.Holes.Add(_hole);
            await dataContext.Holes.AddAsync(_hole);
            await dataContext.SaveChangesAsync();
        }

        public async Task<HoleDTO> UpdateHole(HoleDTO hole)
        {
            var _hole = await dataContext.Holes
                .FindAsync(hole.Id)
                ?? throw new KeyNotFoundException($"Hole with id {hole.Id} does not exist");
            var newHole = mapper.Map(hole, _hole);
            await dataContext
                .SaveChangesAsync();
            return mapper
                .Map<HoleDTO>(newHole);
        }

        public async Task DeleteHole(int holeId)
        {
            var hole = await dataContext.Holes.FindAsync(holeId)
                ?? throw new KeyNotFoundException($"Hole with id {holeId} does not exist");
            dataContext.Holes.Remove(hole);
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<HoleDTO>> GetAllHoles()
        {
            return mapper.Map<List<HoleDTO>>(await dataContext.Holes.ToListAsync());
        }

        public async Task<HoleDTO> PatchHole(JsonPatchDocument<Hole> hole, int id)
        {
            var _hole = await dataContext.Holes.FindAsync(id)
                ?? throw new KeyNotFoundException($"Hole with id {id} does not exist");
            hole.ApplyTo(_hole);
            await dataContext.SaveChangesAsync();
            return mapper.Map<HoleDTO>(_hole);
        }
    }
}
