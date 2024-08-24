using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceApproval;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceCreate;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceDelete;
using IKProje.Application.Features.AdvanceFeatures.AdvanceCommands.AdvanceEdit;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetAll;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingle;
using IKProje.Application.Features.AdvanceFeatures.AdvanceQueries.AdvanceGetSingleForEdit;
using IKProje.Application.Features.ExpensesFeatures.ExpensesQueries.ExpensesGetAll;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionCreate;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionDelete;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionCommands.TypeofPermissionEdit;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetAll;
using IKProje.Application.Features.TypeofPermissionFeatures.TypeofPermissionQueries.TypeofPermissionGetSingle;
using IKProje.Application.ViewModels.AdvanceViewModels;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Controllers
{
    [Authorize]
    public class AdvanceController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;
        private readonly IValidator<AdvanceCreateCommand> createValidator;
        private readonly IValidator<AdvanceViewModel> advanceValidator;

        public AdvanceController(IMediator mediator, IMapper mapper,IValidator<AdvanceCreateCommand> createValidator,IValidator<AdvanceViewModel> advanceValidator)
        {

            this.mediator = mediator;
            this.mapper = mapper;
            this.createValidator = createValidator;
            this.advanceValidator = advanceValidator;
        }
        public async Task<IActionResult> Index()
        {

           
            return View(await mediator.Send(new AdvanceGetAllQuery()
            {
                UserName = User.Identity.Name
            })) ;
        }
        public IActionResult AdvanceCreate() {

            var typeofAdvanceSelectList = Enum.GetValues(typeof(TypeofAdvance))
                                     .Cast<TypeofAdvance>()
                                     .Select(e => new SelectListItem
                                     {
                                         Text = e.ToString(),
                                         Value = e.ToString()
                                     })
                                     .ToList();

            ViewBag.TypeofAdvance = typeofAdvanceSelectList;

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
        public async Task<IActionResult> AdvanceCreate(AdvanceCreateCommand request)
        {
            request.UserName = User.Identity.Name;
            //  var validationResult = await createValidator.ValidateAsync(request);
            if (!ModelState.IsValid)
            {
                //validationResult.AddToModelState(this.ModelState);

                var typeofAdvanceSelectList = Enum.GetValues(typeof(TypeofAdvance))
                                  .Cast<TypeofAdvance>()
                                  .Select(e => new SelectListItem
                                  {
                                      Text = e.ToString(),
                                      Value = e.ToString()
                                  })
                                  .ToList();

                ViewBag.TypeofAdvance = typeofAdvanceSelectList;

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

            
            var result = await mediator.Send(request);

            TempData["Message"] = result.Message;

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> AdvanceDelete(string Id)
        {
            var result = await mediator.Send(new AdvanceDeleteCommand { Id = Id });
            TempData["Message"] = result.Message;
            return RedirectToAction("Index", "Advance");
        }
        public async Task<IActionResult> AdvanceEdit(string id)
        {

            var typeofAdvanceSelectList = Enum.GetValues(typeof(TypeofAdvance))
                                    .Cast<TypeofAdvance>()
                                    .Select(e => new SelectListItem
                                    {
                                        Text = e.ToString(),
                                        Value = e.ToString()
                                    })
                                    .ToList();

            ViewBag.TypeofAdvance = typeofAdvanceSelectList;

            var typeofCurrencySelectList = Enum.GetValues(typeof(Currency))
                                      .Cast<Currency>()
                                      .Select(e => new SelectListItem
                                      {
                                          Text = e.ToString(),
                                          Value = e.ToString()
                                      })
                                      .ToList();

            ViewBag.TypeofAdvance = typeofAdvanceSelectList;


            ViewBag.Currency = typeofCurrencySelectList;

            var model = await mediator.Send(new AdvanceGetSingleForEditCommand { Id = id,IsTracking=false });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceEdit(AdvanceViewForEdit request)
        {
            if (!ModelState.IsValid)
            {
  
                var typeofAdvanceSelectList = Enum.GetValues(typeof(TypeofAdvance))
                                  .Cast<TypeofAdvance>()
                                  .Select(e => new SelectListItem
                                  {
                                      Text = e.ToString(),
                                      Value = e.ToString()
                                  })
                                  .ToList();

                ViewBag.TypeofAdvance = typeofAdvanceSelectList;

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

            var result = await mediator.Send(mapper.Map<AdvanceEditCommand>(request));

            TempData["Message"] = result.Message;
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> AdvanceApprovalList()
        {

            var modelList = await mediator.Send(new AdvanceGetAllQuery { UserName = User.Identity.Name, IsApproval = true });
            return View(modelList);
        }
        public async Task<IActionResult> AdvanceApproval(string id)
        {
            AdvanceViewModel model = await mediator.Send(new AdvanceGetSingleQuery { Id = id });
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdvanceApproval(AdvanceViewModel request)
        {
            if (!ModelState.IsValid)
            {
                
                return View(request);
            }

            var result = await mediator.Send(mapper.Map<AdvanceApprovalCommand>(request));

            TempData["Message"] = result.Message;
            return View(result.Response);
        }
    }
}
