using Soenneker.Monday.GraphQlClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Monday.GraphQlClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MondayGraphQlClientUtilTests : HostedUnitTest
{
    private readonly IMondayGraphQlClientUtil _graphqlclientutil;

    public MondayGraphQlClientUtilTests(Host host) : base(host)
    {
        _graphqlclientutil = Resolve<IMondayGraphQlClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
