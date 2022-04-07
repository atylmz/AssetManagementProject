using AssetManagementUI.UI.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Provider
{
    public class AssetProvider
    {
        HttpClient _client;

        public AssetProvider(HttpClient client)
        {
            _client = client;
        }
        public async Task<string> AddAsset(AssetFullDTO dto, string token = null)
        {
            if(token == null)
            {
                return "Token Not Found";
            }
            var serialized = new StringContent(JsonConvert.SerializeObject(dto));
            serialized.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            var post = await _client.PostAsync("asset/addasset", serialized);
            string result = "";
            if (post.IsSuccessStatusCode)
            {
                result = "Succesfully Added";
            }
            return result;
        }
    }
}
