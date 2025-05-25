using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;

namespace MohaProject;

public class DataFormModel
{
    [JsonPropertyName("projectId")]
    public int ProjectId { get; set; }

    [JsonPropertyName("firstName")]
    public string FirstName { get; set; }

    [JsonPropertyName("middleName")]
    public string MiddleName { get; set; }

    [JsonPropertyName("lastName")]
    public string LastName { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("dob")]
    public DateTime Birthday { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("phone")]
    public string Phone { get; set; }

    [JsonPropertyName("bio")]
    public string Bio { get; set; }

    [JsonPropertyName("experience")]
    public string Experience { get; set; }

    [JsonPropertyName("projectDetails")]
    public string ProjectDetails { get; set; }

    [JsonPropertyName("projectLinks")]
    public string ProjectLinks { get; set; }

    [JsonPropertyName("linkedin")]
    public string LinkedinUrl { get; set; }

    [JsonPropertyName("github")]
    public string GithubUrl { get; set; }

    [JsonPropertyName("instagram")]
    public string InstagramUrl { get; set; }

    [JsonPropertyName("tiktok")]
    public string TiktokUrl { get; set; }

    [JsonPropertyName("certification")]
    public string CertificationName { get; set; }

    [JsonPropertyName("profilePic")]
    public IFormFile Pofile { get; set; }

    [JsonPropertyName("certifications")]
    public List<IFormFile> Certifications { get; set; }
}
