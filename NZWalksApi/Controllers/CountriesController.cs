using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NZWalksApi.Models.Domain;
using NZWalksApi.Models.DTO;

namespace NZWalksApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]
    public class CountriesController : ControllerBase
    {
        private readonly IMapper mapper;

        public CountriesController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> GetV1()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.Parse("d2d7b15a-34b0-400a-a5df-80e934b82823"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("537b80ea-ec5e-416a-a610-c272e1adcf3a"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("a3c05557-24f9-4000-bfad-ea380be1eff5"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("57b653f5-2dde-4910-8a13-1a19a7871e56"),
                    Name = "Country 01",
                    Region = "Asia"
                }
            };

            var countriesDto = mapper.Map<List<CountryDtoV1>>(countries);

            return Ok(countriesDto);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> GetV2()
        {
            var countries = new List<Country>
            {
                new Country
                {
                    Id = Guid.Parse("d2d7b15a-34b0-400a-a5df-80e934b82823"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("537b80ea-ec5e-416a-a610-c272e1adcf3a"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("a3c05557-24f9-4000-bfad-ea380be1eff5"),
                    Name = "Country 01",
                    Region = "Asia"
                },
                new Country
                {
                    Id = Guid.Parse("57b653f5-2dde-4910-8a13-1a19a7871e56"),
                    Name = "Country 01",
                    Region = "Asia"
                }
            };

            var countriesDto = mapper.Map<List<CountryDtoV2>>(countries);

            return Ok(countriesDto);
        }
    }
}
