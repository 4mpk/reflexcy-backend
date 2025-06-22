using System.Threading.Tasks;
using MohaProject.Localization;
using MohaProject.MultiTenancy;
using Volo.Abp.Identity.Web.Navigation;
using Volo.Abp.SettingManagement.Web.Navigation;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MohaProject.Web.Menus;

public class MohaProjectMenuContributor : IMenuContributor
{
    public async Task ConfigureMenuAsync(MenuConfigurationContext context)
    {
        if (context.Menu.Name == StandardMenus.Main)
        {
            await ConfigureMainMenuAsync(context);
        }
    }

    private Task ConfigureMainMenuAsync(MenuConfigurationContext context)
    {
        var administration = context.Menu.GetAdministration();
        var l = context.GetLocalizer<MohaProjectResource>();

        context.Menu.Items.Insert(
            0,
            new ApplicationMenuItem(
                MohaProjectMenus.Home,
                l["Menu:Home"],
                "~/",
                icon: "fas fa-home",
                order: 0
            )
        );

        administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
        //administration.TryRemoveMenuItem(IdentityMenuNames.GroupName);

        administration.SetSubItemOrder(SettingManagementMenuNames.GroupName, 3);

        context.Menu.Items.Insert(1, 
            new ApplicationMenuItem(
                MohaProjectMenus.ReportBug,
                "Report Bug",
                icon: "fa-solid fa-circle custom-dot",
                url: "/ReportBugs", 
                order: 1));

        context.Menu.Items.Insert(1, 
            new ApplicationMenuItem(
                MohaProjectMenus.ContactSupport,
                "Contact Support",
                icon: "fa-solid fa-circle custom-dot",
                url: "/ContactSupport", 
                order: 1));

        context.Menu.Items.Insert(1, 
            new ApplicationMenuItem(
                MohaProjectMenus.Feedback,
                "Feedback",
                icon: "fa-solid fa-circle custom-dot",
                url: "/Feedbacks", 
                order: 1));

        context.Menu.Items.Insert(1, 
            new ApplicationMenuItem(
                MohaProjectMenus.RequestFeature,
                "Request Feature",
                icon: "fa-solid fa-circle custom-dot",
                url: "/RequestFeatures", 
                order: 1));

        return Task.CompletedTask;
    }
}
