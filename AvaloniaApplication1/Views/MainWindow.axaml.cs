using Avalonia.Controls;
using Avalonia.Markup.Xaml.Templates;
using AvaloniaApplication1.ViewModels;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
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

            var box = MessageBoxManager
.GetMessageBoxStandard("Caption", "Are you sure you would like to delete appender_replace_page_1?",
    ButtonEnum.YesNo);
            var result = box.ShowAsync();
        }

    }
}