using AutoMapper;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelEdit;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Mapping.PersonelMapping
{
    public class PersonelMap : Profile
    {
        public PersonelMap()
        {
            CreateMap<PersonelInformationViewModel, Personel>().ReverseMap();
            CreateMap<PersonelInformationForEdit, PersonelEditCommand>().ReverseMap();
            CreateMap<PersonelEditCommand, Personel>().ReverseMap();
            CreateMap<PersonelCreateCommand, Personel>().ReverseMap();
                CreateMap<PersonelPasswordChangeCommand, Personel>().ReverseMap();
            CreateMap<PersonelViewModel, Personel>().ReverseMap();
            CreateMap<Personel, PersonelInformationForEdit>().ReverseMap();
            CreateMap<Personel, PersonelDetailViewModel>().ReverseMap();

       


        }
    }
}
