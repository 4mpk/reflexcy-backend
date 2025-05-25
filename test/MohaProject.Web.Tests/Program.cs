using Microsoft.AspNetCore.Builder;
using MohaProject;
using Volo.Abp.AspNetCore.TestBase;

var builder = WebApplication.CreateBuilder();

builder.Environment.ContentRootPath = GetWebProjectContentRootPathHelper.Get("MohaProject.Web.csproj");
await builder.RunAbpModuleAsync<MohaProjectWebTestModule>(applicationName: "MohaProject.Web" );

public partial class Program
{
}
