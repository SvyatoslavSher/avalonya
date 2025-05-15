using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tmds.DBus.Protocol;
using Avalonia.Dialogs;
using Avalonia.Controls.ApplicationLifetimes;

namespace AvaloniaApplication1.Services
{
    public class AuthService
    {
        private const string AuthUrl = "https://oauth.yandex.ru/authorize";
        private const string ClientId = "80c71c0bc10a44e8b6b372130b8dcce8";

        public async Task<string> GetAccessTokenAsync()
        {
            var authUri = $"{AuthUrl}?response_type=token&client_id={ClientId}&redirect_uri=http://localhost:8080&display=popup";
            Process.Start(new ProcessStartInfo(authUri) { UseShellExecute = true });

            return await ListenForToken();
        }


        private async Task<string> ListenForToken()
        {
            var listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/");
            listener.Start();

            var context = await listener.GetContextAsync();
            var request = context.Request;

            // Пример URL: http://localhost:8080/#access_token=TOKEN_HERE&token_type=bearer&expires_in=...
            var fragment = request.Url.Fragment;
            var accessToken = fragment
                .TrimStart('#')
                .Split('&')[0]
                .Replace("access_token=", "");

            var response = context.Response;
            var buffer = Encoding.UTF8.GetBytes("<html><body>Authorized! You can close this window.</body></html>");
            response.ContentLength64 = buffer.Length;
            await response.OutputStream.WriteAsync(buffer, 0, buffer.Length);
            response.Close();

            


            return accessToken;
        }
    }
}
