namespace BusinessLogicValidatorInterface;
public interface IBusinessValidator<TEntity> where TEntity : class
{
    void CreationValidation(TEntity entity);
    void EditionValidation(int id, TEntity entity);
    void ValidateIdentifier(int id);
}
