using HealthService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HealthService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        [HttpPost]
        public IActionResult StoreFood([FromBody] StoreFoodRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Console.WriteLine(request.Name);
            Console.WriteLine(request.Calories);
            Console.WriteLine(request.TimeEaten);

            return Ok();
        }
    }
}
