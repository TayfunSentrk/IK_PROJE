using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetAll;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IKProje.Presentation.Areas.Admin.Controllers
{
    [Area("Admin")]

    [Authorize(Roles ="Admin")]
    public class HomeController : Controller
    {
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public HomeController(IMediator mediator, IMapper mapper)
        {
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> Userlist()
        {

            ViewBag.companyViewModel = await mediator.Send(new CompanyGetAllQuery() { Tracking = false });
            return View(await mediator.Send(new PersonelGetAllQuery() {}));
           
           
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


        
        public async Task<IActionResult> GetByCompany(string companyId)
        {
           
            var personelList=new List<PersonelViewModel>();
            if (companyId==null)
            {
               personelList = await mediator.Send(new PersonelGetAllQuery() { });
            }

            else
            {
                var query = new PersonelGetAllQuery
                {
                    CompanyId = companyId
                };

                personelList = await mediator.Send(query);
            }

            return View("PartialMyView", personelList);
        }



        public async Task<IActionResult> PartialMyView(string companyId)
        {

            var personelList = new List<PersonelViewModel>();

            if (!string.IsNullOrEmpty(companyId))
            {
                var query = new PersonelGetAllQuery
                {
                    CompanyId = companyId
                };
                personelList = await mediator.Send(query);
            }
            else
            {
                // Eğer companyId boş ise, tüm personelleri almak için bir sorgu gönderin
                personelList = await mediator.Send(new PersonelGetAllQuery());
            }

            return PartialView(personelList);
        }


       


    }
}
