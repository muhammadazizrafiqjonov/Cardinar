using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.Common.PhoneNumbers.Public.GetAllPhoneNumbers;

public class GetAllPhoneNumbersEndpoint(CardinarDbContext context) : Endpoint<GetAllPhoneNumbersRequest, PaginatedResponse<GetAllPhoneNumbersResponse>>
{
    public override void Configure()
    {
        Get("v1/public/phone-numbers/get-all-phone-numbers");
        Policies("Public");
        Tags("Public");
        Options(opts => opts.WithTags("PhoneNumbers"));
    }

    public override async Task<PaginatedResponse<GetAllPhoneNumbersResponse>> ExecuteAsync(GetAllPhoneNumbersRequest req, CancellationToken ct)
    {
        
        var currentPage = req.Page ?? 1;
        var take = req.Size ?? 10;
        var skip = (currentPage - 1) * take;
        
        
        var query = context.PhoneNumbers.AsNoTracking();

        if (!string.IsNullOrEmpty(req.Search))
            query = query.Where(p => EF.Functions.ILike(p.Value, $"%{req.Search}%"));
        

        var totalCount = await query.CountAsync(ct);
        var totalPages = (int)Math.Ceiling((double)totalCount / (req.Size ?? take));
        var data = await query.Select(GetAllPhoneNumbersResponse.Project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<GetAllPhoneNumbersResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
    }
}