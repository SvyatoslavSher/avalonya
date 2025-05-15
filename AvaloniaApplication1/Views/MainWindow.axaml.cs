using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using AvaloniaApplication1.ViewModels;
using System;
using Yandex.Music.Api;
using Yandex.Music.Client;

namespace AvaloniaApplication1.Views
{
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();

            
        }
    }
}