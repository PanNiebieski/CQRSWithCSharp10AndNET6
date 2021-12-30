using Example.ApplicationCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    public  class SendToGrammarCheckerCommandHandler :
                ICommandHandler<SendToGrammarCheckerCommand>
    {
        public async ValueTask
    Handle
    (SendToGrammarCheckerCommand command, CancellationToken token)
        {
            return;
        }
    }
}
