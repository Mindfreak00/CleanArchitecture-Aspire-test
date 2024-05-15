using Microsoft.AspNetCore.Mvc;

namespace ApiService;

[ApiController]
[Route("api/[controller]")]
public class TestController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}