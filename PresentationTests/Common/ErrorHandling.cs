using PresentationTests.Helpers;
using System.Net;

namespace PresentationTests.NewFolder;

public class ErrorHandling
{
    [Fact]
    public async Task GET_Throw_Responds_404()
    {
    await using var application = new TestingFactory();
    using var client = application.CreateClient();

    using var response = await client.GetAsync("/throw");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }
}
