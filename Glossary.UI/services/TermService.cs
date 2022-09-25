using Glossary.UI.Data;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
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
        public async Task CreateTerm(EditTermDefinationViewModel termDefination)
        {
            var jsonPayload = new StringContent(JsonSerializer.Serialize(termDefination),
                Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"api/Terms", jsonPayload);

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException("Some thing went wrong..");
            }
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

        public async Task<TermsViewModel> GetTermBy(int Term)
        {
            return await JsonSerializer.DeserializeAsync<TermsViewModel>
                (await _httpClient.GetStreamAsync($"api/Terms/{Term}"), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Task<IEnumerable<TermsViewModel>> SearchTerms(string word)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateTerm(EditTermDefinationViewModel termDefination)
        {
            var jsonPayload = new StringContent(JsonSerializer.Serialize(termDefination),
                Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"api/Terms/{termDefination.Id}", jsonPayload);
        }
    }
}
