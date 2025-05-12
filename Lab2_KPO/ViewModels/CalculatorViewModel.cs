
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Lab2_KPO.Commands;
using Lab2_KPO.Services;
using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO.ViewModels;

public partial class CalculatorViewModel : ObservableObject
{
    private readonly ICalculator _calculator = new Calculator();
    private readonly MathExpressionValidator _validator = new();
    private readonly CommandInvoker _commandInvoker = new();

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
        if (string.IsNullOrEmpty(symbol)) return;
        
        var command = new AddCharCommand(_validator, symbol[0]);
        _commandInvoker.ExecuteCommand(command);
        
        Expression = _validator.Expression;
        Calculate();
    }

    [RelayCommand]
    private void Backspace()
    {
        var command = new BackspaceCommand(_validator);
        _commandInvoker.ExecuteCommand(command);
        
        Expression = _validator.Expression;
        Calculate();
    }

    [RelayCommand]
    private void Clear()
    {
        var command = new ClearCommand(_validator);
        _commandInvoker.ExecuteCommand(command);
        
        Expression = string.IsNullOrEmpty(_validator.Expression) ? "0" : _validator.Expression;
        Result = "";
    }

    [RelayCommand]
    private void Undo()
    {
        _commandInvoker.Undo();
        Expression = _validator.Expression;
        Calculate();
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
