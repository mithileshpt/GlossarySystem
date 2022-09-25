using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Application.terms.command
{
    public class UpdateTermDefinationCommand
    {
        public int Id { get; set; }
        public string WordOrPhrase { get; set; }
        public String Defination { get; set; }
    }
}
