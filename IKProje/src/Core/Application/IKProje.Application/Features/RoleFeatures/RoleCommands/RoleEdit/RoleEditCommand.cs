﻿using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleCommands.RoleEdit
{
    public class RoleEditCommand:IRequest<IdentityResult>
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
