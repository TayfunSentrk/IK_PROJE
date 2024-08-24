using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionDelete;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetAll;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetSingle;
using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Areas.Yönetici.Controllers
{

    [Area("Yönetici")]

    [Authorize(Roles = "Yönetici")]
    public class TypeofPermissionController : Controller
    {

        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public TypeofPermissionController(IMediator mediator, IMapper mapper)
        {

            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var a = await mediator.Send(new TypeofPermissionGetAllQuery());
            return View(await mediator.Send(new TypeofPermissionGetAllQuery()));
        }
        public IActionResult TypeofPermissionCreate() {


            var typeofGenderSelectList = Enum.GetValues(typeof(Gender))
                                    .Cast<Gender>()
                                    .Select(e => new SelectListItem
                                    {
                                        Text = e.ToString(),
                                        Value = e.ToString()
                                    })
                                    .ToList();

            ViewBag.Gender = typeofGenderSelectList;
         

            return View(); }
        [HttpPost]
        public async Task<IActionResult> TypeofPermissionCreate(TypeofPermissionCreateCommand request)
        {
            var typeofGenderSelectList = Enum.GetValues(typeof(Gender))
                                   .Cast<Gender>()
                                   .Select(e => new SelectListItem
                                   {
                                       Text = e.ToString(),
                                       Value = e.ToString()
                                   })
                                   .ToList();

            if (!ModelState.IsValid)
            {
               
                ViewBag.Gender = typeofGenderSelectList;
                return View(request);
            }

            var result = await mediator.Send(request);


          

            ViewBag.Gender = typeofGenderSelectList;

           
            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> TypeofPermissionDelete(string Id)
        {
            var result = await mediator.Send(new TypeofPermissionDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction("Index", "TypeofPermission");
        }
        public async Task<IActionResult> TypeofPermissionEdit(string id)
        {

            var typeofGenderSelectList = Enum.GetValues(typeof(Gender))
                                  .Cast<Gender>()
                                  .Select(e => new SelectListItem
                                  {
                                      Text = e.ToString(),
                                      Value = e.ToString()
                                  })
                                  .ToList();

            ViewBag.Gender = typeofGenderSelectList;
            TypeofPermissionViewModel model = await mediator.Send(new TypeofPermissionGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> TypeofPermissionEdit(TypeofPermissionViewModel request)
        {
            if (!ModelState.IsValid) {

                var typeofGenderSelectList = Enum.GetValues(typeof(Gender))
                                 .Cast<Gender>()
                                 .Select(e => new SelectListItem
                                 {
                                     Text = e.ToString(),
                                     Value = e.ToString()
                                 })
                                 .ToList();

                ViewBag.Gender = typeofGenderSelectList;
                return View(request); 
            
            }
            var result = await mediator.Send(mapper.Map<TypeofPermissionEditCommand>(request));


            return RedirectToAction(nameof(Index));
        }
    }
}
