using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.CustomActionFilters;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;
using NZWalksApi.Repositories;
using System.Net;

namespace NZWalksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpPost]
        [ValidateModle]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto requestDto)
        {
            var walk = mapper.Map<Walk>(requestDto);

            walk = await walkRepository.CreateAsync(walk);
             
            var walkDto = mapper.Map<WalkDto>(walk);

            return CreatedAtAction(nameof(GetById), new {id = walk.Id}, walkDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] string? filterQuery, 
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 50)
        {
            //Exception handling in method
            //try
            //{
            //    throw new Exception("This is custom exception.");

            //}
            //catch (Exception)
            //{

            //    return Problem("Something went wrong", null, (int)HttpStatusCode.InternalServerError);
            //}

            //Exception handling using middleware
            throw new Exception("This is custom exception.");

            var walk = await walkRepository.GetAllAsync(filterOn, filterQuery, sortBy, isAscending ?? true, pageNumber, pageSize);

            return Ok(mapper.Map<List<WalkDto>>(walk));
        }

        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walk = await walkRepository.GetByIdAsync(id);

            if(walk == null)
            {
                return NotFound();
            } 

            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModle]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto requestDto)
        {
            var walk = mapper.Map<Walk>(requestDto);

            walk = await walkRepository.UpdateAsync(id, walk);

            if (walk == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walk));
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deltedWalk = await walkRepository.DeleteAsync(id);

            if(deltedWalk == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deltedWalk));
        }
    }
}
