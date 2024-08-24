using AutoMapper;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetByName
{
    public class PersonelGetByNameQueryHandler : IRequestHandler<PersonelGetByNameQuery, PersonelInformationViewModel>
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public PersonelGetByNameQueryHandler(UserManager<Personel> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<PersonelInformationViewModel> Handle(PersonelGetByNameQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByNameAsync(request.UserName);
            var persoenelInformation=mapper.Map<PersonelInformationViewModel>(currentUser);
            return persoenelInformation;

        }
    }
}
