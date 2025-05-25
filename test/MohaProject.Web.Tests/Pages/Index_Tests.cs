using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MohaProject.Pages;

public class Index_Tests : MohaProjectWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
