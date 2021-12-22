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
        private ICommandHandler<SendToGrammarCheckerCommand> 
            _sendToGrammarCheckerCommand;

        private ICommandHandler<SendSEOCheckCommand> 
            _sendSEOCheckCommand;

        public PostCreatedEventHandler(ICommandHandler<SendToGrammarCheckerCommand> 
            sendToGrammarCheckerCommand,
            ICommandHandler<SendSEOCheckCommand> sendSEOCheckCommand)
        {
            _sendToGrammarCheckerCommand = sendToGrammarCheckerCommand;
            _sendSEOCheckCommand = sendSEOCheckCommand;
        }

        public async ValueTask Handle(PostCreatedEvent command, CancellationToken token)
        {
            await _sendToGrammarCheckerCommand.Handle(
                new SendToGrammarCheckerCommand(command.CreatedPost), token);

            await _sendSEOCheckCommand.Handle(
                new SendSEOCheckCommand(command.CreatedPost), token);
        }
    }
}
