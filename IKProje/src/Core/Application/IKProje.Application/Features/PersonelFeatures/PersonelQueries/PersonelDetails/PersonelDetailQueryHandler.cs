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

namespace IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelDetails
{
    public class PersonelDetailQueryHandler : IRequestHandler<PersonelDetailQuery, PersonelDetailViewModel>
    {
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public PersonelDetailQueryHandler(UserManager<Personel> userManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }
        public async Task<PersonelDetailViewModel> Handle(PersonelDetailQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await userManager.FindByNameAsync(request.UserName);

            var personelDetail = mapper.Map<PersonelDetailViewModel>(currentUser);
            return personelDetail;
        }
    }
}
