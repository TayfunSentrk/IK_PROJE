using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace IKProje.Presentation.Extensions
{
    public static class ModelStateExtensions
    {
        public static void AddModelErrorList(this ModelStateDictionary modelState, List<string> errors)
        {
            foreach (string item in errors)
            {
                modelState.AddModelError(string.Empty, item);
            }

        }
    }
}
