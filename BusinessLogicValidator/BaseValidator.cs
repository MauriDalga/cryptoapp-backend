using BusinessLogicValidatorInterface;
using FluentValidation;
using FluentValidation.Results;

namespace BusinessLogicValidator;
public class BaseValidator<TEntity> : AbstractValidator<TEntity>, IBusinessValidator<TEntity> where TEntity : class
{
    public void CreationValidation(TEntity entity)
    {
        Validate(entity);

        IncludeValidation(entity);

        BusinessValidation(entity);
    }

    private new void Validate(TEntity entity)
    {
        base.EnsureInstanceNotNull(entity);

        var result = base.Validate(entity);
        var errorFormatted = BaseValidator<TEntity>.FormatErrors(result.Errors);

        if (!result.IsValid) throw new ArgumentException(errorFormatted);
    }

    private static string FormatErrors(IEnumerable<ValidationFailure> errors)
    {
        var errorFormatted = "";

        foreach (var error in errors)
        {
            if (string.IsNullOrEmpty(errorFormatted))
            {
                errorFormatted = error.ErrorMessage;
            }
            else
            {
                errorFormatted = $"{errorFormatted} \n {error.ErrorMessage}";
            }
        }

        return errorFormatted;
    }

    protected virtual void BusinessValidation(TEntity entity) { }

    protected virtual void IncludeValidation(TEntity entity) { }

    public void ValidateIdentifier(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentException("ID can't be less or equal to 0.");
        }

        BusinesIdentifierValidation(id);
    }

    protected virtual void BusinesIdentifierValidation(int id) { }

    public void EditionValidation(int id, TEntity entity)
    {
        Validate(entity);

        IncludeValidation(entity);

        BusinessEditionValidation(id, entity);
    }

    protected virtual void BusinessEditionValidation(int id, TEntity entity) { }

    public void LogInValidation(TEntity entity)
    {
        Validate(entity);

        IncludeValidation(entity);
    }

    public void ValidateEmailPassword(string email, string password)
    {
        BusinessLogInValidation(email, password);
    }

    protected virtual void BusinessLogInValidation(string email, string password) { }
}