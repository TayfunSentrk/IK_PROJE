using AutoMapper;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetByName;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetForEdit
{
    public class PersonelGetForEditQueryHandler : IRequestHandler<PersonelGetForEditQuery, PersonelInformationForEdit>
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public PersonelGetForEditQueryHandler(UserManager<Personel> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<PersonelInformationForEdit> Handle(PersonelGetForEditQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByNameAsync(request.UserName);
            var persoenelInformation = mapper.Map<PersonelInformationForEdit>(currentUser);
            return persoenelInformation;

        }
    }
}
