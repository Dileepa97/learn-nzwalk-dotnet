﻿using Microsoft.EntityFrameworkCore;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;

namespace NZWalksApi.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLRegionRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id.Equals(id));

            if (region == null)
            {
                return null;
            }

            dbContext.Regions.Remove(region);
            await dbContext.SaveChangesAsync();

            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
           return await dbContext.Regions.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await dbContext.Regions.FirstOrDefaultAsync(r => r.Id.Equals(id));

            if (existingRegion == null)
            {
                return null;
            }

            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            return existingRegion;
        }
    }
}
