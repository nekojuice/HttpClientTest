using HttpClientTest.Domain.Entity;
using HttpClientTest.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CatPostTestController : ControllerBase
    {
        private readonly ICatPostTestService _service;
        public CatPostTestController(ICatPostTestService service) 
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IResult> PostTest([FromBody] LoginDTO request) 
        {
            var result = await _service.PostTest(request);
            return Results.Ok();
        }

        [HttpPost]
        public async Task<IResult> PostTestWithAuth([FromBody] LoginDTO request)
        {
            var result = await _service.PostTest(request);
            return Results.Ok();
        }
    }
}
