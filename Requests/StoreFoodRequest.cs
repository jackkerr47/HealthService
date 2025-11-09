using System.ComponentModel.DataAnnotations;

namespace HealthService.Requests;

public class StoreFoodRequest : IValidatableObject
{
    [Required, MinLength(1)]
    public string Name { get; init; } = string.Empty;

    [Required]
    public int Calories { get; init; }

    [Required]
    public DateTime TimeEaten { get; init; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (string.IsNullOrWhiteSpace(Name))
            yield return new ValidationResult("Name cannot be empty or whitespace.", [nameof(Name)]);

        if (Calories <= 0)
            yield return new ValidationResult("Calories must be greater than zero.", [nameof(Calories)]);

        if (TimeEaten == default)
            yield return new ValidationResult("TimeEaten must be a valid date.", [nameof(TimeEaten)]);
    }
}