using AutoMapper;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesDelete;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingle;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionApproval;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionCreate;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionDelete;
using IKProje.Application.Features.PermissionFeatures.PermissionCommands.PermissionEdit;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingle;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetAll;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetSingle;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Application.ViewModels.PermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Controllers
{
    [Authorize]
    public class PermissionController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public PermissionController(IMediator mediator, IMapper mapper)
        {

            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
          
            return View(await mediator.Send(new PermissionGetAllQuery()
            {
                UserName = User.Identity.Name
            }));
        }
        public async Task<IActionResult> PermissionCreate() {

            //var typeofAdvanceSelectList = Enum.GetValues(typeof(TypeofAdvance))
            //                         .Cast<TypeofAdvance>()
            //                         .Select(e => new SelectListItem
            //                         {
            //                             Text = e.ToString(),
            //                             Value = e.ToString()
            //                         })
            //                         .ToList();



            var typeofPermissionSelectList = await mediator.Send(new TypeofPermissionGetAllQuery() { UserName=User.Identity.Name,Tracking=false});



            ViewBag.TypeofPermision = typeofPermissionSelectList.Select(e => new SelectListItem
            {
                Text = e.Name, // 'Name' TypeofPermissionViewModel'deki ilgili alan
                Value = e.Id.ToString() // 'Id' TypeofPermissionViewModel'deki ilgili alan
            }).ToList();




            return View();
        
        
        }
        [HttpPost]
        public async Task<IActionResult> PermissionCreate(PermissionCreateCommand request)
        {
            request.UserName = User.Identity.Name;
            if (!ModelState.IsValid)
            {
                var typeofPermissionSelectList = await mediator.Send(new TypeofPermissionGetAllQuery() { UserName = User.Identity.Name ,Tracking=false});



                ViewBag.TypeofPermision = typeofPermissionSelectList.Select(e => new SelectListItem
                {
                    Text = e.Name, // 'Name' TypeofPermissionViewModel'deki ilgili alan
                    Value = e.Id.ToString() // 'Id' TypeofPermissionViewModel'deki ilgili alan
                }).ToList();


                return View(request);
            }
            
            var result = await mediator.Send(request);



            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> PermissionDelete(string Id)
        {
            var result = await mediator.Send(new PermissionDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction("Index", "Permission");
        }
        public async Task<IActionResult> PermissionEdit(string id)
        {
            var model = await mediator.Send(new PermissonGetSingleForEditCommand { Id = id ,IsTracking=false});
            var typeofPermissionSelectList = await mediator.Send(new TypeofPermissionGetAllQuery() { UserName=User.Identity.Name});



            ViewBag.TypeofPermision = typeofPermissionSelectList.Select(e => new SelectListItem
            {
                Text = e.Name, // 'Name' TypeofPermissionViewModel'deki ilgili alan
                Value = e.Id.ToString() // 'Id' TypeofPermissionViewModel'deki ilgili alan
            }).ToList();
            

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PermissionEdit(PermissonViewForEdit request)
        {
            if (!ModelState.IsValid)
            {
                var typeofPermissionSelectList = await mediator.Send(new TypeofPermissionGetAllQuery() { UserName = User.Identity.Name }); 
                ViewBag.TypeofPermision = typeofPermissionSelectList.Select(e => new SelectListItem
                {
                    Text = e.Name, // 'Name' TypeofPermissionViewModel'deki ilgili alan
                    Value = e.Id.ToString() // 'Id' TypeofPermissionViewModel'deki ilgili alan
                }).ToList();
                return View(request);
            }
            var result = await mediator.Send(mapper.Map<PermissionEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
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

            TempData["ApprovalList"] = typeofApprovalSelectList;

            PermissionViewModel model = await mediator.Send(new PermissionGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> PermissionApproval(PermissionViewModel request)
        {
            if (!ModelState.IsValid)
            {
                
                return View(request);
            }
            var result = await mediator.Send(mapper.Map<PermissionApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return View(result.Response);
        }


            public async Task<IActionResult> GetPermissionDays(string permissionId)
            {

                var model = await mediator.Send(new TypeofPermissionGetSingleQuery { Id = permissionId });
                int days = model.Duration;

                return Json(days);
            }
    }
}
