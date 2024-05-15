namespace Persistence.Shared;

public class UnitOfWork
{
    private readonly IDatabaseContext _database;

    public UnitOfWork(IDatabaseContext database)
    {
        _database = database;
    }

    public void Save()
    {
        _database.Save();
    }
}