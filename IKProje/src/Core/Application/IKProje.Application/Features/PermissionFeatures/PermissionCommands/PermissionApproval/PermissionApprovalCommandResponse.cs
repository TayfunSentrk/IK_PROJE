using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval
{
    public class PermissionApprovalCommandResponse
    {
        public bool? Success { get; set; }
        public string? Message { get; set; }
        public PermissionViewModel? Response { get; set; }
    }
}
