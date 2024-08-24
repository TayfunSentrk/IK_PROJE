using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetAll;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetAll;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelCreate;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordReset;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelSignIn;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelUpdatePassword;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelDetails;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetAll;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle;
using IKProje.Application.ViewModels;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Base.Enums;
using IKProje.Domain.Entities.Entity;
using IKProje.Presentation.Extensions;
using IKProje.Presentation.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Diagnostics;

namespace IKProje.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator mediator;
        private readonly UserManager<Personel> userManager;


        public HomeController(ILogger<HomeController> logger, IMediator mediator, UserManager<Personel> userManager)
        {
            _logger = logger;
            this.mediator = mediator;
            this.userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
           
          
            PersonelDetailQuery request = new PersonelDetailQuery()
            {
                UserName = User.Identity!.Name!
            };

            if (request.UserName==null)
            {
                return RedirectToAction(nameof(HomeController.SignIn));
            }
            var result = await mediator.Send(request);

            if (result.DepartmanId != null)
            {
                ViewBag.Departman = await mediator.Send(new DepartmentGetSingleQuery() { Id = result.DepartmanId });
            }
            if (result.CompanyId != null)
            {
                ViewBag.Company = await mediator.Send(new CompanyGetByIdQuery() { Id = result.CompanyId });
            }
            if (result.VocationId != null)
            {
                ViewBag.Vocation = await mediator.Send(new VocationGetSingleQuery() { Id = result.VocationId });
            }

            return View(result);

         
        }

        public IActionResult Privacy()
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
                await mediator.Send(request);
                ViewBag.Message = "Kayıt Başarılı";
                return RedirectToAction(nameof(SignIn));
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
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(PersonelSigInCommand request, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            returnUrl = returnUrl ?? Url.Action("Index", "Home");
            var result = await mediator.Send(request);
            if (result.Succeeded)
            {
                return Redirect(returnUrl);
            }

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "3 dk boyunca giriş yapamazsınız.");
                return View();
            }

            ModelState.AddModelError(string.Empty, "Yanlış e-posta veya şifre.");
            //ModelState.AddModelError(string.Empty, "Email Veya Şifreniz Yanlış.");

            return View();
        }
        public IActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordReset(PersonelPasswordResetCommand request)
        {
            var response = await mediator.Send(request);
            return View();
        }
        public async Task<IActionResult> UpdatePassword()
        {                 
                   
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePassword(PersonelUpdatePasswordCommand request)
        {
           
            request.UserId = Request.Query["userId"].ToString();
          
            var responce = await mediator.Send(request);
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}