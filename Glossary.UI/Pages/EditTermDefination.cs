using Glossary.UI.Data;
using Glossary.UI.services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.Pages
{
    public partial class EditTermDefination
    {
        [Parameter]
        public string TermId { get; set; }
        [Inject]
        public ITermService TermService { get; set; }

        protected string Message { get; set; }
        protected string StatusClass { get; set; }
        public bool Saved { get; set; }

        public EditTermDefinationViewModel EditTermDefinationViewModel { get; set; } = new EditTermDefinationViewModel();
        protected override async Task OnInitializedAsync()
        {
            Saved = false;
            if (TermId != null)
            {
                var result = (await TermService.GetTermBy(int.Parse(TermId)));
                EditTermDefinationViewModel.WordOrPhrase = result.WordOrPPhrase;
            }   
        }

        protected async Task HandleValidSubmit()
        {
            if (TermId != null)
            {
                await TermService.UpdateTerm(EditTermDefinationViewModel);
            }
            else {
                
                await TermService.CreateTerm(EditTermDefinationViewModel);
            } 
        }

        protected async Task HandleInValidSubmit()
        {
            Message = "Invalid submit";
            Saved = true;
        }
    }  
}
