using Example.ApplicationCore.EventConfiguration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Events
{
    internal class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
    {
        private SendToGrammarCheckerCommandHandler


        public ValueTask Handle(PostCreatedEvent command, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
