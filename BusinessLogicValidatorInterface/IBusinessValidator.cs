namespace BusinessLogicValidatorInterface;

public interface IBusinessValidator<in TEntity> where TEntity : class
{
    void CreationValidation(TEntity entity);
    void EditionValidation(int id, TEntity entity);
    void LogInValidation(TEntity entity);
    void ValidateIdentifier(int id);
    void ValidateEmailPassword(string email, string password);
    void ValidateWalletAddress(string walletAddress);
}