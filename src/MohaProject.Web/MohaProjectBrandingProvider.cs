using Microsoft.Extensions.Localization;
using MohaProject.Localization;
using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace MohaProject.Web;

[Dependency(ReplaceServices = true)]
public class MohaProjectBrandingProvider : DefaultBrandingProvider
{
    private IStringLocalizer<MohaProjectResource> _localizer;

    public MohaProjectBrandingProvider(IStringLocalizer<MohaProjectResource> localizer)
    {
        _localizer = localizer;
    }

    public override string AppName => _localizer["AppName"];
}
