using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyCreate;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyDelete;
using IKProje.Application.Features.CompanyFeatures.CompanyCommands.CompanyEdit;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationCrreate;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationDelete;
using IKProje.Application.Features.VocationFeatures.VocationCommands.VocationEdit;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle;
using IKProje.Application.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IKProje.Presentation.Areas.Yönetici.Controllers
{

    [Area("Yönetici")]

    [Authorize(Roles = "Yönetici")]
    public class VocationController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public VocationController(IMediator mediator, IMapper mapper)
        {

            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
          
            return View(await mediator.Send(new VocationGetAllQuery()));
        }
        public IActionResult VocationCreate() { return View(); }
        [HttpPost]
        public async Task<IActionResult> VocationCreate(VocationCreateCommand request)
        {

            var result = await mediator.Send(request);

            TempData["Message"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> VocationDelete(string Id)
        {
            var result = await mediator.Send(new VocationDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction("Index", "Vocation");
        }
        public async Task<IActionResult> VocationEdit(string id)
        {
            VocationViewModel model = await mediator.Send(new VocationGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> VocationEdit(VocationViewModel request)
        {

            var result = await mediator.Send(mapper.Map<VocationEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
    }
}
