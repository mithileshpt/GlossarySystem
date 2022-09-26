using Glossary.Infrastructure.steple.CQRS;
using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Application.terms.command
{
    public class AddTermDefinationCommand : ICommand
    {
        public string WordOrPhrase { get; set; }
        public String Defination { get; set; }
    }
}
