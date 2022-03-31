using AssetManagementUI.UI.Models.ApiModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AssetManagementUI.UI.Provider
{
    public class ComboboxFillerProvider
    {
        HttpClient _client;

        public ComboboxFillerProvider(HttpClient client)
        {
            _client = client;
        }

       public async Task<ComboboxDTO> GetComboboxFiller()
        {
            var value = await _client.GetAsync("ComboboxFill/comboboxfiller");
            if (value.IsSuccessStatusCode)
            {
                var content = await value.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ComboboxDTO>(content);
                return data;
            }
            return null;
        }
    }
}
