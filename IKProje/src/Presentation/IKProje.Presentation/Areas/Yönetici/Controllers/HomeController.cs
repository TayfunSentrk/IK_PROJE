using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Areas.Yönetici.Controllers
{
    [Area("Yönetici")]
    [Authorize(Roles = "Yönetici")]

    public class HomeController : Controller
    {
        

        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public HomeController(IMapper mapper, IMediator mediator)
        {
            this.mapper = mapper;
            this.mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> SignUp()

        {


            ViewBag.companyViewModel = await mediator.Send(new CompanyGetAllQuery() { Tracking = false });

            ViewBag.departmentViewModels = await mediator.Send(new DepartmentGetAllQuery() { Tracking = false });

            ViewBag.vocationViewModels = await mediator.Send(new VocationGetAllQuery() { Tracking = false });

            var genderList = Enum.GetValues(typeof(Gender))
                              .Cast<Gender>()
                              .Select(e => new SelectListItem
                              {
                                  Text = e.ToString(),
                                  Value = e.ToString()
                              })
                              .ToList();

            ViewBag.Gender = genderList;


            return View();


        }

        [HttpPost]

        public async Task<IActionResult> SignUp(PersonelCreateCommand request)
        {
            if (!ModelState.IsValid)
            {
                var genderList = Enum.GetValues(typeof(Gender))
                              .Cast<Gender>()
                              .Select(e => new SelectListItem
                              {
                                  Text = e.ToString(),
                                  Value = e.ToString()
                              })
                              .ToList();

                ViewBag.Gender = genderList;
                ViewBag.companyViewModel = await mediator.Send(new CompanyGetAllQuery() { Tracking = false });

                ViewBag.departmentViewModels = await mediator.Send(new DepartmentGetAllQuery() { Tracking = false });

                ViewBag.vocationViewModels = await mediator.Send(new VocationGetAllQuery() { Tracking = false });
                ViewBag.Message = "Lütfen Kayıt İçin Bilgilerinizi Kontrol Ediniz";
                return View(request);
            }
            if (request != null)
            {
                request.ManagerUserName = User.Identity.Name;
                await mediator.Send(request);
                ViewBag.Message = "Kayıt Başarılı";
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            ViewBag.companyViewModel = await mediator.Send(new CompanyGetAllQuery() { Tracking = false });

            ViewBag.departmentViewModels = await mediator.Send(new DepartmentGetAllQuery() { Tracking = false });

            ViewBag.vocationViewModels = await mediator.Send(new VocationGetAllQuery() { Tracking = false });
            ViewBag.Gender = Enum.GetValues(typeof(Gender))
                            .Cast<Gender>()
                            .Select(e => new SelectListItem
                            {
                                Text = e.ToString(),
                                Value = e.ToString()
                            })
                            .ToList();


            return View();
        }
    }
}
