using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using WebAPI.Core.Exceptions;

namespace WebAPI.Features.Vehicles.CarMake.Admin.DeleteCarMake;

public class DeleteCarMakeEndpoint(CardinarDbContext ctx) : Endpoint<DeleteCarMakeRequest, NoContent>
{
    public override void Configure()
    {
        Delete("v1/public/car-make/delete-car-make/{id}");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("CarMakes"));
    }

    public override async Task HandleAsync(DeleteCarMakeRequest req, CancellationToken ct)
    {
        var ifExists = await ctx.CarMakes
            .AnyAsync(b => Equals(b.Id, req.Id), ct);
        DoesNotExistsException.ThrowIf(ifExists);
        
        var carmake = await ctx.CarMakes.SingleOrDefaultAsync(c => Equals(c.Id, req.Id), ct);
        if (carmake != null) ctx.CarMakes.Remove(carmake);

        await ctx.SaveChangesAsync(ct);

        await Send.NoContentAsync();
    }
}