using IKProje.Application.Contract.PermissionRepository;
using IKProje.Domain.Entities.Entity;
using IKProje.Persistance.Concrete.Common;
using IKProje.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Persistance.Concrete.PermissionRepositories
{
    public class PermissionWriteRepository:WriteRepository<Permission>,IPermissionWriteRepository
    {
        public PermissionWriteRepository(IKProjeDbContext context) : base(context) { }
       
    }
}
