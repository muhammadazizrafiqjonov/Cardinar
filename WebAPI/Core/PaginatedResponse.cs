using WebAPI.Features.Auth.Users.Admin.GetAllUsers;
using WebAPI.Features.Common.PhoneNumbers.Admin.GetAllPhoneNumbers;

namespace WebAPI.Core;

public class PaginatedResponse<T>
{
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public int CurrentPage { get; set; }
    public bool HasNext { get; set; }
    public bool HasPrevious { get; set; }
    public ICollection<T> Data { get; set; } = [];

    public static GetAllPhoneNumbersResponse BuildFrom(int totalCount, int totalPages, int currentPage, ICollection<T> data) => new GetAllPhoneNumbersResponse()
    {
        TotalCount = totalCount,
        TotalPages = totalPages,
        CurrentPage = currentPage,
        HasNext = currentPage < totalPages,
        HasPrevious = currentPage > 1,
        Data = data
    };
}