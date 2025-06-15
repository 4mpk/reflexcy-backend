using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohaProject.DataForms;
using MohaProject.Web.Models;
using SelectPdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace MohaProject.Web.Controllers;

[Authorize]
[Route("/Templates")]
public class TemplatesController : AbpController
{
    private readonly IRepository<DataForm, Guid> _dataFormRepository;
    private Dictionary<int, string> templateCategories = new()
    {
        { 1, "Software" },
        { 2, "Software" },
        { 3, "Software" },
        { 4, "Software" },
        { 5, "Photography" },
        { 6, "Photography" },
        { 7, "Fashion" },
        { 8, "Fashion" },
        { 9, "Graphic Design" },
        { 10, "Graphic Design" },
        { 11, "Computer" },
        { 12, "Computer" }
    };

    public TemplatesController(
        IRepository<DataForm, Guid> dataFormRepository)
    {
        _dataFormRepository = dataFormRepository;
    }

    [HttpGet("PDF")]
    public async Task<IActionResult> GetTemplatePdf(Guid dataFormId)
    {
        var dataForm = await _dataFormRepository.GetAsync(dataFormId);

        string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "template.html");
        string htmlTemplate = System.IO.File.ReadAllText(templatePath);

        var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates");

        var profile = Directory.GetFiles(folderPath)
                                .Select(Path.GetFileName)
                                .FirstOrDefault(f => f.StartsWith($"{dataForm.Id}_Profile_"));

        var profileUrl = profile != null ? $"{Request.Scheme}://{Request.Host}/templates/{profile}" : "";
        
        var firstProject = Directory.GetFiles(folderPath)
                                .Select(Path.GetFileName)
                                .FirstOrDefault(f => f.StartsWith($"{dataForm.Id}_FirstProjectPicture_"));

        var firstProjectUrl = firstProject != null ? $"{Request.Scheme}://{Request.Host}/templates/{firstProject}" : "";
        
        var secondProject = Directory.GetFiles(folderPath)
                                .Select(Path.GetFileName)
                                .FirstOrDefault(f => f.StartsWith($"{dataForm.Id}_SecondProjectPicture_"));

        var secondProjectUrl = secondProject != null ? $"{Request.Scheme}://{Request.Host}/templates/{secondProject}" : "";
        
        var thirdProject = Directory.GetFiles(folderPath)
                                .Select(Path.GetFileName)
                                .FirstOrDefault(f => f.StartsWith($"{dataForm.Id}_ThirdProjectPicture_"));

        var thirdProjectUrl = thirdProject != null ? $"{Request.Scheme}://{Request.Host}/templates/{thirdProject}" : "";
        var displayBio = string.IsNullOrEmpty(dataForm.Bio) ? "display: none" : "";
        var displayVision = string.IsNullOrEmpty(dataForm.Vision) ? "display: none" : "";
        var displaySkills = string.IsNullOrEmpty(dataForm.Skills) ? "display: none" : "";
        var displayEducation = string.IsNullOrEmpty(dataForm.DepartmentName) 
            && string.IsNullOrEmpty(dataForm.UniversityName) ? "display: none" : "";

        var displayEducationPage = string.IsNullOrEmpty(dataForm.DepartmentName) 
            && string.IsNullOrEmpty(dataForm.UniversityName)
            && string.IsNullOrEmpty(dataForm.Skills) ? "display: none" : "";
        var displayFirstPosition= string.IsNullOrEmpty(dataForm.FirstPositionTitle) ? "display: none" : "";
        var displaySecondPosition= string.IsNullOrEmpty(dataForm.SecondPositionTitle) ? "display: none" : "";
        var displayThirdPosition= string.IsNullOrEmpty(dataForm.ThirdPositionTitle) ? "display: none" : "";
        var displayFirstProject= string.IsNullOrEmpty(dataForm.FirstProjectName) ? "display: none" : "";
        var displaySecondProject = string.IsNullOrEmpty(dataForm.SecondProjectName) ? "display: none" : "";
        var displayThirdProject = string.IsNullOrEmpty(dataForm.ThirdProjectName) ? "display: none" : "";
        var displayProjects = string.IsNullOrEmpty(dataForm.FirstProjectName) 
            && string.IsNullOrEmpty(dataForm.SecondProjectName)
            && string.IsNullOrEmpty(dataForm.ThirdProjectName) ? "display: none" : "";

        string htmlContent = htmlTemplate
            .Replace("{{FirstName}}", dataForm.FirstName)
            .Replace("{{LastName}}", dataForm.LastName)
            .Replace("{{Email}}", dataForm.Email)
            .Replace("{{Phone}}", dataForm.Phone)
            .Replace("{{CategoryName}}", templateCategories.GetValueOrDefault(dataForm.ProjectId))
            .Replace("{{Profile}}", profileUrl)
            .Replace("{{Vision}}", dataForm.Vision)
            .Replace("{{DisplayVision}}", displayVision)
            .Replace("{{Bio}}", dataForm.Bio)
            .Replace("{{DisplayBio}}", displayBio)
            .Replace("{{Skills}}", dataForm.Skills)
            .Replace("{{DisplaySkills}}", displaySkills)
            .Replace("{{DisplayEducation}}", displayEducation)
            .Replace("{{DisplayEducationPage}}", displayEducationPage)
            .Replace("{{DepartmentName}}", dataForm.DepartmentName)
            .Replace("{{UniversityName}}", dataForm.UniversityName)
            .Replace("{{DateOfGraduation}}", dataForm.DateOfGraduation)
            .Replace("{{DisplayFirstPosition}}", displayFirstPosition)
            .Replace("{{DisplaySecondPosition}}", displaySecondPosition)
            .Replace("{{DisplayThirdPosition}}", displayThirdPosition)
            .Replace("{{FirstPositionTitle}}", dataForm.FirstPositionTitle)
            .Replace("{{FirstPositionDescription}}", dataForm.FirstPositionDescription)
            .Replace("{{FirstPositionEndDate}}", dataForm.FirstPositionEndDate)
            .Replace("{{SecondPositionTitle}}", dataForm.SecondPositionTitle)
            .Replace("{{SecondPositionDescription}}", dataForm.SecondPositionDescription)
            .Replace("{{SecondPositionEndDate}}", dataForm.SecondPositionEndDate)
            .Replace("{{ThirdPositionTitle}}", dataForm.ThirdPositionTitle)
            .Replace("{{ThirdPositionDescription}}", dataForm.ThirdPositionDescription)
            .Replace("{{ThirdPositionEndDate}}", dataForm.ThirdPositionEndDate)
            .Replace("{{DisplayProjects}}", displayProjects)
            .Replace("{{DisplayFirstProject}}", displayFirstProject)
            .Replace("{{DisplaySecondProject}}", displaySecondProject)
            .Replace("{{DisplayThirdProject}}", displayThirdProject )
            .Replace("{{FirstProjectName}}", dataForm.FirstProjectName)
            .Replace("{{FirstProjectDescription}}", dataForm.FirstProjectDescription)
            .Replace("{{FirstProjectUrl}}", firstProjectUrl)
            .Replace("{{SecondProjectName}}", dataForm.SecondProjectName)
            .Replace("{{SecondProjectDescription}}", dataForm.SecondProjectDescription)
            .Replace("{{SecondProjectUrl}}", secondProjectUrl)
            .Replace("{{ThirdProjectName}}", dataForm.ThirdProjectName)
            .Replace("{{ThirdProjectDescription}}", dataForm.ThirdProjectDescription)
            .Replace("{{ThirdProjectUrl}}", thirdProjectUrl)
            .Replace("{{LinkedinUrl}}", dataForm.LinkedinUrl)
            .Replace("{{DisplayLinkedIn}}", string.IsNullOrEmpty(dataForm.LinkedinUrl) ? "display: none" : "")
            .Replace("{{FacebookUrl}}", dataForm.FacebookUrl)
            .Replace("{{DisplayFacebook}}", string.IsNullOrEmpty(dataForm.FacebookUrl) ? "display: none" : "")
            .Replace("{{XUrl}}", dataForm.XUrl)
            .Replace("{{DisplayX}}", string.IsNullOrEmpty(dataForm.XUrl) ? "display: none" : "block")
            .Replace("{{InstagramUrl}}", dataForm.InstagramUrl)
            .Replace("{{DisplayInstagram}}", string.IsNullOrEmpty(dataForm.InstagramUrl) ? "display: none" : "");

        // Convert HTML to PDF
        HtmlToPdf converter = new();
        converter.Options.PdfPageSize = PdfPageSize.Custom;
        converter.Options.PdfPageCustomSize = new System.Drawing.SizeF(288, 90);
        byte[] pdf = converter.ConvertHtmlString(htmlContent).Save();

        // Return file as download
        return File(pdf, "application/pdf", "Portfolio.pdf");
    }

    [HttpPost("DataForm")]
    public async Task<IActionResult> DataForm([FromForm] DataFormModel model)
    {
        try
        {
            if (model.ProjectId <= 0)
                return BadRequest("You have to select template before fulfill the form");

            var dataForm = new DataForm()
            {
                CustomerId = CurrentUser.GetId(),
                ProjectId = model.ProjectId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Phone = model.Phone ?? "",
                Vision = model.Vision ?? "",
                Bio = model.Bio ?? "",
                Skills = model.Skills ?? "",
                DepartmentName = model.DepartmentName ?? "",
                UniversityName = model.UniversityName ?? "",
                DateOfGraduation = model.DateOfGraduation ?? "",
                FirstPositionTitle = model.FirstPositionTitle ?? "",
                FirstPositionDescription = model.FirstPositionDescription ?? "",
                FirstPositionEndDate = model.FirstPositionEndDate ?? "",
                SecondPositionTitle = model.SecondPositionTitle ?? "",
                SecondPositionDescription = model.SecondPositionDescription ?? "",
                SecondPositionEndDate = model.SecondPositionEndDate ?? "",
                ThirdPositionTitle = model.ThirdPositionTitle ?? "",
                ThirdPositionDescription = model.ThirdPositionDescription ?? "",
                ThirdPositionEndDate = model.ThirdPositionEndDate ?? "",
                FirstProjectName = model.FirstProjectName ?? "",
                FirstProjectDescription = model.FirstProjectDescription ?? "",
                SecondProjectName = model.SecondProjectName ?? "",
                SecondProjectDescription = model.SecondProjectDescription ?? "",
                ThirdProjectName = model.ThirdProjectName ?? "",
                ThirdProjectDescription = model.ThirdProjectDescription ?? "",
                LinkedinUrl = model.LinkedinUrl ?? "",
                FacebookUrl = model.FacebookUrl ?? "",
                InstagramUrl = model.InstagramUrl ?? "",
                XUrl = model.XUrl ?? ""
            };

            await _dataFormRepository.InsertAsync(dataForm);

            var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates");

            if (model.Profile != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", $"{dataForm.Id}_Profile_{model.Profile.FileName}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.Profile.CopyToAsync(stream);
                }
            }
            if (model.FirstProjectPicture != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", $"{dataForm.Id}_FirstProjectPicture_{model.FirstProjectPicture.FileName}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.FirstProjectPicture.CopyToAsync(stream);
                }
            }
            if (model.SecondProjectPicture != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", $"{dataForm.Id}_SecondProjectPicture_{model.SecondProjectPicture.FileName}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.SecondProjectPicture.CopyToAsync(stream);
                }
            }
            if (model.ThirdProjectPicture != null)
            {
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "templates", $"{dataForm.Id}_ThirdProjectPicture_{model.ThirdProjectPicture.FileName}");

                Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.ThirdProjectPicture.CopyToAsync(stream);
                }
            }

            return RedirectToAction("GetTemplatePdf", new { dataFormId = dataForm.Id });
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = await _dataFormRepository.GetQueryableAsync();

        var dataForms = await query
            .AsNoTracking()
            .Where(e => e.CustomerId == CurrentUser.GetId())
            .ToListAsync();

        return Ok(dataForms);
    }
}