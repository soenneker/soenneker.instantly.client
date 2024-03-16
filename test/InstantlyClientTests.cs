using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Instantly.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;
using Xunit.Abstractions;

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
