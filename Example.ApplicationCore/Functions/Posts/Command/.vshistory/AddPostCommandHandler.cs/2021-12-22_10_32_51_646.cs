using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.EventConfiguration;
using Example.ApplicationCore.Functions.Posts.Events;
using Example.ApplicationCore.Interfaces;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    public class AddPostCommandHandler :
        ICommandHandler<AddPostCommand>
    {
        private IPostRepository _postRepository;

        private IEventHandler<PostCreatedEvent> _eventHandler;

        public AddPostCommandHandler(IPostRepository postRepository,
            IEventHandler<PostCreatedEvent> eventHandler)
        {
            _postRepository = postRepository;
            _eventHandler = eventHandler;
        }

        public async ValueTask Handle
            (AddPostCommand request, CancellationToken token)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("AddPostCommandHandler");
            Console.ResetColor();



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


            _eventHandler.Handle(p,token);

            return;
        }
    }
}
