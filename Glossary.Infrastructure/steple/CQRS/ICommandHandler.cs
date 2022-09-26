using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Infrastructure.steple.CQRS
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        void Handle(TCommand Command);
    }
}
