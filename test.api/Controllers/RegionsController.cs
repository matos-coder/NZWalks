using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using test.api.CustomValidate;
using test.api.data;
using test.api.models.domain;
using test.api.models.DTOs;
using test.api.Repositories;

namespace test.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class RegionsController : ControllerBase
    {
        private readonly walksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(walksDbContext dbContext, IRegionRepository regionRepository,IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }
        //get all region
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll([FromQuery] string? sortBy, [FromQuery] bool? isAsending, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize= 1000) 
        {
            //get data from database with model
            var regionsDomain = await regionRepository.GetAllAsync(sortBy, isAsending ?? true,pageNumber,pageSize);

            //map domain model to dto
            var regionsDto = mapper.Map<List<regionsdto>>(regionsDomain);

            //return the dto not the model

            return Ok(regionsDto);
        }
        //get by id
        [HttpGet]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetById([FromRoute] Guid id) 
        {
            //var regions = dbContext.regions.Find(id);
            var regionDomain = await regionRepository.GetByIdAsync(id);
      

            if (regionDomain == null)
            {
                return NotFound();
            }
            //map

            var regionsDto = mapper.Map<List<regionsdto>>(regionDomain);

            //return dto

            return Ok(regionsDto);
        }
        [HttpPost]
        [validateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> CreateAsync([FromBody] addRegionDto addRegionDto)
        {
                //map dto to model
                var regionModel = mapper.Map<region>(addRegionDto);

                //use model to create a region
                regionModel = await regionRepository.CreateAsync(regionModel);

                //map model to dto
                var regionsDto = mapper.Map<regionsdto>(regionModel);

                return CreatedAtAction(nameof(GetById), new { Id = regionModel.Id }, regionsDto);
           
        }
        [HttpPut]
        [Route("{id:Guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] putRegionDto updateRegionDto)
        {
            var regionModel = mapper.Map<region>(updateRegionDto);

            regionModel = await regionRepository.UpdateAsync(id, regionModel);

            if (regionModel == null) 
            { 
                return NotFound();
            }
            //map dto to model
            mapper.Map<putRegionDto>(regionModel);


            await dbContext.SaveChangesAsync();

            //convert model to dto
            var regionDto = mapper.Map<regionsdto>(regionModel);
            return Ok(regionDto);
        }
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionModel = await regionRepository.DeleteAsync(id);

            if(regionModel == null)
            {
                return NotFound();
            }

            return Ok();

        }
    }
}
