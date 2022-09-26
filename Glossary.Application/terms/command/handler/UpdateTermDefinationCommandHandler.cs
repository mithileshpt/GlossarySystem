using Glossary.Infrastructure.steple.CQRS;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Glossary.Application.terms.command.handler
{
    public class UpdateTermDefinationCommandHandler : ICommandHandler<UpdateTermDefinationCommand>
    {
        public void Handle(UpdateTermDefinationCommand Command)
        {
            throw new NotImplementedException();
        }
    }
}
