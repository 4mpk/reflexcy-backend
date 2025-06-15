using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.Entities;

public class ContactSupport : AuditedAggregateRoot<Guid>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Message { get; set; }
}
