using Example.ApplicationCore.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Functions.Posts.Command
{
    internal class SendSEOCheckCommandHandler :
        ICommandHandler<SendSEOCheckCommand>
    {
        public async ValueTask 
            Handle
            (SendSEOCheckCommand command, CancellationToken token)
        {
            return;
        }
    }
}
