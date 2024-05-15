using Domain.Investors;
using Moq;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared;

[TestFixture]
public class RepositoryTests
{
    private Mock<IDatabaseContext> _mockContext;
    private Mock<DbSet<Investor>> _mockSet;
    private Repository<Investor> _repository;
    private IQueryable<Investor> _data;

    [SetUp]
    public void SetUp()
    {
        // Initialize the mock set
        _mockSet = new Mock<DbSet<Investor>>();

        // Example data
        _data = new List<Investor>
        {
            new Investor { Id = Guid.NewGuid() }, // Assuming T has an Id property of type Guid
            new Investor { Id = Guid.NewGuid() }
        }.AsQueryable();

        // Setup the mock set
        _mockSet.As<IQueryable<Investor>>().Setup(m => m.Provider).Returns(_data.Provider);
        _mockSet.As<IQueryable<Investor>>().Setup(m => m.Expression).Returns(_data.Expression);
        _mockSet.As<IQueryable<Investor>>().Setup(m => m.ElementType).Returns(_data.ElementType);
        _mockSet.As<IQueryable<Investor>>().Setup(m => m.GetEnumerator()).Returns(_data.GetEnumerator());

        // Initialize the mock context
        _mockContext = new Mock<IDatabaseContext>();
        //_mockContext.Setup(c => c.Set<Investor>()).Returns(_mockSet.Object);

        // Create an instance of the repository
        _repository = new Repository<Investor>(_mockContext.Object);
    }

    [Test]
    public void TestGetAllShouldReturnAllEntities()
    {
        var result = _repository.GetAll();
        
        Assert.IsTrue(result.Count() == _data.Count(), "Expected number of items not returned.");
    }

    [Test]
    public void TestGetShouldReturnEntityById()
    {
        var id = _data.First().Id; // Assuming T has an Id that is a Guid
        _mockSet.Setup(x => x.Find(id)).Returns(_data.FirstOrDefault(t => t.Id == id));

        var result = _repository.Get(id);

        Assert.That(result, Is.Not.Null, "Item should not be null.");
        Assert.That(id, Is.EqualTo(result.Id), "Item returned does not match the requested item.");
    }

    [Test]
    public void TestAddShouldAddEntity()
    {
        var newItem = new Investor { Id = Guid.NewGuid() }; // Create a new item
        _repository.Add(newItem);

        //Assert.That(_data, Contains.Item(newItem));
        _mockSet.Verify(s => s.Add(It.Is<Investor>(entity => entity == newItem)), Times.Once(), "Item was not added as expected.");
    }
}