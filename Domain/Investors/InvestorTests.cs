using NUnit.Framework;

namespace Domain.Investors;

[TestFixture]
public class InvestorTests
{
    private Investor _investor;
    private readonly Guid _id = new("01479C9B-EB60-4614-A58E-EB0B66316826");
    private const string FirstName = "first";
    
    [SetUp]
    public void SetUp()
    {
        _investor = new Investor();
    }

    [Test]
    public void TestSetAndGetId()
    {
        _investor.Id = _id;

        Assert.That(_investor.Id, Is.EqualTo(_id));
    }

    [Test]
    public void TestSetAndGetName()
    {
        _investor.FirstName = FirstName;

        Assert.That(_investor.FirstName, Is.EqualTo(FirstName));
    }
}