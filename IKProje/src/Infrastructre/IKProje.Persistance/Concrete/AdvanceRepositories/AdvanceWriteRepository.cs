using IKProje.Application.Contract.AdvanceRepository;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.AdvanceRepositories
{
    public class AdvanceWriteRepository:WriteRepository<Advance>,IAdvanceWriteRepository
    {
        public AdvanceWriteRepository(IKProjeDbContext context):base(context) { }

        public async Task<Tuple<Personel, Advance>> ControlofAdvance(Personel personel, Advance advance)
        {
            if (DateTime.Now > personel.AdvanceRenewalDate || personel.AdvanceRenewalDate == null)//5 aralık 2023--10 tl-- 6 aralık 2024
            {
                personel.NumberofAdvance = 0;
                personel.UsedAdvance = 0;
            }
            //if (personel.NumberofAdvance == 0)
            //{
            //    personel.NumberofAdvance = 1;
            //    personel.AdvanceRenewalDate = DateTime.Now.AddYears(1);//5 aralık 2024
            //}
            // 5 ocak 2024 10 tl
            // 5 şubat 2024 10 tl
            decimal maxAdvance = personel.Salary * 3;
            if (personel.UsedAdvance + advance.TotalAmount <= maxAdvance)
            {

                if (personel.NumberofAdvance == 0)
                {
                    personel.AdvanceRenewalDate = DateTime.Now.AddYears(1);//5 aralık 2024
                }
                // Avans talep edilen miktarı geçmiyorsa işlemi onayla.
                advance.StatusofApproval = Approval.Approved;

                // Kullanılan avans miktarını güncelle.
                personel.UsedAdvance += advance.TotalAmount;
                personel.NumberofAdvance++;

            }
            else
            {
                advance.StatusofApproval = Approval.Denied;
            }
            return new Tuple<Personel,Advance>(personel, advance);
        }
    }
}
