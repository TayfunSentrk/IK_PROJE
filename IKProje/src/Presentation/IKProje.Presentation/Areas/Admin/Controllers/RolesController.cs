using AutoMapper;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleAssign;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleCreate;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleEdit;
using IKProje.Application.Features.RoleFeatures.RoleCommands.RoleRemove;
using IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetAll;
using IKProje.Application.Features.RoleFeatures.RoleQueries.RoleGetForEdit;
using IKProje.Application.Features.RoleFeatures.RoleQueries.RolesGetAllForAssign;
using IKProje.Application.ViewModels.Roles;
using IKProje.Presentation.Controllers;
using IKProje.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace IKProje.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles = "Admin")]
    public class RolesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public RolesController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            RoleGetAllQuery query = new RoleGetAllQuery();

            return View(await mediator.Send(query));
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleCreateCommand request)
        {
            if (!ModelState.IsValid) { return View(request); }
            IdentityResult result = await mediator.Send(request);
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
                return View();
            }
            TempData["Message"] = "Ekleme işlemi başarıyla Tamamlanmıştır.";
            return RedirectToAction(nameof(RolesController.Index));
        }


        public async Task<IActionResult> RoleEdit(string id)
        {
            RoleGetForEditQuery query = new RoleGetForEditQuery() { Id = id };
            UpdateRoleViewModel result = await mediator.Send(query);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(UpdateRoleViewModel request)
        {
            if (!ModelState.IsValid) { return View(request); }
            var roleEdit = mapper.Map<RoleEditCommand>(request);
            IdentityResult? result = await mediator.Send(roleEdit);
            if (!result.Succeeded)
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
            TempData["Message"] = "Güncelleme işlemi başarıyla Tamamlanmıştır.";
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RoleRemove(string id)
        {
            RoleRemoveCommand roleRemove = new() { Id = id };
            var result = await mediator.Send(roleRemove);
            if (!result.Succeeded)
            {
                ModelState.AddModelErrorList(result.Errors.Select(x => x.Description).ToList());
                return View();
            }
            TempData["Message"] = "Silme işlemi başarıyla Tamamlanmıştır.";
            return RedirectToAction(nameof(RolesController.Index));
        }
        public async Task<IActionResult> RoleAssignToPersonel(string id)
        {
            ViewBag.Id = id;
            RoleGetAllForAssignQuery request = new RoleGetAllForAssignQuery() { UserId = id };
            List<AssignRoleToUserViewModel> roles = await mediator.Send(request);
            return View(roles);
        }
        [HttpPost]
        public async Task<IActionResult> RoleAssignToPersonel(List<AssignRoleToUserViewModel> request, string id)
        {
            RoleAssignCommand roleAssign = new RoleAssignCommand { UserId = id ,Roles=request};
            await mediator.Send(roleAssign);


            return RedirectToAction("Userlist", "Home");

        }
    }
}
