using AutoMapper;
using DrillCRUD.Data;
using DrillCRUD.Models;
using Microsoft.AspNetCore.JsonPatch;

namespace DrillCRUD.Services.HolePointService
{
    public class HolePointService: IHolePointService
    {
        private readonly IMapper mapper;
        private readonly DataContext dataContext;

        public HolePointService(IMapper mapper, DataContext dataContext)
        {
            this.mapper = mapper;
            this.dataContext = dataContext;
        }

        public async Task CreateHolePoint(HolePointDTO holePointDTO)
        {
            var point = mapper
                .Map<HolePoint>(holePointDTO);
            (await dataContext.Holes
                .FindAsync(holePointDTO.HoleId)
                ?? throw new KeyNotFoundException($"Hole with id {holePointDTO.HoleId} does not exist"))
                .HolePoint = point;
            await dataContext.HolePoints
                .AddAsync(point);
            await dataContext
                .SaveChangesAsync();
        }

        public async Task<HolePointDTO> GetHolePoint(int id)
        {
            return mapper
                .Map<HolePointDTO>(await dataContext.HolePoints
                .FindAsync(id)
                ?? throw new KeyNotFoundException($"HolePoint with id {id} does not exist"));
        }

        public async Task<HolePointDTO> UpdateHolePoint(JsonPatchDocument<HolePoint> holePoint, int id)
        {
            var point = await dataContext.HolePoints.FindAsync(id)
                ?? throw new KeyNotFoundException($"HolePoint with id {id} does not exist");
            holePoint.ApplyTo(point);

            await dataContext
                .SaveChangesAsync();
            return mapper
                .Map<HolePointDTO>(point);
        }

        public async Task DeleteHolePoint(int id)
        {
            dataContext.HolePoints
                .Remove(await dataContext.HolePoints
                .FindAsync(id)
                ?? throw new KeyNotFoundException($"HolePoint with id {id} does not exist"));
        }
    }
}
