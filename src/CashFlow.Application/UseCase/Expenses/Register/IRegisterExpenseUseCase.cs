using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCase.Expenses.Register;

public interface IRegisterExpenseUseCase
{
    ResponseExpenseJson Execute(RequestExpenseJson request);
}