using Microsoft.AspNetCore.Razor.TagHelpers;

namespace IdentityApp.Web.TagHelpers
{
    public class UserPictureThumbnailTagHelper : TagHelper
    {
        public string? PictureUrl { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";

            if (string.IsNullOrEmpty(PictureUrl))
            {
                output.Attributes.SetAttribute("src", "/userpictures/default_user_picture.jpeg");
            }
            else
            {
                output.Attributes.SetAttribute("src", $"/userpictures/{PictureUrl}");
            }
        }
    }
}
