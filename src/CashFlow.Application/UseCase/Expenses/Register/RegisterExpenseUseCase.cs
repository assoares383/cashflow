using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseExpenseJson Execute(RequestExpenseJson request)
    {
        return new ResponseExpenseJson();
    }
}