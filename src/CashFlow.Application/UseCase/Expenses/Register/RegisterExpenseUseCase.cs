using AutoMapper;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCase.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public RegisterExpenseUseCase(
        IExpensesRepository repository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestRegisterExpenseJson requestRegister)
    {
        Validate(requestRegister);
        
        var entity = _mapper.Map<Expense>(requestRegister);
        
        await _repository.Add(entity);
        await _unitOfWork.Commit();
        
        return _mapper.Map<ResponseRegisteredExpenseJson>(entity);
    }

    private void Validate(RequestRegisterExpenseJson requestRegister)
    {
        var validator = new RegisterExpenseValidator();
        var result = validator.Validate(requestRegister);

        if (result.IsValid == false)
        {
            var errorMessages = 
                result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}