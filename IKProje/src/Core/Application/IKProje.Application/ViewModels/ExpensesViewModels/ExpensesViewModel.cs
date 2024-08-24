using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.ExpensesViewModels
{
    public class ExpensesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; } = default!;
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;

        public DateTime DateofReply { get; set; }
        public Approval StatusofApproval { get; set; } = Approval.AwaitingApproval;
        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofExpenses TypeofExpenses { get; set; }
        public string Documantation { get; set; }
        public string PersonelId { get; set; }
        public string PersonelName { get; set; }
        public PersonelViewModel PersonelViewModel { get; set; }

        public Domain.Entities.Entity.Personel Personel { get; set; }
        public string CompanyId { get; set; } //++
        public CompanyViewModel CompanyViewModel { get; set; }
    }
}
