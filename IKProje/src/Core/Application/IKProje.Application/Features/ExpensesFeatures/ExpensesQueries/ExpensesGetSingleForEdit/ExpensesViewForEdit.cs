using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit
{
    public class ExpensesViewForEdit
    {

        public string Id { get; set; }

        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofExpenses TypeofExpenses { get; set; }
        public string Documantation { get; set; }
        //public string PersonelId { get; set; }
    }
}
