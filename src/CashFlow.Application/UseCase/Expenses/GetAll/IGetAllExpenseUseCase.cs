using CashFlow.Application.UseCase.Expenses.GetAll;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public interface IGetAllExpenseUseCase
{
    Task<ResponseExpensesJson> Execute(long id);
}