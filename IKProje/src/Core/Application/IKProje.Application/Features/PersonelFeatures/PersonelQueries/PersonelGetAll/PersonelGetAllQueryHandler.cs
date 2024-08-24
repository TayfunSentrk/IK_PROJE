using AutoMapper;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetAll
{
    public class PersonelGetAllQueryHandler : IRequestHandler<PersonelGetAllQuery, List<PersonelViewModel>>
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public PersonelGetAllQueryHandler(UserManager<Personel> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<List<PersonelViewModel>> Handle(PersonelGetAllQuery request, CancellationToken cancellationToken)
        {

            if (request.CompanyId!=null)
            {
                List<Personel> userListWithCompany = await userManager.Users.Where(x => x.CompanyId == request.CompanyId).ToListAsync();
                return mapper.Map<List<PersonelViewModel>>(userListWithCompany);
            }


            if (request.UserName!=null)
            {
                var currentUser = await userManager.FindByNameAsync(request.UserName);

                if (currentUser != null)
                {
                    List<Personel> userListWithCompany = await userManager.Users.Where(x => x.CompanyId == currentUser.CompanyId).ToListAsync();
                    return mapper.Map<List<PersonelViewModel>>(userListWithCompany);
                }

            }

         
          
            List<Personel> userList = await userManager.Users.ToListAsync();
           
            return mapper.Map<List<PersonelViewModel>>(userList);
        }
    }
}
