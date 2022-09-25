using Glossary.UI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.services
{
    public interface ITermService
    {
        Task<IEnumerable<TermsViewModel>> GetAllTerms();
        Task<TermsViewModel> GetTermBy(int Term);
        Task<IEnumerable<TermsViewModel>> SearchTerms(string word);
        Task CreateTerm(EditTermDefinationViewModel termDefination);
        Task UpdateTerm(EditTermDefinationViewModel termDefination);
        Task Delete(long termId);
    }
}
