namespace BLL.Validation;

public interface IValidator<T>
{
   ValidationResult Validate(T dto);
}