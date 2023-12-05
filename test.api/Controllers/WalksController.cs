using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.api.data;
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
        private readonly walksDbContext dbContext;

        public WalksController(IMapper mapper, IWalkRepository walkRepository,walksDbContext dbContext)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
            this.dbContext = dbContext;
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
        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var regions = dbContext.regions.Find(id);
            var walkModel = await walkRepository.GetByIdAsync(id);


            if (walkModel == null)
            {
                return NotFound();
            }
            //map

            var walkDto = mapper.Map<List<WalkDto>>(walkModel);

            //return dto

            return Ok(walkDto);
        }
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] updateWalkDto updateWalkDto)
        {
            var walkModel = mapper.Map<walk>(updateWalkDto);

            walkModel = await walkRepository.UpdateAsync(id, walkModel);

            if (walkModel == null)
            {
                return NotFound();
            }
            //map dto to model
            mapper.Map<updateWalkDto>(walkModel);


            await dbContext.SaveChangesAsync();

            //convert model to dto
            var walkDto = mapper.Map<updateWalkDto>(walkModel);
            return Ok(walkDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var walkModel = await walkRepository.DeleteAsync(id);

            if (walkModel == null)
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
