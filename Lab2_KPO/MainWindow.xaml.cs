using System.Text;
using System.Windows;
using System.Windows.Controls;
using org.mariuszgromada.math.mxparser;

namespace Lab2_KPO;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ICalculator _calculator = new Calculator();
    private readonly char[] _mathSigns = ['-', '+', '*', '/', '^'];
    private readonly StringBuilder _currentExpression = new("");
    private int _countOpenBracket = 0;

    public MainWindow()
    {
        License.iConfirmNonCommercialUse("Used for educational purposes to implement a calculator application");

        InitializeComponent();
    }

    private void CalculateExpression()
    {
        try
        {
            double result = Math.Round(_calculator.Compute(_currentExpression.ToString()), 5);

            tbResult.Text = result.ToString();
        }
        catch (Exception ex)
        {
            // ignored
        }

        tbInputExpression.Text = _currentExpression.ToString();
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        _currentExpression.Clear();
        _countOpenBracket = 0;
        CalculateExpression();
    }

    private void BtnDivision_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;
        
        if(_currentExpression[^1] == '.')
            return;

        if (_currentExpression.Length > 2 && _mathSigns.Contains(_currentExpression[^1]) &&
            _currentExpression[^2] == '(')
            return;

        if (_mathSigns.Contains(_currentExpression[^1]))
        {
            _currentExpression.Length--;
            tbInputExpression.Text = _currentExpression.ToString();
        }

        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '(')
            return;

        _currentExpression.Append('/');
        CalculateExpression();
    }

    private void BtnMultiplication_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;
        
        if(_currentExpression[^1] == '.')
            return;

        if (_currentExpression.Length > 2 && _mathSigns.Contains(_currentExpression[^1]) &&
            _currentExpression[^2] == '(')
            return;

        if (_mathSigns.Contains(_currentExpression[^1]))
        {
            _currentExpression.Length--;
            tbInputExpression.Text = _currentExpression.ToString();
        }

        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '(')
            return;

        _currentExpression.Append('*');
        CalculateExpression();
    }

    private void BtnBackSpace_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0) 
            return;
        
        _currentExpression.Length--;
        CalculateExpression();
    }

    private void BtnNumber_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button { Content: string number })
        {
            _currentExpression.Append(number);
            CalculateExpression();
        }
    }

    private void btnSubtraction_Click(object sender, RoutedEventArgs e)
    {
        if(_currentExpression.Length == 0)
            return;
        
        if (_currentExpression[^1] == '.')
            return;
        
        if (_mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('-');
        CalculateExpression();
    }

    private void btnSummation_Click(object sender, RoutedEventArgs e)
    {
        if(_currentExpression.Length == 0)
            return;
        
        if (_currentExpression[^1] == '.')
            return;
        
        if (_mathSigns.Contains(_currentExpression[^1]))
            _currentExpression.Length--;

        _currentExpression.Append('+');
        CalculateExpression();
    }


    private void btnPointBracket_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;

        if (!char.IsNumber(_currentExpression[^1]))
            return;

        for (int i = _currentExpression.Length - 1; i >= 0; i--)
        {
            char currentChar = _currentExpression[i];

            if (currentChar == '.')
                return;

            if (!char.IsNumber(currentChar))
                break;
        }

        _currentExpression.Append(".");
        CalculateExpression();
    }

    private void btnOpenBracket_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length > 0 && !_mathSigns.Contains(_currentExpression[^1]))
            return;
        
        _currentExpression.Append("(");
        _countOpenBracket++;
        CalculateExpression();
    }

    private void btnCloseBracket_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;

        if(_countOpenBracket == 0 )
            return;
        
        if(_currentExpression[^1] == '.' )
            return;
        
        _currentExpression.Append(")");
        _countOpenBracket--;
        CalculateExpression();
    }

    private void btnExponential_Click(object sender, RoutedEventArgs e)
    {
        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '.')
            return;
        
        if (_currentExpression.Length > 2 && _mathSigns.Contains(_currentExpression[^1]) &&
            _currentExpression[^2] == '(')
            return;

        if (_mathSigns.Contains(_currentExpression[^1]))
        {
            _currentExpression.Length--;
            tbInputExpression.Text = _currentExpression.ToString();
        }

        if (_currentExpression.Length == 0)
            return;

        if (_currentExpression[^1] == '(')
            return;

        _currentExpression.Append("^");
        CalculateExpression();
    }
}