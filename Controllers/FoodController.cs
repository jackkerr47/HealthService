using Google.Api.Gax;
using Google.Cloud.Firestore;
using HealthService.Models;
using HealthService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace HealthService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FoodController : ControllerBase
{
    private readonly FirestoreDb _db;

    public FoodController()
    {
        _db = new FirestoreDbBuilder
        {
            ProjectId = "jackkerr47-project",
            EmulatorDetection = EmulatorDetection.EmulatorOrProduction
        }.Build();
    }
        
    [HttpPost]
    public async Task<IActionResult> StoreFood([FromBody] StoreFoodRequest request)
    {
        var food = new Food(request.Name, request.Calories, request.TimeEaten);
        
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
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetFood(string id)
    {
        try
        {
            DocumentReference docRef = _db.Collection("food").Document(id);
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (!snapshot.Exists) return NotFound();
            
            var food = snapshot.ConvertTo<Food>();
            return Ok(food);

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
    
    [HttpGet]
    public async Task<IActionResult> GetFood()
    {
        try
        {
            QuerySnapshot snapshot = await _db.Collection("food").GetSnapshotAsync();

            var foods = new List<Food>();

            foreach (DocumentSnapshot doc in snapshot.Documents)
            {
                if (doc.Exists)
                {
                    var food = doc.ConvertTo<Food>();
                    foods.Add(food);
                }
            }

            return Ok(foods);

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { error = ex.Message });
        }
    }
}