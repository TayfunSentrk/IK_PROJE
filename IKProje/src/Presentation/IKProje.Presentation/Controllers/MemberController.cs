using AutoMapper;
using IKProje.Application.Features.CompanyFeatures.CompanyQueries.CompanyGetSingle;
using IKProje.Application.Features.DepartmentFeatures.DepartmendQueries.DepartmentGetSingle;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelEdit;
using IKProje.Application.Features.PersonelFeatures.PersonelCommands.PersonelPasswordChange;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelDetails;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetByName;
using IKProje.Application.Features.PersonelFeatures.PersonelQueries.PersonelGetForEdit;
using IKProje.Application.Features.VocationFeatures.VocationsQueries.VocationGetSingle;
using IKProje.Application.ViewModels.Personel;
using IKProje.Domain.Entities.Entity;
using IKProje.Presentation.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;

namespace IKProje.Presentation.Controllers
{

    [Authorize]
    public class MemberController : Controller
    {

        private readonly SignInManager<Personel> signInManager;
        private readonly UserManager<Personel> userManager;
        private readonly IFileProvider fileProvider;
        private readonly IMediator mediator;
        private readonly IMapper mapper;

        public MemberController(SignInManager<Personel> signInManager, UserManager<Personel> userManager, IFileProvider fileProvider, IMediator mediator, IMapper mapper)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.fileProvider = fileProvider;
            this.mediator = mediator;
            this.mapper = mapper;
        }
        public IActionResult LogOut()
        {
            signInManager.SignOutAsync();


            return RedirectToAction("SignIn", "Home");
        }

        //Kullanıcının Özet bilgilerini getirme işlemi
        public async Task<IActionResult> Index()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PersonelGetByNameQuery personelGetByName = new PersonelGetByNameQuery
            {
                UserName = User.Identity!.Name!
            };
            var result = await mediator.Send(personelGetByName);

            return View(result);
        }

        //Giriş yapan Kullanıcı bilgilerini güncellemek istediğinde oluşan sayfa bu sayfada güncel verileri olacaktır.
        public async Task<IActionResult> UserEdit()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PersonelGetForEditQuery request = new PersonelGetForEditQuery()
            {
                UserName = User.Identity!.Name!
            };
            var result = await mediator.Send(request);

            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> UserEdit(PersonelInformationForEdit request)
        {
            if (!ModelState.IsValid) return View(request);

            if (request.Picture != null && request.Picture.Length > 0)
            {
                var data = request.PicturePath.AddPicturePath(request.Picture, fileProvider);
                request.PicturePath = data;
            }
            var personelEditCommand = mapper.Map<PersonelEditCommand>(request);
            personelEditCommand.UserName = User.Identity!.Name!;
            PersonelEditCommand personelEdit = await mediator.Send(personelEditCommand);

            if (personelEdit.IdentityResult.Succeeded)
                ModelState.AddModelErrorList(personelEdit.IdentityResult.Errors.Select(x => x.Description).ToList());


            TempData["Message"] = "Hesabınız başarıyla güncellenmiştir...";

            PersonelInformationForEdit personelInformationModel = mapper.Map<PersonelInformationForEdit>(personelEdit);

            return View(personelInformationModel);
        }

        //birleştirme işlemi yapılacakdeğişiklik yapıldı
        public async Task<IActionResult> UserDetails()
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            PersonelDetailQuery request = new PersonelDetailQuery()
            {
                UserName = User.Identity!.Name!
            };
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


        public IActionResult PasswordChange()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PasswordChange(PersonelPasswordChangeCommand request)
        {
            if (!ModelState.IsValid) return View();
            request.UserName = User.Identity!.Name!;
            PersonelPasswordChangeCommandResponce
                result = await mediator.Send(request);

            if (!result.checkOldPassword)
            {
                ModelState.AddModelError(string.Empty, "Eski şifreniz yanlıştır.");
                return View();

            }

            if (!result.result.Succeeded)
            {
                ModelState.AddModelErrorList(result.result.Errors.Select(x => x.Description).ToList());
                return View();
            }

            TempData["Message"] = "Şifreniz Başarıyla Değiştirilmiştir..";
            return View();
        }

        public async Task<IActionResult> AccessDenied(string returnUrl)
        {
            return View();
        }

    }
}
