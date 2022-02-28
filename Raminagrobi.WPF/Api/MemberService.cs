﻿using Newtonsoft.Json;
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

                return result;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
