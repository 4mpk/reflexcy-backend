using Xunit;

namespace MohaProject.EntityFrameworkCore;

[CollectionDefinition(MohaProjectTestConsts.CollectionDefinitionName)]
public class MohaProjectEntityFrameworkCoreCollection : ICollectionFixture<MohaProjectEntityFrameworkCoreFixture>
{

}
