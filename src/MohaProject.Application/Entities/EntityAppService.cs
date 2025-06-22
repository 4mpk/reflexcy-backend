using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace MohaProject.Entities;

public class EntityAppService : ApplicationService, IEntityAppService
{
    private readonly IRepository<ContactSupport, Guid> _ContactSupportRepository;
    private readonly IRepository<RequestFeature, Guid> _RequestFeatureRepository;
    private readonly IRepository<ReportBug, Guid> _ReportBugRepository;
    private readonly IRepository<Feedback, Guid> _FeedbackRepository;

    public EntityAppService(
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

    public async Task<PagedResultDto<ContactSupport>> GetContactSupportAsync()
    {
        var items = await _ContactSupportRepository.GetListAsync();

        return new PagedResultDto<ContactSupport>
        {
            TotalCount = items.Count,
            Items = items
        };
    }

    public async Task<PagedResultDto<Feedback>> GetFeedbacksAsync()
    {
        var items = await _FeedbackRepository.GetListAsync();

        return new PagedResultDto<Feedback>
        {
            TotalCount = items.Count,
            Items = items
        };
    }

    public async Task<PagedResultDto<ReportBug>> GetReportBugsAsync()
    {
        var items = await _ReportBugRepository.GetListAsync();

        return new PagedResultDto<ReportBug>
        {
            TotalCount = items.Count,
            Items = items
        };
    }

    public async Task<PagedResultDto<RequestFeature>> GetRequestFeaturesAsync()
    {
        var items = await _RequestFeatureRepository.GetListAsync();

        return new PagedResultDto<RequestFeature>
        {
            TotalCount = items.Count,
            Items = items
        };
    }
}
