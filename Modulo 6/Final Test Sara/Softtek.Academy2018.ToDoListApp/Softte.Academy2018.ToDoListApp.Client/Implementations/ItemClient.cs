using Softte.Academy2018.ToDoListApp.Client.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Softtek.Academia2018.ToDoListApp.DTO;
using System.Net.Http;
using Newtonsoft.Json;

namespace Softte.Academy2018.ToDoListApp.Client.Implementations
{
    public class ItemClient : IItemClient
    {
        private readonly Uri uri;
        private readonly MediaTypeWithQualityHeaderValue mediaType;

        public ItemClient()
        {
            uri = new Uri("http://localhost:2048/");
            mediaType = new MediaTypeWithQualityHeaderValue("application/json");
        }

        public async Task<ItemDTO> GetItembyId(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);

                var response = await client.GetAsync($"Items/{id}");

                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var user = JsonConvert.DeserializeObject<ItemDTO>(content);

                return user;
            }
        }

        public async Task<ICollection<ItemDTO>> GetAllItems()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);

                var response = await client.GetAsync("Items");

                string content = await response.Content.ReadAsStringAsync();
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var items = JsonConvert.DeserializeObject<List<ItemDTO>>(content);

                return items;
            }
        }

        public async Task<bool> AddItem(ItemDTO itemDTO)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);

                var response = await client.PostAsJsonAsync($"Items", itemDTO);

                return response.IsSuccessStatusCode;

            }
        }

        public async Task<bool> UpdateItem(ItemDTO itemDTO)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = uri;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(mediaType);

                var response = await client.PutAsJsonAsync($"Items", itemDTO);

                return response.IsSuccessStatusCode;

            }
        }
    }
}
