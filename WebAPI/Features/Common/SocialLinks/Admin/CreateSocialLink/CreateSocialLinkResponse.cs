using WebAPI.Features.Common.Entities;
using WebAPI.Features.Common.PhoneNumbers.Admin.CreatePhoneNumber;
using PhoneNumber = WebAPI.Features.Common.Entities.PhoneNumber;

namespace WebAPI.Features.Common.SocialLinks.Admin.CreateSocialLink;

public class CreateSocialLinkResponse
{
    public string Title { get; set; } = null!;
    public string Link { get; set; } = null!;
    
    public static CreateSocialLinkResponse FromEntity(SocialLink entity)
    {
        return new CreateSocialLinkResponse()
        {
            Title = entity.Title,
            Link = entity.Link
        };
    } 
}