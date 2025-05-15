using Avalonia.Controls;
using Avalonia.Controls.Chrome;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AvaloniaApplication1.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public ObservableCollection<MusicItem> Tracks { get; set; } = new();

        public string? Title { get; set; }
        public string? Artist { get; set; }

        private readonly AuthService _authService = new();
        private readonly YandexMusicService _musicService = new();

        [RelayCommand]
        private async Task Login()
        {
            

            var token = await _authService.GetAccessTokenAsync();
            if (!string.IsNullOrEmpty(token))
            {
                var tracks = await _musicService.GetUserTracksAsync(token);
                Tracks.Clear();
                foreach (var track in tracks)
                {
                    Tracks.Add(track);
                }
            }


            Tracks = new ObservableCollection<MusicItem>
            {
            new MusicItem { Title = "Test Track", Artist = "Test Artist" },
            new MusicItem { Title = "Another Track", Artist = "Another Artist" }
            };

            Title = Tracks[0].Title;
            Artist = Tracks[0].Artist;

            
        }
    }
}
