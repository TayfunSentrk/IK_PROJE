using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingleForEdit
{
    public class AdvanceViewForEdit
    {

        public string Id { get; set; }

        public decimal TotalAmount { get; set; }
        public Currency Currency { get; set; }
        public TypeofAdvance TypeofAdvance { get; set; }
        public string Description { get; set; }
    }
}
