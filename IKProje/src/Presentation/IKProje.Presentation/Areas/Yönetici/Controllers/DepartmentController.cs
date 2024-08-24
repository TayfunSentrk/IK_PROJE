using AutoMapper;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentDelete;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle;
using IKProje.Application.ViewModels;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IKProje.Presentation.Areas.Yönetici.Controllers
{
    [Area("Yönetici")]

    [Authorize(Roles = "Yönetici")]
    public class DepartmentController : Controller
    {

        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public DepartmentController(IMediator mediator, IMapper mapper)
        {

            this.mediator = mediator;
            this.mapper= mapper;
        }
        public async Task<IActionResult> Index()
        {
           
            return View(await mediator.Send(new DepartmentGetAllQuery()));
        }
        public IActionResult DepartmentCreate() { return View(); }
        [HttpPost]
        public async Task<IActionResult> DepartmentCreate(DepartmentCreateCommand request)
        {
            request.UserName = User.Identity!.Name!;
            if (!ModelState.IsValid) { return View(request); }
            
            var result = await mediator.Send(request);

            TempData["Message"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> DepartmentDelete(string Id)
        {
            var result = await mediator.Send(new DepartmentDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction("Index", "Department");
        }
        public async Task<IActionResult> DepartmentEdit(string id)
        {
            DepartmentViewModel model = await mediator.Send(new DepartmentGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DepartmentEdit(DepartmentViewModel request)
        {
            if (!ModelState.IsValid) {  return View(request); }    
            var result = await mediator.Send(mapper.Map<DepartmentEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }


    }
}
