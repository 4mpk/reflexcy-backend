using MohaProject.Samples;
using Xunit;

namespace MohaProject.EntityFrameworkCore.Applications;

[Collection(MohaProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<MohaProjectEntityFrameworkCoreTestModule>
{

}
