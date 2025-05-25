using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.Favorites;

public class Favorite : AuditedAggregateRoot<Guid>
{
    public Guid UserId { get; set; }

    public int TemplateId { get; set; }
}
