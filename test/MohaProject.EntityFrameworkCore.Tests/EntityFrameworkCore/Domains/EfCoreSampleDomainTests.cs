using MohaProject.Samples;
using Xunit;

namespace MohaProject.EntityFrameworkCore.Domains;

[Collection(MohaProjectTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<MohaProjectEntityFrameworkCoreTestModule>
{

}
