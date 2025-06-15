using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.Entities;

public class ReportBug : AuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Steps { get; set; }
}
