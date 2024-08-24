using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IKProje.Presentation.TagHelpers
{
    public class UserPictureThumbNailTagHelper : TagHelper
    {

        public string PictureUrl { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (string.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userpictures/defaultProfilPicture.png");
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
            }


        }

    }
}
