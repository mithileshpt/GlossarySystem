using Glossary.UI.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Glossary.UI.services
{
    public class TermService : ITermService
    {
        private readonly HttpClient _httpClient;
        public TermService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public Task CreateTerm(TermsViewModel termDefination)
        {
            throw new NotImplementedException();
        }

        public Task Delete(long termId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TermsViewModel>> GetAllTerms()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<TermsViewModel>>
                 (await _httpClient.GetStreamAsync("api/terms"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<IEnumerable<TermsViewModel>> SearchTerms(string word)
        {
            throw new NotImplementedException();
        }

        public Task UpdateTerm(TermsViewModel term)
        {
            throw new NotImplementedException();
        }
    }
}
