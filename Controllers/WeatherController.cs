using Google.Cloud.Firestore;
using HealthService.Models;
using HealthService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HealthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly FirestoreDb _db = FirestoreDb.Create("jackkerr47-project-local");
        
    [HttpPost]
    public async Task<IActionResult> StoreFood([FromBody] StoreFoodRequest request)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
            
        var food = new Food(request.Name, request.Calories ?? 0, request.TimeEaten ?? DateTime.Now);
            
        try
        {
            var docRef = await _db.Collection("food").AddAsync(food);
            return Ok(new { id = docRef.Id });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}