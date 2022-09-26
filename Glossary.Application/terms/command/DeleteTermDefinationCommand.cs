using Glossary.Infrastructure.steple.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Application.terms.command
{
    public class DeleteTermDefinationCommand : ICommand
    {
        public int Id { get; set; }
    }
}
