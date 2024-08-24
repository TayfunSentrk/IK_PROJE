using AutoMapper;
using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Application.Contract.ExpensesRepository;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate
{
    public class ExpensesCreateCommandHandler : IRequestHandler<ExpensesCreateCommand, ExpensesCreateCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly IExpensesWriteRepository expensesWriteRepository;
        private readonly UserManager<Personel> userManager;

        public ExpensesCreateCommandHandler(IMapper mapper, IExpensesWriteRepository expensesWriteRepository, UserManager<Personel> userManager)
        {
            this.mapper = mapper;
            this.expensesWriteRepository = expensesWriteRepository;
            this.userManager = userManager;
        }
        public async Task<ExpensesCreateCommandResponse> Handle(ExpensesCreateCommand request, CancellationToken cancellationToken)
        {
            Personel? personel = await userManager.FindByNameAsync(request.UserName!);
            var expenses = mapper.Map<Expenses>(request);
            expenses.PersonelId = personel.Id;
            expenses.Personel = personel;
            expenses.Company = personel.Company;
            expenses.Name = request.TypeofExpenses.ToString();
            expenses.CompanyId = personel.CompanyId;
            bool success = await expensesWriteRepository.AddAsync(expenses, cancellationToken);
            await expensesWriteRepository.SaveAsync(cancellationToken);

            ExpensesCreateCommandResponse responce = new ExpensesCreateCommandResponse
            {
                Response = request,
                Success = success,
                Message = success ? "İşlem Başarılı" : "İşlem Başarısız"
            };
            return responce;
        }
    }
}
