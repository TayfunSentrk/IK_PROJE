using IKProje.Application.Contract.TypeofPermissionRepository;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.TypeofPermissionRepositories
{
    public class TypeofPermissionReadRepository:ReadRepository<TypeofPermission>,ITypeofPermissionReadRepository
    {
        public TypeofPermissionReadRepository(IKProjeDbContext context):base(context) { }
       
    }
}
