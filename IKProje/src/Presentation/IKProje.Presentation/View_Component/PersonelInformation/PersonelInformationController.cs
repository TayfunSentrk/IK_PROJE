using AutoMapper;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetByName;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKProje.Presentation.View_Component.PersonelInformation
{
    public class PersonelInformationController:ViewComponent
    {


        private readonly IMediator _mediator;
        private readonly UserManager<Personel> userManager;
        private readonly IMapper mapper;

        public PersonelInformationController(IMediator mediator,UserManager<Personel> userManager,IMapper mapper)
        {
            _mediator = mediator;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersonelGetByNameQuery personelGetByName = new PersonelGetByNameQuery
            {
                UserName = User.Identity!.Name!
            };
            var result = await _mediator.Send(personelGetByName);

            return View(result);
        }
    }
    
}
