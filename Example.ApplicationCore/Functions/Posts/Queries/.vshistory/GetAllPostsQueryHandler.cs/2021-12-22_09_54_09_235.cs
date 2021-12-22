using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Interfaces;

namespace Example.ApplicationCore.Functions.Posts.Queries
{
    public class GetAllPostsQueryHandler :
        IQueryHandler<GetAllPostsQuery, List<Post>>
    {
        private IPostRepository _postRepository;

        public GetAllPostsQueryHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ValueTask<List<Post>> Handle
            (GetAllPostsQuery request, CancellationToken ct)
        {
            var posts = _postRepository.GetAll();

            if (request.OrderBy == OrderByPostOptions.ByAuthor)
                return ValueTask.FromResult
                    (posts.OrderByDescending(p => p.Author).ToList());
            else if (request.OrderBy == OrderByPostOptions.ByDate)
                return ValueTask.FromResult
                    (posts.OrderByDescending(p => p.Date).ToList());
            else if (request.OrderBy == OrderByPostOptions.ByTitle)
                return ValueTask.FromResult
                    (posts.OrderByDescending(p => p.Title).ToList());
            else if (request.OrderBy == OrderByPostOptions.Error)
                return ValueTask.FromResult
                    (new List<Post>());

            return ValueTask.FromResult
                   (posts.ToList());
        }
    }
}
