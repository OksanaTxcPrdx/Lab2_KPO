using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Lab2_KPO.Services;
using Microsoft.Extensions.Configuration;

namespace Lab2_KPO;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IConfiguration? Configuration { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        try
        {
            // Загрузка конфигурации с обработкой случая отсутствия файла
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            Configuration = builder.Build();
            // Инициализация сервиса конфигурации
            ConfigurationService.Initialize(Configuration);

            // Если конфигурация недействительна, можно показать предупреждение
            if (!ConfigurationService.IsConfigurationValid)
            {
                MessageBox.Show(
                    "Файл конфигурации отсутствует или содержит некорректные данные. Будут использованы значения по умолчанию.",
                    "Предупреждение",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"Ошибка при загрузке конфигурации: {ex.Message}\nБудут использованы значения по умолчанию.",
                "Ошибка",
                MessageBoxButton.OK,
                MessageBoxImage.Error);

            // Инициализируем сервис с пустой конфигурацией
            ConfigurationService.Initialize(null);
        }

        base.OnStartup(e);
    }
}