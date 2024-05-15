using Moq;
using NUnit.Framework;

namespace Persistence.Shared;

[TestFixture]
public class UnitOfWorkTests
{
    private UnitOfWork _unitOfWork;
    private Mock<IDatabaseContext> _mockContext;

    [SetUp]
    public void SetUp()
    {
        _mockContext = new Mock<IDatabaseContext>();
        _unitOfWork = new UnitOfWork(_mockContext.Object);
    }

    [Test]
    public void TestSaveShouldSaveUnitOfWork()
    {
        _unitOfWork.Save();
    }
}