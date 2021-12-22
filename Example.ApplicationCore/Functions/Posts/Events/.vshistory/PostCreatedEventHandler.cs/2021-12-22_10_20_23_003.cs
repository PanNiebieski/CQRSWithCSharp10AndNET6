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
        private ICommandHandler<SendToGrammarCheckerCommand> _sendToGrammarCheckerCommand;
        private ICommandHandler<SendSEOCheckCommandHandler> _sendSEOCheckCommandHandler;

        public PostCreatedEventHandler(ICommandHandler<SendToGrammarCheckerCommand> 
            sendToGrammarCheckerCommand,
            ICommandHandler<SendSEOCheckCommandHandler> sendSEOCheckCommandHandler)
        {
            _sendToGrammarCheckerCommand = sendToGrammarCheckerCommand;
            _sendSEOCheckCommandHandler = sendSEOCheckCommandHandler;
        }

        public async ValueTask Handle(PostCreatedEvent command, CancellationToken token)
        {
            await _sendToGrammarCheckerCommand.Handle(
                new SendToGrammarCheckerCommand(command.CreatedPost), token);

            await _sendSEOCheckCommandHandler.Handle(
                new SendSEOCheckCommand(command.CreatedPost), token);
        }
    }
}
