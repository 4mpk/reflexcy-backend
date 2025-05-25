using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohaProject.DataForms;
using SelectPdf;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace MohaProject.Web.Controllers;

[Route("/Templates")]
public class TemplatesController : AbpController
{
    private readonly IRepository<DataForm, Guid> _dataFormRepository;

    public TemplatesController(
        IRepository<DataForm, Guid> dataFormRepository)
    {
        _dataFormRepository = dataFormRepository;
    }

    /// <summary>
    /// we chack inside the method  if CurrentUser.IsAuthenticated so must be related to him 
    /// else 
    /// do not care,  due to calls from dashboard
    /// </summary>
    //[Authorize]
    [HttpGet("PDF")]
    public async Task<IActionResult> GetTemplatePdf()
    {
        string templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "template.html");
        string htmlTemplate = System.IO.File.ReadAllText(templatePath);
        string htmlContent = htmlTemplate
            .Replace("{{Name}}", "Mervan Kasir")
            .Replace("{{Project}}", "Ecommerce Platform")
            .Replace("{{Description}}", "A modern, responsive web app built with C# and React.");

        // Convert HTML to PDF
        HtmlToPdf converter = new();
        converter.Options.PdfPageSize = PdfPageSize.Custom;
        converter.Options.PdfPageCustomSize = new System.Drawing.SizeF(288, 100);
        converter.Options.MarginLeft = 20;
        converter.Options.MarginRight = 20;
        byte[] pdf = converter.ConvertHtmlString(htmlContent).Save();

        // Return file as download
        return File(pdf, "application/pdf", "Portfolio.pdf");
    }

    [HttpPost("DataForm")]
    public async Task<IActionResult> DataForm(DataFormModel model)
    {
        using var reader = new StreamReader(Request.Body);
        var body = await reader.ReadToEndAsync();

        try
        {
            var form = JsonSerializer.Deserialize<DataFormModel>(body);

            if (form.ProjectId <= 0)
                return BadRequest("You have to select template before fulfill the form");

            var dataForm = new DataForm()
            {
                CustomerId = CurrentUser.GetId(),
                ProjectId = form.ProjectId,
                FirstName = form.FirstName,
                MiddleName = form.MiddleName,
                LastName = form.LastName,
                Gender = form.Gender,
                Birthday = form.Birthday,
                Email = form.Email,
                Phone = form.Phone,
                Bio = form.Bio,
                Experience = form.Experience,
                ProjectDetails = form.ProjectDetails,
                ProjectLinks = form.ProjectLinks,
                LinkedinUrl = form.LinkedinUrl,
                GithubUrl = form.GithubUrl,
                InstagramUrl = form.InstagramUrl,
                TiktokUrl = form.TiktokUrl,
                CertificationName = form.CertificationName,
            };

            await _dataFormRepository.InsertAsync(dataForm);

        }
        catch (Exception)
        {
            return BadRequest();
        }
        
        return Ok();
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