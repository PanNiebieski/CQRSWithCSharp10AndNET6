using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example.ApplicationCore.Configuration
{
    //public interface ICommandHandler<in T>
    //{
    //    void Handle(T command, CancellationToken token);
    //}

    //public interface ICommandHandler<in T>
    //{
    //    Task Handle(T command, CancellationToken token);
    //}

    public interface ICommandHandler<in T>
    {
        ValueTask Handle(T command, CancellationToken token);
    }
}
