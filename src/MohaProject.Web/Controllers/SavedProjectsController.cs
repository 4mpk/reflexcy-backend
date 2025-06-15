using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MohaProject.SavedProjects;
using System;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace MohaProject.Web.Controllers;

[Authorize]
[Route("/SavedProjects")]
public class SavedProjectsController : AbpController
{
    private readonly IRepository<SavedProject, Guid> _SavedProjectRepository;

    public SavedProjectsController(
        IRepository<SavedProject, Guid> savedProjectRepository)
    {
        _SavedProjectRepository = savedProjectRepository;
    }

    /// <summary>
    /// we chack inside the method  if CurrentUser.IsAuthenticated so must be related to him 
    /// else 
    /// do not care,  due to calls from dashboard
    /// </summary>
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var query = await _SavedProjectRepository.GetQueryableAsync();

        var favorites = await query
            .AsNoTracking()
            .Where(e => e.UserId == CurrentUser.GetId())
            .ToListAsync();

        return Ok(favorites);
    }

    [HttpPost("MakeSave")]
    public async Task<IActionResult> MakeSaveAsync(int templateId)
    {
        if (templateId == 0)
            return RedirectToAction("GetAll");

        var item = await _SavedProjectRepository
            .FindAsync(e => e.TemplateId == templateId && e.UserId == CurrentUser.GetId());

        if (item == null)
        {
            var savedProject = new SavedProject()
            {
                UserId = CurrentUser.GetId(),
                TemplateId = templateId
            };

            await _SavedProjectRepository.InsertAsync(savedProject);
        }
        else
        {
            await _SavedProjectRepository.DeleteAsync(item);
        }

        return Ok();
    }
}