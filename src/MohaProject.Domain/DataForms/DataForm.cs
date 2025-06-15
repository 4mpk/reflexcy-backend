using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace MohaProject.DataForms;

public class DataForm : AuditedAggregateRoot<Guid>
{
    public Guid CustomerId { get; set; }
    public int ProjectId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Bio { get; set; }
    public string Vision { get; set; }
    public string Skills { get; set; }
    public string DepartmentName { get; set; }
    public string UniversityName { get; set; }
    public string DateOfGraduation { get; set; }
    public string FirstPositionTitle { get; set; }
    public string FirstPositionDescription { get; set; }
    public string FirstPositionEndDate { get; set; }
    public string SecondPositionTitle { get; set; }
    public string SecondPositionDescription { get; set; }
    public string SecondPositionEndDate { get; set; }
    public string ThirdPositionTitle { get; set; }
    public string ThirdPositionDescription { get; set; }
    public string ThirdPositionEndDate { get; set; }
    public string FirstProjectName { get; set; }
    public string FirstProjectDescription { get; set; }
    public string SecondProjectName { get; set; }
    public string SecondProjectDescription { get; set; }
    public string ThirdProjectName { get; set; }
    public string ThirdProjectDescription { get; set; }
    public string LinkedinUrl { get; set; }
    public string FacebookUrl { get; set; }
    public string InstagramUrl { get; set; }
    public string XUrl { get; set; }
}
