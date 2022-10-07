using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.DataDB;

namespace Web_Admin_Client.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("PostImage")]
        public async Task<ImageDto> PostImage([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return null;
            string fileName = image.FileName;
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);

            }
            ImageDto imageUpload = new ImageDto();
            imageUpload.HaBia = fileName;

            return imageUpload;
        }
           
    }
}
