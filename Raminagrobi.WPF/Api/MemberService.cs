using Newtonsoft.Json;
using Raminagrobis.Api.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Raminagrobis.WPF.Api
{
    public class MemberService
    {

        private string _baseUrl = "";
        private HttpClient _httpClient;

        public MemberService(string baseUrl, HttpClient httpClient)
        {
            _baseUrl = baseUrl;
            _httpClient = new HttpClient();
        }

        public IEnumerable<MemberResponse> GetAll()
        {
            try
            {
                HttpResponseMessage response = _httpClient.GetAsync($"{_baseUrl}/Member/GetAll").Result;
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;
                // Above three lines can be replaced with new helper method below
                // string responseBody = await client.GetStringAsync(uri);

                var result = JsonConvert.DeserializeObject<IEnumerable<MemberResponse>>(responseBody);

#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
                return result;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
                return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
            }
#pragma warning disable CS0168 // La variable 'ex' est déclarée, mais jamais utilisée
            catch (Exception ex)
#pragma warning restore CS0168 // La variable 'ex' est déclarée, mais jamais utilisée
            {
#pragma warning disable CS8603 // Existence possible d'un retour de référence null.
                return null;
#pragma warning restore CS8603 // Existence possible d'un retour de référence null.
            }
        }
    }
}
