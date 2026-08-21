using Microsoft.EntityFrameworkCore;
namespace WebAPI.Features.Vehicles.CarMake.Public.GetAllCarMake;

public class GetAllCarMakesEndpoint(CardinarDbContext ctx) : Endpoint<GetAllCarMakesRequest, PaginatedResponse<GetAllCarMakesResponse>>
{
    public override void Configure()
    {
        Get("v1/public/car-make/get-all-car-makes");
        Policies("Public");
        Tags("Public");
        Options(opts => opts.WithTags("CarMakes"));
    }

    public override async Task<PaginatedResponse<GetAllCarMakesResponse>> ExecuteAsync(GetAllCarMakesRequest req, CancellationToken ct)
    {
        
        var currentPage = req.Page ?? 1;
        var take = req.Size ?? 10;
        var skip = (currentPage - 1) * take;
        
        var query = ctx.CarMakes.AsNoTracking();

        if (!string.IsNullOrEmpty(req.Search))
            query = query.Where(b => EF.Functions.ILike(b.Title, $"%{req.Search}%"));
        

        var totalCount = await query.CountAsync(ct);
        var totalPages = (int)Math.Ceiling((double)totalCount / (req.Size ?? take));
        var data = await query.Select(GetAllCarMakesResponse.Project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<GetAllCarMakesResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
    }
}