using Soenneker.Instantly.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Instantly.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class InstantlyClientTests : HostedUnitTest
{
    private readonly IInstantlyClient _util;

    public InstantlyClientTests(Host host) : base(host)
    {
        _util = Resolve<IInstantlyClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
