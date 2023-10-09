using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NZWalksApi.CustomActionFilters;
using NZWalksApi.Data;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;
using NZWalksApi.Repositories;
using System.Text.Json;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {

        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;
        private readonly ILogger<RegionsController> logger;

        public RegionsController( IRegionRepository regionRepository, IMapper mapper, ILogger<RegionsController> logger)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //logger.LogInformation("GetAllRegions Action Method was invoked");
            //logger.LogWarning("This is warning log");
            //logger.LogError("This is error log");

            //try
            //{
            //    throw new Exception("This is custom exception");
            //} 
            //catch (Exception e)
            //{
            //    logger.LogError(e, e.Message);
            //    throw;
            //}

            var regions = await regionRepository.GetAllAsync();

            //var regionsDto = new List<RegionDto>();

            //foreach (var region in regions)
            //{
            //    regionsDto.Add(new RegionDto()
            //    {
            //        Id = region.Id,
            //        Code = region.Code,
            //        Name = region.Name,
            //        RegionImageUrl = region.RegionImageUrl
            //    });
            //}

            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            logger.LogInformation($"Finished GetAllRegions Action Method with data: {JsonSerializer.Serialize(regionsDto)}");

            return Ok(regionsDto);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id);

            var region = await regionRepository.GetByIdAsync(id);

            if (region == null )
            { 
                return NotFound();
            }

            //var regionDto = new RegionDto()
            //{
            //    Id = region.Id,
            //    Code = region.Code,
            //    Name = region.Name,
            //    RegionImageUrl = region.RegionImageUrl
            //};

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }


        [HttpPost]
        [ValidateModle]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto regionRequestDto)
        {
            //Sam functionality was replaced by [ValidateModle] attribute
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            var region = mapper.Map<Region>(regionRequestDto);

            region = await regionRepository.CreateAsync(region);

            var regionDto = mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }


        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModle]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto regionRequestDto)
        {
            var region = mapper.Map<Region>(regionRequestDto);

            region = await regionRepository.UpdateAsync(id, region);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }


        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }
    } 
}
