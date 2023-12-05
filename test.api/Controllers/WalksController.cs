using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using test.api.models.domain;
using test.api.models.DTOs;
using test.api.Repositories;

namespace test.api.Controllers
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
        public async Task<IActionResult> Create([FromBody] addWalkDto addWalkDto)
        {
            var walkModel = mapper.Map<walk>(addWalkDto);
            await walkRepository.CreateAsync(walkModel);

            var walkDto = mapper.Map<WalkDto>(walkModel);
            return Ok(walkDto);
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            //get data from database with model
            var walkModel = await walkRepository.GetAllAsync();

            //map domain model to dto
            var walkDto = mapper.Map<List<WalkDto>>(walkModel);

            //return the dto not the model

            return Ok(walkDto);
        }
    }
}
