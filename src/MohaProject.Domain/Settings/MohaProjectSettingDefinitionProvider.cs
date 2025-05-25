using Volo.Abp.Settings;

namespace MohaProject.Settings;

public class MohaProjectSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MohaProjectSettings.MySetting1));
    }
}
