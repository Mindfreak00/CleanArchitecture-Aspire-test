using Application.Interfaces.Persistence;
using Domain.Investors;
using Persistence.Shared;

namespace Persistence.Investors;

public class InvestorRepository
    : Repository<Investor>,
        IInvestorRepository
{
    public InvestorRepository(IDatabaseContext database)
        : base(database)
    {
        
    }
}