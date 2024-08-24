using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.ViewModels
{
    public class DepartmentViewModel
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public bool IsActive { get; set; }
    }
}
