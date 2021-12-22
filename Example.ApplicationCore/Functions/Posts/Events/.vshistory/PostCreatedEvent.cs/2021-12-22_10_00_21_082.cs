using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Events
{
    public record  PostCreatedEvent
    {
        public PostCreatedEvent(Post d)
        {
            CreatedPost = d;
        }

        public Post CreatedPost { get; init; }
    }
}
