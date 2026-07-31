using Microsoft.EntityFrameworkCore;

namespace WebAPI.Features.Common.PhoneNumbers.Public.GetAllPhoneNumbers;

public class GetAllPhoneNumbersEndpoint(CardinarDbContext context) : Endpoint<WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersRequest, WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersResponse>
{
    public override void Configure()
    {
        Get("v1/admin/phone-numbers/get-all-phone-numbers");
        Policies("Public");
        Tags("Public");
        Options(opts => opts.WithTags("PhoneNumbers"));
    }

    public override async Task<WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersResponse> ExecuteAsync(WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersRequest req, CancellationToken ct)
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
        var data = await query.Select(WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersResponse.Project).Skip(skip).Take(take).ToArrayAsync(ct);

        return PaginatedResponse<WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers.GetAllPhoneNumbersResponse>.BuildFrom(totalCount, totalPages, currentPage, data);
    }
}