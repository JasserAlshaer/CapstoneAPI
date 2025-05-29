using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {

        [HttpGet("download/{filename}")]
        public IActionResult DownloadFile(string filename)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", filename);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found.");
                }

                var fileBytes = System.IO.File.ReadAllBytes(filePath);
                var fileName = Path.GetFileName(filePath);
                return File(fileBytes, "application/octet-stream", fileName);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            
        }
        //Encoding
        [HttpPost("[action]")]
        public async Task<IActionResult> EncodeFileToBase64(IFormFile file)
        {

            try
            {
                if (file == null || file.Length == 0)
                {
                    return BadRequest("File Not Exisit or Invalid");
                }
                using (var memoryStream = new MemoryStream())
                {
                    //copy file to memory
                    await file.CopyToAsync(memoryStream);
                    //Conver Byte to Base 64 String
                    string base64 = Convert.ToBase64String(memoryStream.ToArray());
                    //Add MIME Type
                    //read file content type 
                    string mimeType = file.ContentType;

                    return Ok($"data:{mimeType};base64,{base64}");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file == null || file.Length == 0)
                {
                    throw new Exception("Please Enter Valid File");
                }
                //generate new file Name extracted from current file name 
                //string newFileName = DateTime.Now.ToString()+"-"+file.FileName;
                string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                string directory = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");
                using (var fs = new FileStream(Path.Combine(directory, fileName), FileMode.Create))
                {
                    await file.CopyToAsync(fs);
                }
                return Ok($"/uploads/{fileName}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("delete/{filename}")]
        public IActionResult DeleteFile(string filename)
        {
            try
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Attachments", filename);

                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("File not found.");
                }

                System.IO.File.Delete(filePath);
                return Ok($"File {filename} deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
    }
}
