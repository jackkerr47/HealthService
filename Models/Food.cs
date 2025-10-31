namespace HealthService.Models;

public class Food(string name, int calories, DateTime timeEaten)
{
    public string Name { get; set; } = name;

    public int Calories { get; set; } = calories;
    
    public DateTime TimeEaten { get; set; } = timeEaten;
}