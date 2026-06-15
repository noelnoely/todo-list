using BLL.Dtos.TodoList;

namespace BLL.Validation.TodoList;

public class CreateTodoListDtoValidator : IValidator<CreateTodoListDto>
{
    public ValidationResult Validate(CreateTodoListDto dto)
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

        return result;
    }
}