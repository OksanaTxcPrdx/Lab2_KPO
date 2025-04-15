
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2_KPO.Services;
using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO.ViewModels;

public partial class CalculatorViewModel: ObservableObject
{
    private readonly ICalculator _calculator = new Calculator();
    private readonly MathExpressionValidator _validator = new();

    [ObservableProperty]
    private string _expression = "";

    [ObservableProperty]
    private string _result = "";

    public CalculatorViewModel()
    {
        License.iConfirmNonCommercialUse("Used for educational purposes to implement a calculator application");
    }

    [RelayCommand]
    private void AddChar(string symbol)
    {
        if (string.IsNullOrEmpty(symbol) || !_validator.TryAddChar(symbol[0])) return;
        Expression = _validator.Expression;
        Calculate();
    }

    [RelayCommand]
    private void Backspace()
    {
        if (_validator.RemoveLastChar())
        {
            Expression = _validator.Expression;
            Calculate();
        }
    }

    [RelayCommand]
    private void Clear()
    {
        _validator.Clear();
        Expression = "0";
        Result = "";
    }


    private void Calculate()
    {
        try
        {
            double value = _calculator.Compute(_validator.Expression);
            Result = Math.Round(value, 5).ToString();
        }
        catch
        {
            Result = "Error";
        }
    }
}