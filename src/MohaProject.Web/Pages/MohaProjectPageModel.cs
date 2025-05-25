using MohaProject.Localization;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace MohaProject.Web.Pages;

/* Inherit your PageModel classes from this class.
 */
public abstract class MohaProjectPageModel : AbpPageModel
{
    protected MohaProjectPageModel()
    {
        LocalizationResourceType = typeof(MohaProjectResource);
    }
}
