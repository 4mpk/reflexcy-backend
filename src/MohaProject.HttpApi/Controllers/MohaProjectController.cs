using MohaProject.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace MohaProject.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MohaProjectController : AbpControllerBase
{
    protected MohaProjectController()
    {
        LocalizationResource = typeof(MohaProjectResource);
    }
}
