using Application.Investors.Queries.GetInvestorList;
using Microsoft.AspNetCore.Mvc;

namespace service.test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {


        private readonly IGetInvestorsListQuery _query;
        public TestController(IGetInvestorsListQuery query)
        {
            _query = query;
        }   

        [HttpGet(Name = "GetTest")]
        public IEnumerable<InvestorsListItemModel> Get()
        {

            return _query.Execute();
        }
    }
}
