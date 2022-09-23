using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Core.entities
{
    public class Term
    {
        public int Id { get; set; }
        public String WordOrPPhrase { get; set; }
        public List<Definition> Definition { get; set; }
    }
}
