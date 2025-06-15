using Microsoft.AspNetCore.Mvc;
using MohaProject.Entities;
using MohaProject.Web.Models;
using System;
using System.Threading.Tasks;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Domain.Repositories;

namespace MohaProject.Web.Controllers;


[Route("/Entities")]
public class EntitiesController : AbpController
{
    private readonly IRepository<ContactSupport, Guid> _ContactSupportRepository;
    private readonly IRepository<RequestFeature, Guid> _RequestFeatureRepository;
    private readonly IRepository<ReportBug, Guid> _ReportBugRepository;
    private readonly IRepository<Feedback, Guid> _FeedbackRepository;

    public EntitiesController(
        IRepository<ContactSupport, Guid> contactSupportRepository,
        IRepository<RequestFeature, Guid> requestFeatureRepository,
        IRepository<ReportBug, Guid> reportBugRepository,
        IRepository<Feedback, Guid> feedbackRepository)
    {
        _ContactSupportRepository = contactSupportRepository;
        _RequestFeatureRepository = requestFeatureRepository;
        _ReportBugRepository = reportBugRepository;
        _FeedbackRepository = feedbackRepository;
    }

    [HttpPost("ContactSupport")]
    public async Task<IActionResult> ContactSupportAsync(ContactSupportModel model)
    {
        if (model is null)
            return BadRequest();

        var entity = new ContactSupport()
        {
            Email = model.Email,
            Name = model.Name,
            Message = model.Message,
        };

        await _ContactSupportRepository.InsertAsync(entity);

        return Ok();
    }

    [HttpPost("ReportBug")]
    public async Task<IActionResult> ReportBugAsync(ReportBugModel model)
    {
        if (model is null)
            return BadRequest();

        var entity = new ReportBug()
        {
            Title = model.Title,
            Description = model.Description,
            Steps = model.Steps,
        };

        await _ReportBugRepository.InsertAsync(entity);

        return Ok();
    }

    [HttpPost("RequestFeature")]
    public async Task<IActionResult> RequestFeatureAsync(RequestFeatureModel model)
    {
        if (model is null)
            return BadRequest();

        var entity = new RequestFeature()
        {
            Title = model.Title,
            Description = model.Description,
            Befefit = model.Befefit,
        };

        await _RequestFeatureRepository.InsertAsync(entity);

        return Ok();
    }

    [HttpPost("Feedback")]
    public async Task<IActionResult> FeedbackAsync(FeedbackModel model)
    {
        if (model is null)
            return BadRequest();

        var entity = new Feedback()
        {
            Rating = model.Rating,
            Comments = model.Comments,
        };

        await _FeedbackRepository.InsertAsync(entity);

        return Ok();
    }
}