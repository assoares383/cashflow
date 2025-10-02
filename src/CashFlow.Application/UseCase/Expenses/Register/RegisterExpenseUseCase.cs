using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    public RegisterExpenseUseCase(IExpensesRepository repository)
    {
        _repository = repository;
    }
    public ResponseExpenseJson Execute(RequestExpenseJson request)
    {
        Validate(request);
        
        var entity = new Expense
        {
            Amount = request.Amount,
            Date = request.Date,
            Description = request.Description,
            PaymentType = (PaymentType)request.PaymentType,
            Title = request.Title
        };
        
        _repository.Add(entity);
        
        return new ResponseExpenseJson();
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(request);

        if (result.IsValid == false)
        {
            var errorMessages = 
                result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}