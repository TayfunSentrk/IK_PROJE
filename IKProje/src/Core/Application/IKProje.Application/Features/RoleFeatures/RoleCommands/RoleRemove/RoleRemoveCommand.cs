using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleRemove
{
    public class RoleRemoveCommand : IRequest<IdentityResult>
    {
        public string Id { get; set; }
    }

}
