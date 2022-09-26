using Glossary.UI.Data;
using Glossary.UI.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.Pages
{
    public partial class Terms
    {
        public List<TermsViewModel> TermList { get; set; }
        [Inject]
        public ITermService TermService { get; set; }
        protected async override Task OnInitializedAsync()
        {
            TermList = (await TermService.GetAllTerms()).ToList();
        }

        protected async Task DeleteTermDefination(int id)
        {
            await TermService.Delete(id);
        }
    }
}
