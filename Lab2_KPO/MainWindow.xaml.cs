using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Lab2_KPO;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ICalculator _calculator = new Calculator();
    private readonly char[] _mathSigns = ['-', '+', '*', '/'];
    private readonly StringBuilder _currentExpression = new("");

    public MainWindow()
    {
        InitializeComponent();

        CalculateExpression();
    }

    private void CalculateExpression()
    {
        double result = Math.Round(_calculator.Compute(_currentExpression.ToString()),5);
        tbInputExpression.Text = _currentExpression + " = " + result.ToString().PadLeft(10);
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        _currentExpression.Clear();
        CalculateExpression();
    }

    private void BtnDivision_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '(' || _currentExpression[^1] == ')')
            return;

        if (_mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('/');
        CalculateExpression();
    }

    private void BtnMultiplication_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '(' || _currentExpression[^1] == ')')
            return;

        if (_mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('*');
        CalculateExpression();
    }

    private void BtnBackSpace_Click(object sender, RoutedEventArgs e)
    {
        if(_currentExpression.Length>0)
            _currentExpression.Length--;
        CalculateExpression();
    }

    private void BtnNumber_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            string number = button.Content.ToString();
            _currentExpression.Append(number);
            CalculateExpression();
        }
    }

    private void btnSubtraction_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length > 0 && _mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('-');
        CalculateExpression();
    }

    private void btnSummation_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length >0 && _mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('+');
        CalculateExpression();
    }

    private void btnEqual_Click(object sender, RoutedEventArgs e)
    {

    }


    private void Button_Click(object sender, RoutedEventArgs e)
    {
        _currentExpression.Append(".");
        CalculateExpression();
    }
}