using AutoMapper;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesApproval;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesCreate;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesDelete;
using IKProje.Application.Features.ExpensesFeatures.ExpensesCommands.ExpensesEdit;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingle;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetSingleForEdit;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetAll;
using IKProje.Application.Features.PermissionFeatures.PermissionQueries.PermissionGetSingleForEdit;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.ExpensesViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Controllers
{

    [Authorize]
    public class ExpensesController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public ExpensesController(IMediator mediator, IMapper mapper)
        {

            this.mediator = mediator;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            return View(await mediator.Send(new ExpensesGetAlllQuery() { UserName= User.Identity.Name }));
        }
        public IActionResult ExpensesCreate() 
        
        
        {
            var typeofExpensesSelectList = Enum.GetValues(typeof(TypeofExpenses))
                                     .Cast<TypeofExpenses>()
                                     .Select(e => new SelectListItem
                                     {
                                         Text = e.ToString(),
                                         Value = e.ToString()
                                     })
                                     .ToList();

            ViewBag.typeofExpenses = typeofExpensesSelectList;

            var typeofCurrencySelectList = Enum.GetValues(typeof(Currency))
                                      .Cast<Currency>()
                                      .Select(e => new SelectListItem
                                      {
                                          Text = e.ToString(),
                                          Value = e.ToString()
                                      })
                                      .ToList();

          


            ViewBag.Currency = typeofCurrencySelectList;




            return View(); 
        
        
        
        
        }
        [HttpPost]
        public async Task<IActionResult> ExpensesCreate(ExpensesCreateCommand request)
        {
            request.UserName = User.Identity.Name;
            if (!ModelState.IsValid) 
            { 
                 var typeofExpensesSelectList = Enum.GetValues(typeof(TypeofExpenses))
                                     .Cast<TypeofExpenses>()
                                     .Select(e => new SelectListItem
                                     {
                                         Text = e.ToString(),
                                         Value = e.ToString()
                                     })
                                     .ToList();

            ViewBag.typeofExpenses = typeofExpensesSelectList;

            var typeofCurrencySelectList = Enum.GetValues(typeof(Currency))
                                      .Cast<Currency>()
                                      .Select(e => new SelectListItem
                                      {
                                          Text = e.ToString(),
                                          Value = e.ToString()
                                      })
                                      .ToList();

          


            ViewBag.Currency = typeofCurrencySelectList;




            return View(); 
            }
            
            var result = await mediator.Send(request);

            TempData["Message"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> ExpensesDelete(string Id)
        {
            var result = await mediator.Send(new ExpensesDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> ExpensesEdit(string id)
        {

            var typeofExpensesSelectList = Enum.GetValues(typeof(TypeofExpenses))
                                   .Cast<TypeofExpenses>()
                                   .Select(e => new SelectListItem
                                   {
                                       Text = e.ToString(),
                                       Value = e.ToString()
                                   })
                                   .ToList();

            ViewBag.typeofExpenses = typeofExpensesSelectList;

            var typeofCurrencySelectList = Enum.GetValues(typeof(Currency))
                                      .Cast<Currency>()
                                      .Select(e => new SelectListItem
                                      {
                                          Text = e.ToString(),
                                          Value = e.ToString()
                                      })
                                      .ToList();




            ViewBag.Currency = typeofCurrencySelectList;



            var model = await mediator.Send(new ExpensesGetSingleForEditCommand { Id = id , IsTracking = false });
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExpensesEdit(ExpensesViewForEdit request)
        {
            if (!ModelState.IsValid)
            {
                var typeofExpensesSelectList = Enum.GetValues(typeof(TypeofExpenses))
                                    .Cast<TypeofExpenses>()
                                    .Select(e => new SelectListItem
                                    {
                                        Text = e.ToString(),
                                        Value = e.ToString()
                                    })
                                    .ToList();

                ViewBag.typeofExpenses = typeofExpensesSelectList;

                var typeofCurrencySelectList = Enum.GetValues(typeof(Currency))
                                          .Cast<Currency>()
                                          .Select(e => new SelectListItem
                                          {
                                              Text = e.ToString(),
                                              Value = e.ToString()
                                          })
                                          .ToList();




                ViewBag.Currency = typeofCurrencySelectList;




                return View(request);
            }

            var result = await mediator.Send(mapper.Map<ExpensesEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ExpensesApprovalList()
        {

            var modelList = await mediator.Send(new ExpensesGetAlllQuery { UserName = User.Identity.Name, IsApproval = true });
            return View(modelList);
        }
        public async Task<IActionResult> ExpensesApproval(string id)
        {
            ExpensesViewModel model = await mediator.Send(new ExpensesGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ExpensesApproval(ExpensesViewModel request)
        {
            if (!ModelState.IsValid)  return View(request); 
            var result = await mediator.Send(mapper.Map<ExpensesApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return View(result.Response);
        }
    }
}
