using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;
using Lab2_KPO.Services;
using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly MediaPlayer _clickSoundPlayer = new MediaPlayer();
    public MainWindow()
    {
        InitializeComponent();
        // Устанавливаем размеры окна из конфигурации
        this.Height = ConfigurationService.WindowHeight;
        this.Width = ConfigurationService.WindowWidth;
            
        // Если нужно установить минимальные размеры
        this.MinHeight = 300;
        this.MinWidth = 300;
    }

    private void SetWindowSize()
    {
        // Получаем настройки из конфигурации
        this.Height = ConfigurationService.WindowHeight;
        this.Width = ConfigurationService.WindowWidth;

       
    }
}