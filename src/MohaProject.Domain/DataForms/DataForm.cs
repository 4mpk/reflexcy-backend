using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.DataForms;

public class DataForm : AuditedAggregateRoot<Guid>
{
    public Guid CustomerId { get; set; }
    public int ProjectId { get; set; }
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    public string LastName { get; set; }

    public string Gender { get; set; }

    public DateTime Birthday { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Bio { get; set; }

    public string Experience { get; set; }

    public string ProjectDetails { get; set; }

    public string ProjectLinks { get; set; }

    public string LinkedinUrl { get; set; }

    public string GithubUrl { get; set; }

    public string InstagramUrl { get; set; }

    public string TiktokUrl { get; set; }

    public string CertificationName { get; set; }
}
