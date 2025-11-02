using Google.Cloud.Firestore;

namespace HealthService.Models;

[FirestoreData]
public class Food
{
    // Firestore needs a parameterless constructor
    public Food() { }

    // Optional: a convenience constructor for your own use
    public Food(string name, int calories, DateTime timeEaten)
    {
        Name = name;
        Calories = calories;
        TimeEaten = timeEaten;
    }
    
    [FirestoreProperty]
    public string Name { get; set; }

    [FirestoreProperty]
    public int Calories { get; set; }
    
    [FirestoreProperty]
    public DateTime TimeEaten { get; set; }
}