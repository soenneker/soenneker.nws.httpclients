using Soenneker.Nws.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Nws.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class OpenApiHttpClientTests : HostedUnitTest
{
    private readonly INwsOpenApiHttpClient _httpclient;

    public OpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<INwsOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
