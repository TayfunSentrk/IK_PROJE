using AutoMapper;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingle;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingle;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Areas.Yönetici.Controllers
{

    [Area("Yönetici")]

    [Authorize(Roles ="Yönetici")]
    public class ApprovalController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        public ApprovalController(IMediator mediator, IMapper mapper )
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }

      
        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> PermissionApprovalList()
        {

            var modelList = await mediator.Send(new PermissionGetAllQuery { UserName = User.Identity.Name, IsApproval = true });
            return View(modelList);
        }

        public async Task<IActionResult> PermissionApproval(string id)
        {

            var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                                 .Cast<Approval>()
                                 .Select(e => new SelectListItem
                                 {
                                     Text = e.ToString(),
                                     Value = e.ToString()
                                 })
                                 .ToList();

          

            ViewBag.ApprovalList = typeofApprovalSelectList;

            PermissionViewModel model = await mediator.Send(new PermissionGetSingleQuery { Id = id ,IsApproval=true});
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PermissionApproval(PermissionViewModel request)
        {

            foreach (var key in ModelState.Keys.ToList())
            {
                if (key != "StatusofApproval")
                {
                    ModelState.Remove(key);
                }
            }
            if (!ModelState.IsValid)
            {
                var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                                 .Cast<Approval>()
                                 .Select(e => new SelectListItem
                                 {
                                     Text = e.ToString(),
                                     Value = e.ToString()
                                 })
                                 .ToList();
                ViewBag.ApprovalList = typeofApprovalSelectList;
                return View(request);
            }
            var result = await mediator.Send(mapper.Map<PermissionApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(ApprovalController.PermissionApprovalList));
        }

        public async Task<IActionResult> ExpensesApprovalList()
        {


            var modelList = await mediator.Send(new ExpensesGetAlllQuery { UserName = User.Identity.Name, IsApproval = true });
            return View(modelList);
        }
        public async Task<IActionResult> ExpensesApproval(string id)
        {
            var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                                .Cast<Approval>()
                                .Select(e => new SelectListItem
                                {
                                    Text = e.ToString(),
                                    Value = e.ToString()
                                })
                                .ToList();
            ViewBag.ApprovalList = typeofApprovalSelectList;

            ExpensesViewModel model = await mediator.Send(new ExpensesGetSingleQuery { Id = id,IsApproval=true });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExpensesApproval(ExpensesViewModel request)
        {

            foreach (var key in ModelState.Keys.ToList())
            {
                if (key != "StatusofApproval")
                {
                    ModelState.Remove(key);
                }
            }

            if (!ModelState.IsValid)
            {

                var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                               .Cast<Approval>()
                               .Select(e => new SelectListItem
                               {
                                   Text = e.ToString(),
                                   Value = e.ToString()
                               })
                               .ToList();

                ViewBag.ApprovalList = typeofApprovalSelectList;

                return View(request);

            }
               
            var result = await mediator.Send(mapper.Map<ExpensesApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(ApprovalController.ExpensesApprovalList));
        }

        public async Task<IActionResult> AdvanceApprovalList()
        {

            var modelList = await mediator.Send(new AdvanceGetAllQuery { UserName = User.Identity.Name, IsApproval = true });
            return View(modelList);
        }
        public async Task<IActionResult> AdvanceApproval(string id)
        {

            var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                               .Cast<Approval>()
                               .Select(e => new SelectListItem
                               {
                                   Text = e.ToString(),
                                   Value = e.ToString()
                               })
                               .ToList();
            ViewBag.ApprovalList = typeofApprovalSelectList;
            AdvanceViewModel model = await mediator.Send(new AdvanceGetSingleQuery { Id = id,IsApproval=true });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceApproval(AdvanceViewModel request)
        {

            foreach (var key in ModelState.Keys.ToList())
            {
                if (key != "StatusofApproval")
                {
                    ModelState.Remove(key);
                }
            }
            if (!ModelState.IsValid)
            {
                var typeofApprovalSelectList = Enum.GetValues(typeof(Approval))
                               .Cast<Approval>()
                               .Select(e => new SelectListItem
                               {
                                   Text = e.ToString(),
                                   Value = e.ToString()
                               })
                               .ToList();
                ViewBag.ApprovalList = typeofApprovalSelectList;

                return View(request);
            }
            request.PersonelName = request.Personel.UserName;

            var result = await mediator.Send(mapper.Map<AdvanceApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(ApprovalController.AdvanceApprovalList));
        }
    }
}
