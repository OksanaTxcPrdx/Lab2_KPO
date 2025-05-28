using System.Windows;
using Lab2_KPO.Services;

namespace Lab2_KPO.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
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