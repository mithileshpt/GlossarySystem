using Glossary.UI.Data;
using Glossary.UI.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.Pages
{
    public partial class TermDefinations
    {
        [Parameter]
        public string TermId { get; set; }
        //[Inject]
        //public ITermService TermService { get; set; }
        public int Count { get; set; } = 1;
        public IEnumerable<DefinitionViewModel> Definations { get; set; }
        
        protected override Task OnInitializedAsync()
        {
            //Definations = (await TermService.GetAllTerms()).ToList();
            return base.OnInitializedAsync();
        }
    }
}
