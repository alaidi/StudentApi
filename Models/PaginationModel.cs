namespace StudentApi.Models;

public record PageInfo(
    int TotalCount,
    int PageSize,
    int CurrentPage,
    bool HasNextPage,
    bool HasPreviousPage
);

public record PaginatedList<T>(
    IEnumerable<T> Items,
    PageInfo PageInfo
);
