namespace Application.Investors.Queries.GetInvestorList;

public interface IGetInvestorsListQuery
{
    List<InvestorsListItemModel> Execute();
}