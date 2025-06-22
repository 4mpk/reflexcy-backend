using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
namespace MohaProject.Entities;

public interface IEntityAppService : IApplicationService
{
    Task<PagedResultDto<ReportBug>> GetReportBugsAsync();
    Task<PagedResultDto<Feedback>> GetFeedbacksAsync();
    Task<PagedResultDto<RequestFeature>> GetRequestFeaturesAsync();
    Task<PagedResultDto<ContactSupport>> GetContactSupportAsync();
}
