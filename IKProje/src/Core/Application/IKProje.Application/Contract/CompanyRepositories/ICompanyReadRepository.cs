using IKProje.Application.Contract.Common;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Contract.CompanyRepositories
{
    public interface ICompanyReadRepository:IReadRepository<Company>
    {
    }
}
