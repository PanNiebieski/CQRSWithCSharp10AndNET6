using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.Interfaces;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    public class AddPostCommandHandler :
        ICommandHandler<AddPostCommand>
    {
        private IPostRepository _postRepository;

        public AddPostCommandHandler(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public ValueTask Handle(AddPostCommand command, CancellationToken token)
        {
            Post p = new Post()
            {
                Author = request.Author,
                CategoryId = request.CategoryId,
                Date = request.Date,
                Description = request.Description,
                ImageUrl = request.ImageUrl,
                PostId = request.PostId,
                Rate = request.Rate,
                Title = request.Title,
                Url = request.Url
            };

            _postRepository.AddPost(p);
        }
    }
}
