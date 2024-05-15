using Application.Interfaces.Persistence;
using Domain.Investors;
using Moq.AutoMock;
using NUnit.Framework;

namespace Application.Investors.Queries.GetInvestorList;

[TestFixture]
public class GetInvestorListQueryTests
{
    private GetInvestorsListQuery _query;
    private AutoMocker _mocker;
    private Investor _investor;
    private List<Investor> _investors;

    private Guid _id = new("ECCE9123-9477-4060-870B-0D59250BFEB8");
    private const string FirstName = "first";

    [SetUp]
    public void SetUp()
    {
        _mocker = new AutoMocker();

        _investor = new Investor
        {
            Id = _id,
            FirstName = FirstName
        };

        _investors = new List<Investor>
        {
            _investor
        };

        _mocker.GetMock<IInvestorRepository>()
            .Setup(_ => _.GetAll())
            .Returns(_investors.AsQueryable());

        _query = _mocker.CreateInstance<GetInvestorsListQuery>();
    }

    [Test]
    public void TestExecuteShouldReturnListOfInvestors()
    {
        var results = _query.Execute();
        var result = results.Single();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(_id));
        Assert.That(result.FirstName, Is.EqualTo(FirstName));
    }
}