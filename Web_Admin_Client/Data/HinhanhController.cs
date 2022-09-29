using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Admin_Client.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class HinhanhController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HinhanhController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpPost("PostImage")]
        public async Task<IActionResult> PostImage([FromForm] IFormFile image)
        {
            if (image == null || image.Length == 0)
                return BadRequest("Vui lòng chọn ảnh");
            string fileName = image.FileName;
            string extension = Path.GetExtension(fileName);
            string[] allow = { ".jpg", ".png" };
            if (!allow.Contains(extension.ToLower()))
                return BadRequest("Ảnh không hợp lệ, Vui lòng chọn ảnh khác");
            string fileNameNew = $"{Guid.NewGuid()}{extension}";
            string filePath = Path.Combine(_webHostEnvironment.ContentRootPath, "wwwroot", "images", fileNameNew);

            using (var fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                await image.CopyToAsync(fileStream);

            }
            return Ok($"image/{fileNameNew}");
        }
    }
}
