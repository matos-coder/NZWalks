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
   
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        [HttpPost]
        [Route("Upload")]
        
        public async Task<IActionResult> Upload([FromForm] imgUploadDto request)
        {
            ValidateFileUpload(request);
            if (ModelState.IsValid)
            {
                var imgModel = new image
                {
                    File= request.File,
                    FileDescription= request.FileDescription,
                    FileName = request.File.FileName,
                    FileExtension = Path.GetExtension(request.File.FileName),
                    FileSizeInByte = request.File.Length
                };
                await imageRepository.Upload(imgModel);
                return Ok(imgModel);
            }
            return BadRequest(ModelState);
        }
        private void ValidateFileUpload(imgUploadDto request)
        {
            var allowedExtension = new string[] { "jpg", "jpeg", "png" };
            if (allowedExtension.Contains(Path.GetExtension(request.File.FileName))) 
            {
                ModelState.AddModelError("file", "unsupported file extension");
            }
            if (request.File.Length > 10000000)
            {
                ModelState.AddModelError("file", "file is more than 10mb");
            }
        }
    }
}
