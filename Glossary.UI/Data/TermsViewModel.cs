using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.Data
{
    public class TermsViewModel
    {
        public int Id { get; set; }
        public String WordOrPPhrase { get; set; }
        public List<DefinitionViewModel> Definition { get; set; }
    }
}
