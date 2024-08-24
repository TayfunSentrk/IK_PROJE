﻿using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit
{
    public class PermissionEditCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public PermissionEditCommand Response { get; set; }
    }
}
