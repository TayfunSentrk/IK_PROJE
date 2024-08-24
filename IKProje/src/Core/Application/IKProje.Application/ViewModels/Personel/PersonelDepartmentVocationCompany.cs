using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels.Personel
{
    public class PersonelDepartmentVocationCompany
    {
        public PersonelCreateCommand personelCreateCommand { get; set; }

        public  IEnumerable<CompanyViewModel> companyViewModel { get; set; }
        public IEnumerable<DepartmentViewModel> departmentViewModels { get; set; }

        public IEnumerable<VocationViewModel> vocationViewModels { get; set; }


    }
}
