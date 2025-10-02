using CashFlow.Application.UseCase.Expenses.Register;

namespace CashFlow.Application;
using Microsoft.Extensions.DependencyInjection;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
    }
}