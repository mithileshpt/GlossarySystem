using System;
using System.Collections.Generic;
using System.Text;

namespace Glossary.Core.entities
{
    public class Definition
    {
        public int Id { get; set; }
        public String Description { get; set; }
        public Term Term { get; set; }
    }
}
