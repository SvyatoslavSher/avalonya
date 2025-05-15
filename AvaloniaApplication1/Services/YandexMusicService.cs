using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AvaloniaApplication1.Services
{
    public class YandexMusicService
    {
        public async Task<List<Models.MusicItem>> GetUserTracksAsync(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"OAuth {token}");

            // Неофициальный эндпоинт (может измениться)
            var response = await client.GetAsync("https://api.music.yandex.net/users/me/likes/tracks");
            var json = await response.Content.ReadAsStringAsync();

            try
            {
                var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                var items = new List<Models.MusicItem>();

                // Это пример — реальный парсинг зависит от ответа сервера
                for (int i = 0; i < 5; i++)
                {
                    items.Add(new Models.MusicItem
                    {
                        Title = $"Track {i + 1}",
                        Artist = $"Artist {i + 1}"
                    });
                }

                return items;
            }
            catch
            {
                return new List<Models.MusicItem>();
            }
        }
    }
}
