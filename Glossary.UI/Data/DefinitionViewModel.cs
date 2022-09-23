using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.Data
{
    public class DefinitionViewModel
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public long TermId { get; set; }
    }
}
