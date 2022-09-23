using Glossary.UI.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.UI.services
{
    public interface ITermService
    {
        Task<IEnumerable<TermsViewModel>> GetAllTerms();
        Task<IEnumerable<TermsViewModel>> SearchTerms(string word);
        Task CreateTerm(TermsViewModel termDefination);
        Task UpdateTerm(TermsViewModel term);
        Task Delete(long termId);
    }
}
