using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.SavedProjects;

public class SavedProject : AuditedAggregateRoot<Guid>
{
    public Guid UserId { get; set; }

    public int TemplateId { get; set; }
}
