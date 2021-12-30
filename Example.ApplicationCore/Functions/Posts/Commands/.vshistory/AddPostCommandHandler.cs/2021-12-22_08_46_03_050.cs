using Example.ApplicationCore.Configuration;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    public class AddPostCommandHandler :
        ICommandHandler<AddPostCommand>
    {
        private IPostRepository _postRepository;

        public ValueTask Handle(AddPostCommand command, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
