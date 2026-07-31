using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

public class GetAllPhoneNumbersEndpoint(CardinarDbContext context) : Endpoint<GetAllPhoneNumbersRequest, GetAllPhoneNumbersResponse>
{
    public override void Configure()
    {
        Get("v1/admin/phone-numbers/get-all-phone-numbers");
        Policies("Admin");
        Tags("Admin");
        Options(opts => opts.WithTags("PhoneNumbers"));
    }

    public override async Task<GetAllPhoneNumbersResponse> ExecuteAsync(GetAllPhoneNumbersRequest req, CancellationToken ct)
    {
        
        var currentPage = req.Page ?? 1;
        var take = req.Size ?? 10;
        var skip = (currentPage - 1) * take;
        
        
        var query = context.Users.AsNoTracking();

        if (!string.IsNullOrEmpty(req.Search))
            query = query.Where(p => EF.Functions.ILike(p.PhoneNumber, $"%{req.Search}%"));

        if (req.IsAdmin != null)
            query = query.Where(p => p.IsAdmin == req.IsAdmin);

        var totalCount = await query.CountAsync(ct);
        var totalPages = (int)Math.Ceiling((double)totalCount / (req.Size ?? take));
        var data = await query.Select(GetAllPhoneNumbersResponse.project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<GetAllPhoneNumbersResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
    }
}