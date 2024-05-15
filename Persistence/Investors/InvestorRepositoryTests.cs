using Moq;
using NUnit.Framework;
using Persistence.Shared;

namespace Persistence.Investors;

[TestFixture]
public class InvestorRepositoryTests
{
    [Test]
    public void TestConstructorShouldCreateRepository()
    {
        var context = new Mock<IDatabaseContext>();
        var repository = new InvestorRepository(context.Object);
        Assert.That(repository, Is.Not.Null);
    }
}