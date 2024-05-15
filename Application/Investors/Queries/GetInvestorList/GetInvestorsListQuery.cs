using Application.Interfaces;
using Application.Interfaces.Persistence;

namespace Application.Investors.Queries.GetInvestorList;

//public class GetInvestorListQuery : IGetInvestorsListQuery
//{
//    private readonly IInvestorRepository _repository;

//    public GetInvestorListQuery(IInvestorRepository repository)
//    {
//        _repository = repository;
//    }

//    public List<InvestorsListItemModel> Execute()
//    {
//        var investors = _repository.GetAll()
//            .Select(_ => new InvestorsListItemModel
//            {
//                Id = _.Id,
//                FirstName = _.FirstName,
//                CreationDate = _.CreationDate,
//                LastEditDate = _.LastEditDate,
//                Status = _.Status
//            });
//        return investors.ToList();
//    }
//}

public class GetInvestorsListQuery
    : IGetInvestorsListQuery
{
    private readonly IDatabaseService _database;

    public GetInvestorsListQuery(IDatabaseService database)
    {
        _database = database;
    }

    public List<InvestorsListItemModel> Execute()
    {
        var sales = _database.Investors
            .Select(p => new InvestorsListItemModel()
            {
                Id = p.Id
            });

        return sales.ToList();
    }
}