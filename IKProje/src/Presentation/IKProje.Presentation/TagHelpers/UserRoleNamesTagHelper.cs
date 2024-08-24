using IKProje.Domain.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace IKProje.Presentation.TagHelpers
{
    public class UserRoleNamesTagHelper : TagHelper
    {
        private readonly UserManager<Personel> userManager;

        public string Id { get; set; }
        public UserRoleNamesTagHelper(UserManager<Personel> userManager)
        {
            this.userManager = userManager;
        }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var user = await userManager.FindByIdAsync(Id);
            var userRoles = await userManager.GetRolesAsync(user);
            var stringBuilder = new StringBuilder();
            foreach (var item in userRoles.ToList())
            {
                stringBuilder.Append(@$"
                   <span class='badge bg-secondary mx-1'>{item.ToLower()}</span>
                        ");
            }
            output.Content.SetHtmlContent(stringBuilder.ToString());
        }
    }
}
