using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.Entities;

public class Feedback : AuditedAggregateRoot<Guid>
{
    public string Rating { get; set; }
    public string Comments { get; set; }
}
