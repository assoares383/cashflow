using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Response;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase
{
    public ResponseExpenseJson Execute(RequestExpenseJson request)
    {
        Validate(request);
        return new ResponseExpenseJson();
    }

    private void Validate(RequestExpenseJson request)
    {
        var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
        var result = DateTime.Compare(request.Date, DateTime.UtcNow);
        var paymentTypeIsValid= Enum.IsDefined(typeof(PaymentType), request.PaymentType);

        if (titleIsEmpty)
        {
            throw new ArgumentException("The title is required.");
        }

        if (request.Amount <= 0)
        {
            throw new ArgumentException("The amount must be greater than zero.");
        }

        if (result > 0)
        {
            throw new ArgumentException("Expenses cannot be for the future");
        }

        if (paymentTypeIsValid == false)
        {
            throw new ArgumentException("Payment Type is not valid.");
        }
    }
}