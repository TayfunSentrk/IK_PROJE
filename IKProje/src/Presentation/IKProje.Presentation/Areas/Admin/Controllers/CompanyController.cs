using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentCreate;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentDelete;
using IKProje.Application.Features.DepartmentFeatures.DeparmentCommands.DepartmentEdit;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle;
using IKProje.Application.ViewModels;
using IKProje.Domain.Entities.Entity;
using IKProje.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace IKProje.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]
    public class CompanyController : Controller
    {
       
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IFileProvider fileProvider;

        public CompanyController( IMediator mediator, IMapper mapper,IFileProvider fileProvider)
        {
            
            this.mediator = mediator;
            this.mapper = mapper;
            this.fileProvider = fileProvider;
        }
        public async Task<IActionResult> Index()
        {
          
            return View(await mediator.Send(new CompanyGetAllQuery()));
        }
        public IActionResult CompanyCreate() { return View(); }
        [HttpPost]
        public async Task<IActionResult> CompanyCreate(CompanyCreateCommand request)
        {
            if (!ModelState.IsValid) 
            
            { 
                return View(request);
            }
          

            if (request.Picture != null && request.Picture.Length > 0)
            {
                var data = request.LogoPath.AddPicturePath(request.Picture, fileProvider);
                request.LogoPath = data;
            }
            var result = await mediator.Send(request);

            if(result.Success == true)
            {
                TempData["Success"] = result.Message;
            }
            else
            {
                TempData["Error"] = result.Message;

            }


            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> CompanyDelete(string Id)
        {
            var result = await mediator.Send(new CompanyDeleteCommand { Id = Id });
            if (result.Success == true)
            {
                TempData["Success"] = result.Message;
            }
            else
            {
                TempData["Error"] = result.Message;

            }
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> CompanyEdit(string id)
        {
            CompanyViewModel model = await mediator.Send(new CompanyGetByIdQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CompanyEdit(CompanyViewModel request)
        {
            var a = request.Picture;
            if (!ModelState.IsValid) { 
                return View(request);
            }
            if (request.Picture != null && request.Picture.Length > 0)
            {
                var data = request.LogoPath.AddPicturePath(request.Picture, fileProvider);
                request.LogoPath = data;
            }
            var result = await mediator.Send(mapper.Map<CompanyEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

    }
}
