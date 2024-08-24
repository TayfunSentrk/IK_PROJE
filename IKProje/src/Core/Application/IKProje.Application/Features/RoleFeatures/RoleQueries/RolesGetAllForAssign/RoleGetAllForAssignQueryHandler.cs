using AutoMapper;
using IKProje.Application.ViewModels.Roles;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.RoleFeatures.RoleQueries.RolesGetAllForAssign
{
    public class RoleGetAllForAssignQueryHandler : IRequestHandler<RoleGetAllForAssignQuery, List<AssignRoleToUserViewModel>>
    {
        private readonly UserManager<Personel> userManager;
        private readonly RoleManager<Role> roleManager;
        private readonly IMapper mapper;

        public RoleGetAllForAssignQueryHandler(UserManager<Personel> userManager,RoleManager<Role> roleManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }
        public async Task<List<AssignRoleToUserViewModel>> Handle(RoleGetAllForAssignQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByIdAsync(request.UserId);
            var roles = await roleManager.Roles.ToListAsync();
            var roleViewModelList = new List<AssignRoleToUserViewModel>();
            IList<string> userRoles = await userManager.GetRolesAsync(currentUser!);

            foreach (var role in roles)
            {
                var assignRoleToUser = mapper.Map<AssignRoleToUserViewModel>(role);
                //Kullanıcının rolleri içerisinde iterasyonun içerisindeki rol varsa exist propertisinin trueya çekiyorum var diye
                if (userRoles.Contains(role.Name!))
                {
                    assignRoleToUser.Exist = true;
                }
                //artık rol listesine rolleri yükleyip geri dönüyorum.
                roleViewModelList.Add(assignRoleToUser);

            }
            return roleViewModelList;
        }
    }
}
