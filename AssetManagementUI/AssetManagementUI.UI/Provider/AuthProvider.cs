using AssetManagementUI.UI.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Provider
{
    public class AuthProvider
    {
        HttpClient _client;

        public AuthProvider(HttpClient client)
        {
            _client = client;
        }

        public async Task<PersonnelWithTokenDTO> Login(string userName, string password)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(new LoginDTO()
            {
                Username = userName,
                Password = password
            }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            var returnedValue = await _client.PostAsync("auth/login", content);
            PersonnelWithTokenDTO dto = new PersonnelWithTokenDTO();
            if (returnedValue.IsSuccessStatusCode)
            {
                var value = await returnedValue.Content.ReadAsStringAsync();
                dto = JsonConvert.DeserializeObject<PersonnelWithTokenDTO>(value);
               
            }
            else
            {
                dto = null;
            }
            return dto;
        }
    }
}
