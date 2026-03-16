using Soenneker.Nws.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Nws.HttpClients.Tests;

[Collection("Collection")]
public sealed class OpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IOpenApiHttpClient _httpclient;

    public OpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
