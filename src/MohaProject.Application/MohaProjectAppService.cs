using System;
using System.Collections.Generic;
using System.Text;
using MohaProject.Localization;
using Volo.Abp.Application.Services;

namespace MohaProject;

/* Inherit your application services from this class.
 */
public abstract class MohaProjectAppService : ApplicationService
{
    protected MohaProjectAppService()
    {
        LocalizationResource = typeof(MohaProjectResource);
    }
}
