using Example.ApplicationCore.Configuration;
using Example.ApplicationCore.EventConfiguration;
using Example.ApplicationCore.Functions.Posts.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Events
{
    internal class PostCreatedEventHandler : IEventHandler<PostCreatedEvent>
    {
        private ICommandHandler<SendToGrammarCheckerCommand> commandHandler;
        private ICommandHandler<SendToGrammarCheckerCommand> commandHandler;

        public ValueTask Handle(PostCreatedEvent command, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}
