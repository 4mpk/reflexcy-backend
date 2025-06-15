using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Users;
using Volo.Abp.AspNetCore.Mvc;
using System.Linq;
using System;

namespace MohaProject.Web.Controllers;

[Authorize]
[Route("/File")]
public class FileController : AbpController
{
    [HttpPost("uploadProfileImage")]
    public async Task<IActionResult> UploadFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("File not selected");
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        var files = Directory.GetFiles(folderPath, $"{CurrentUser.GetId()}*");

        foreach (var fileToDelete in files)
        {
            try
            {
                System.IO.File.Delete(fileToDelete);
                Console.WriteLine($"Deleted: {fileToDelete}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file {fileToDelete}: {ex.Message}");
            }
        }

        // Save path: wwwroot/uploads/{filename}
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", $"{CurrentUser.GetId()}_{file.FileName}");

        // Ensure directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filePath));

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return Ok(new { message = "File uploaded successfully", filePath });
    }

    [HttpGet("GetProfileImage")]
    public async Task<IActionResult> GetProfileFileAsync()
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        // Find the first file that starts with "555"
        var fileName = Directory.GetFiles(folderPath)
                                .Select(Path.GetFileName)
                                .FirstOrDefault(f => f.StartsWith(CurrentUser.GetId().ToString()));

        if (fileName == null)
            return NotFound("No file starting with 555 found.");

        var fileUrl = $"{Request.Scheme}://{Request.Host}/uploads/{fileName}";

        return Ok(new { url = fileUrl });
    }

    [HttpPost("DeleteProfileImage")]
    public async Task<IActionResult> DeleteProfileFileAsync()
    {
        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");

        var files = Directory.GetFiles(folderPath, $"{CurrentUser.GetId()}*");

        foreach (var fileToDelete in files)
        {
            try
            {
                System.IO.File.Delete(fileToDelete);
                Console.WriteLine($"Deleted: {fileToDelete}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file {fileToDelete}: {ex.Message}");
            }
        }
        return Ok();
    }
}
