namespace WebAPI.Features.Common.SocialLinks.Admin.CreateSocialLink;

public class CreateSocialLinkEndpoint(CardinarDbContext ctx) : Endpoint<CreateSocialLinkRequest, CreateSocialLinkResponse>
{
    public override void Configure()
    {
        Post("v1/admin/social-link/create");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("SocialLink"));
    }

    public override async Task<CreateSocialLinkResponse> ExecuteAsync(CreateSocialLinkRequest req, CancellationToken ct)
    {
        var dirPath = Path.Combine("uploads");
        Directory.CreateDirectory(dirPath);
        var filePath = Path.Combine(dirPath, req.Icon.FileName);
        await using var file = new FileStream(filePath, FileMode.Create);
        await req.Icon.CopyToAsync(file, ct);

        var newLink = ctx.SocialLinks.Add(req.ToEntity(filePath));
        
        await ctx.SaveChangesAsync(ct);
        
        return CreateSocialLinkResponse.FromEntity(newLink.Entity);
    }
}