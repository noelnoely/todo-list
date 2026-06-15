using BLL.Dtos.Todo;

namespace BLL.Validation.Todo;

public class UpdateTodoDtoValidator : IValidator<UpdateTodoDto>
{
    public ValidationResult Validate(UpdateTodoDto dto)
    {
        var result = new ValidationResult();
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            result.AddError("Name is required.");
        }

        if (!string.IsNullOrWhiteSpace(dto.Name) && dto.Name.Trim()
                .Length > 50)
        {
            result.AddError("Name must not exceed 50 characters.");
        }

        if (!string.IsNullOrWhiteSpace(dto.Description) && dto.Description.Trim()
                .Length > 120)
        {
            result.AddError("Description must not exceed 120 characters.");
        }

        return result;
    }
}