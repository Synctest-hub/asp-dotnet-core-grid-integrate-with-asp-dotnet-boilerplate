using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace SyncfusionGrid.Pages;

public class Index_Tests : SyncfusionGridWebTestBase
{
    [Fact]
    public async Task Welcome_Page()
    {
        var response = await GetResponseAsStringAsync("/");
        response.ShouldNotBeNull();
    }
}
