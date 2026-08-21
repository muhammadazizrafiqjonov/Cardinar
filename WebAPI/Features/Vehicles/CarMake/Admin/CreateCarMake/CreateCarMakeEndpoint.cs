using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using WebAPI;
using WebAPI.Core.Exceptions;
using WebAPI.Features.Branches.Admin.CreateBranch;
using WebAPI.Features.Vehicles.CarMake.Admin.CreateCarMake;

namespace Namespace;

public class CreateCarMakeEndpoint(CardinarDbContext ctx) : Endpoint<CreateCarMakeRequest, CreateCarMakeResponse>
{
    public override void Configure()
    {
        Post("v1/public/car-make/create-car-make");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("CarMakes"));
    }

    public override async Task<CreateCarMakeResponse> ExecuteAsync(CreateCarMakeRequest req, CancellationToken ct)
    {
        var alreadyExists = await ctx.CarMakes
            .AnyAsync(c => EF.Functions.ILike(c.Title, req.Title), ct);
        AlreadyExistsException.ThrowIf(alreadyExists);

        var newBranch =  ctx.CarMakes.Add(req.ToEntity());
        await ctx.SaveChangesAsync(ct);

        return CreateCarMakeResponse.FromEntity(newBranch.Entity);
    }
}