using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Lab2_KPO.Services;
public static class ConfigurationService
{
  private static readonly int DefaultWindowHeight = 550;
  private static readonly int DefaultWindowWidth = 450;
  private static readonly string DefaultTheme = "Boys";

  private static IConfiguration? _configuration;
  private static bool _isConfigurationValid = false;

  public static void Initialize(IConfiguration? configuration)
  {
    _configuration = configuration;
    ValidateConfiguration();
  }

  public static int WindowHeight => GetValue("AppSettings:WindowHeight", DefaultWindowHeight);
  public static int WindowWidth => GetValue("AppSettings:WindowWidth", DefaultWindowWidth);
  public static string Theme => GetValue("AppSettings:Theme", DefaultTheme);

  public static bool IsBoysMode => Theme.Equals("Boys", StringComparison.OrdinalIgnoreCase);
  public static bool IsConfigurationValid => _isConfigurationValid;

  private static void ValidateConfiguration()
  {
    try
    {
      if (_configuration == null)
      {
        _isConfigurationValid = false;
        return;
      }

      // Проверяем наличие секции AppSettings
      var appSettings = _configuration.GetSection("AppSettings");
      if (!appSettings.Exists())
      {
        _isConfigurationValid = false;
        return;
      }

      // Валидируем высоту
      int height = GetValue("AppSettings:WindowHeight", DefaultWindowHeight);
      if (height < 300 || height > 1080)
      {
        // Некорректное значение, будем использовать значение по умолчанию
        height = DefaultWindowHeight;
      }

      // Валидируем ширину
      int width = GetValue("AppSettings:WindowWidth", DefaultWindowWidth);
      if (width < 300 || width > 1920)
      {
        // Некорректное значение, будем использовать значение по умолчанию
        width = DefaultWindowWidth;
      }

      // Проверяем тему
      string theme = GetValue("AppSettings:Theme", DefaultTheme);
      if (!theme.Equals("Boys", StringComparison.OrdinalIgnoreCase) && 
        !theme.Equals("Girls", StringComparison.OrdinalIgnoreCase))
      {
        // Некорректное значение, будем использовать значение по умолчанию
        theme = DefaultTheme;
      }

      _isConfigurationValid = true;
    }
    catch
    {
      _isConfigurationValid = false;
    }
  }

  private static T GetValue<T>(string key, T defaultValue = default)
  {
    try
    {
      if (_configuration == null)
        return defaultValue;

      var value = _configuration[key];
      if (string.IsNullOrEmpty(value))
        return defaultValue;

      return (T)Convert.ChangeType(value, typeof(T));
    }
    catch
    {
      return defaultValue;
    }
  }
}
