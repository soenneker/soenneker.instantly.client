using Soenneker.Instantly.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Instantly.Client.Tests;

[Collection("Collection")]
public class InstantlyClientTests : FixturedUnitTest
{
    private readonly IInstantlyClient _util;

    public InstantlyClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IInstantlyClient>(true);
    }
}
