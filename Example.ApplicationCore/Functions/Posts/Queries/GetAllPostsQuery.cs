

namespace Example.ApplicationCore.Functions.Posts.Queries
{
    public record GetAllPostsQuery(OrderByPostOptions OrderBy,
         int Page,int PageSize)
    {
        private const int DefaultPage = 1;
        private const int DefaultPageSize = 10;

        public static GetAllPostsQuery 
            With(OrderByPostOptions? filter, int? page, int? pageSize)
        {
            page ??= DefaultPage;
            pageSize ??= DefaultPageSize;

            filter ??= OrderByPostOptions.None;

            if (page <= 0)
                throw new ArgumentOutOfRangeException(nameof(page));

            if (pageSize <= 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize));

            return new(filter.Value, page.Value, pageSize.Value);
        }
    }
}
