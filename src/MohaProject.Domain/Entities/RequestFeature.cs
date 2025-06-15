using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.Entities;

public class RequestFeature : AuditedAggregateRoot<Guid>
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Befefit { get; set; }
}
