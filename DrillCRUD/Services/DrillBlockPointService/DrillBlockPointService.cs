using AutoMapper;
using DrillCRUD.Data;
using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.DrillBlockPointService
{
    public class DrillBlockPointService: IDrillBlockPointService
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public DrillBlockPointService(IMapper mapper, DataContext dataContext)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
        }
        public async Task CreateDrillBlockPoint(DrillBlockPointDTO _point)
        {
            var point = mapper
                .Map<DrillBlockPoint>(_point);
            (await dataContext.DrillBlocks
                .Include(b => b.DrillBlockPoints)
                .FirstOrDefaultAsync(b => b.Id == _point.DrillBlockId)
                ?? throw new KeyNotFoundException($"DrillBlock with id {_point.DrillBlockId} does not exist"))
            .DrillBlockPoints
                .Add(point);

            await dataContext.DrillBlockPoints
                .AddAsync(point);
            await dataContext
                .SaveChangesAsync();
        }

        public async Task<DrillBlockPointDTO> UpdateDrillBlockPoint(JsonPatchDocument<DrillBlockPoint> _point, int id)
        {
            var point = await dataContext.DrillBlockPoints
                .FindAsync(id)
                ?? throw new KeyNotFoundException($"DrillBlockPoint with id {id} does not exist");
            _point.ApplyTo(point);
            await dataContext
                .SaveChangesAsync();
            return mapper
                .Map<DrillBlockPointDTO>(point);
        }

        public async Task<DrillBlockPointDTO> GetDrillBlockPoint(int id)
        {
            return mapper
                .Map<DrillBlockPointDTO>(await dataContext.DrillBlockPoints
                .FindAsync(id)
                ?? throw new KeyNotFoundException($"DrillBlockPoint with id {id} does not exist"));
        }

        public async Task DeleteDrillBlockPoint(int id)
        {
            dataContext.DrillBlockPoints
                .Remove(await dataContext.DrillBlockPoints.FindAsync(id)
                ?? throw new KeyNotFoundException($"DrillBlockPoint with id {id} does not exist"));
        }
    }
}
