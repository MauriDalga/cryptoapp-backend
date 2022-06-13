
using BusinessLogicValidator.Entities;
using BusinessLogicValidator.Model;
using BusinessLogicValidatorInterface;
using Domain;
using Microsoft.Extensions.DependencyInjection;
using Model.Write;

namespace Factory;
internal static class ValidatorFactory
{
    public static void InjectValidators(this IServiceCollection services)
    {
        services.AddTransient<IBusinessValidator<UserModel>, UserModelValidator>();
        services.AddTransient<IBusinessValidator<UserEditModel>, UserEditModelValidator>();
        services.AddTransient<IBusinessValidator<SessionModel>, SessionModelValidator>();
        services.AddTransient<IBusinessValidator<TransactionModel>, TransactionModelValidator>();
        services.AddTransient<IBusinessValidator<User>, UserValidator>();
        services.AddTransient<IBusinessValidator<Transaction>, TransactionValidator>();
    }
}