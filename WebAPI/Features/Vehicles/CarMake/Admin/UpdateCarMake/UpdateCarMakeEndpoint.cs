using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Vehicles.CarMake.Admin.UpdateCarMake;

public class UpdateCarMakeEndpoint(CardinarDbContext ctx) : Endpoint<UpdateCarMakeRequest, UpdateCarMakeResponse>
{
    public override void Configure()
    {
        Patch("v1/public/car-make/update-car-make");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("CarMakes"));
    }

    public override async Task<UpdateCarMakeResponse> ExecuteAsync(UpdateCarMakeRequest req, CancellationToken ct)
    {
        var ifExists =
            await ctx.CarMakes.AnyAsync(c =>  c.Id == req.Id, ct);
        DoesNotExistsException.ThrowIf(ifExists);
        
        var updatedBranch = ctx.CarMakes.Update(req.ToEntity());
        await ctx.SaveChangesAsync(ct);

        return UpdateCarMakeResponse.FromEntity(updatedBranch.Entity);
    }
}