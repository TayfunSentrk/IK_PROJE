using FluentValidation;
using IKProje.Application.ViewModels.TypeofPermissionViewModels;
using IKProje.Domain.Entities.Base.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKProje.Application.Validations.BaseValidations
{
    public   class BaseValidationRules
    { public static void NameRules<T>(IRuleBuilder<T,string> ruleBuilder)
        {
            ruleBuilder
            .NotNull().NotEmpty()
            .WithMessage("Lütfen 'Ad'i boş geçmeyiniz.")
            .MaximumLength(20)
            .MinimumLength(3)
            .WithMessage("'Ad' değeri 3 ile 20 karakter arasında olmalıdır.");
        }

        public static void TotalAmount<T>(IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.NotNull().NotEmpty().WithMessage("Toplam tutar değeri boş bırakılamaz.")
                 .Must(BeAValidNumber).WithMessage("Toplam tutar sadece sayısal değer içermelidir.")
            .GreaterThanOrEqualTo(2000).WithMessage("Toplam tutar en az 2 bin olmalı.")
            .Must(value => value > 0).WithMessage("Toplam tutar 0 veya daha küçük bir değer olamaz.");
        } 
        public static void Currency<T>(IRuleBuilder<T, Currency> ruleBuilder)
        {
            ruleBuilder.NotNull().NotEmpty().WithMessage("Para Birimi alanı boş bırakılamaz.");
        }
        public static void TypeofAdvance<T>(IRuleBuilder<T, TypeofAdvance> ruleBuilder)
        {
            ruleBuilder.NotNull().NotEmpty().WithMessage("Avans Türü Alanı  boş bırakılamaz.");
        }    
        public static void TypeofExpenses<T>(IRuleBuilder<T, TypeofExpenses> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Harcama Türü Alanı  boş bırakılamaz.");
        }   
        public static void Description<T>(IRuleBuilder<T, string> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Tanım Alanı  boş bırakılamaz.");
        }  
        public static void DayCount<T>(IRuleBuilder<T, byte> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("İzin yapılacak gün sayısını bildirmeniz gerekmektedir.");
        }
        public static void StartedDay<T>(IRuleBuilder<T, DateTime> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("İznin başlayacağı gün boş geçilemez.");
        }
        public static void FinishedDay<T>(IRuleBuilder<T, DateTime> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("İznin biteceği gün boş geçilemez.");
        }
        public static void TypeofPermission<T>(IRuleBuilder<T, TypeofPermissionViewModel> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("İzin Türünü seçiniz,bu alan boş geçilemez.");
        }
        public static void FirstName<T>(IRuleBuilder<T, string> ruleBuilder)
        {
            ruleBuilder
        .NotNull()
        .WithMessage("İsim alanı boş geçilemez.")
        .MaximumLength(20)
        .WithMessage("İsim alanı maksimum 20 karakter olabilir.")
        .MinimumLength(2)
        .WithMessage("İsim alanı minimum 2 karakter olmalıdır.");
        }
        public static void LastName<T>(IRuleBuilder<T, string> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Soyisim alanı boş geçilemez.").MaximumLength(20).WithMessage("Soyisim alanı maksimium 20 karakter olabilir").MinimumLength(2).WithMessage("Minimum 2 karakter olabilir.");
        }
        public static void IdentityNumber<T>(IRuleBuilder<T, string> ruleBuilder)
        {
       
         ruleBuilder
        .NotNull()
        .WithMessage("T.C. Kimlik No alanı null geçilemez.")
        .Length(11)
        .WithMessage("T.C. Kimlik No 11 karakter olmalıdır.")
        .Must(BeNumeric)
        .WithMessage("T.C. Kimlik No sadece sayısal karakterler içermelidir.");
        }
        public static void Address<T>(IRuleBuilder<T, string> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Adres alanı boş geçilemez.").MaximumLength(100).MinimumLength(10).WithMessage("Adres alanı maksimium 100  ve minimum 10 karakter olabilir.");
        }
        public static void PlaceBirth<T>(IRuleBuilder<T, string> ruleBuilder)
        {
            ruleBuilder.NotNull().NotEmpty().WithMessage("Doğum Yeri alanı boş geçilemez.").MaximumLength(100).MinimumLength(2).WithMessage("Doğum Yeri alanı maksimium 100  ve minimum 2 karakter olabilir.");
        }
        public static void Salary<T>(IRuleBuilder<T, decimal> ruleBuilder)
        {
            ruleBuilder.NotNull().WithMessage("Maaş alanı boş geçilemez.").GreaterThanOrEqualTo(11500).WithMessage("Maaş tutarı asgari ücretten büyük olmalıdır").Must(BeAValidNumber).WithMessage("Maaş alanında harf veya farklı karakter kullanılamaz.");
        }
        public static void BirthDate<T>(IRuleBuilder<T, DateTime> ruleBuilder)
        {
            ruleBuilder
        .NotNull()
        .WithMessage("Doğum tarihi alanı boş geçilemez.")
        .Must(BeAtLeast18YearsOld)
        .WithMessage("En az 18 yaşında olmalısınız.")
        .Must(BeLessThan90YearsOld)
        .WithMessage("90 yaşından küçük olmalısınız.");
        }
        //public static void IdRules<T>(IRuleBuilder<T, string> ruleBuilder)
        //{
        //    ruleBuilder.NotNull().WithMessage("Id  boş bırakılamaz.");
        //}


        private static bool BeAtLeast18YearsOld(DateTime birthDate)
        {
            return birthDate <= DateTime.Today.AddYears(-18);
        }

        private static bool BeLessThan90YearsOld(DateTime birthDate)
        {
            return birthDate > DateTime.Today.AddYears(-90);
        }

        private static bool BeAValidNumber(decimal value)
        {
            return decimal.TryParse(value.ToString(), out _);
        }

        private static bool BeNumeric(string identityNumber)
        {
            if (identityNumber == null)
            {
                return false;
            }

            // identityNumber null değilse, tüm karakterlerin sayısal olup olmadığını kontrol et.
            return identityNumber.All(char.IsDigit);
        }

    }
}
