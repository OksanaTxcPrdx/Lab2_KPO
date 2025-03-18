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
    private readonly MathExpressionValidator _expressionValidator = new();

    public MainWindow()
    {
        License.iConfirmNonCommercialUse("Used for educational purposes to implement a calculator application");

        InitializeComponent();
    }

    private void tbInputExpression_TextChanged(object sender, TextChangedEventArgs e)
    {
        tbInputExpression.ScrollToHorizontalOffset(tbInputExpression.ExtentWidth);
    }

    private void CalculateExpression()
    {
        try
        {
            double result = Math.Round(_calculator.Compute(_expressionValidator.Expression), 5);

            tbResult.Text = result.ToString();
        }
        catch
        {
            // ignored
        }

        tbInputExpression.Text = _expressionValidator.Expression;
    }

    private void BtnClear_Click(object sender, RoutedEventArgs e)
    {
        _expressionValidator.Clear();
        tbInputExpression.Text = "0";
    }

    private void BtnDivision_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('/'))
            return;
        
        CalculateExpression();
    }

    private void BtnMultiplication_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('*'))
            return;
        
        CalculateExpression();
    }

    private void BtnBackSpace_Click(object sender, RoutedEventArgs e)
    {
        if(_expressionValidator.RemoveLastChar())
            CalculateExpression();
    }

    private void BtnNumber_Click(object sender, RoutedEventArgs e)
    {
        if (sender is not Button { Content: string number }) return;

        if(!_expressionValidator.TryAddChar(number[^1]))
            return;
        
        CalculateExpression();
    }

    private void btnSubtraction_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('-'))
            return;
        
        CalculateExpression();
    }

    private void btnSummation_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('+'))
            return;
        
        CalculateExpression();
    }


    private void btnPointBracket_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('.'))
            return;
        
        CalculateExpression();
    }

    private void btnOpenBracket_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('('))
            return;
        
        CalculateExpression();
    }

    private void btnCloseBracket_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar(')'))
            return;
        
        CalculateExpression();
    }

    private void btnExponential_Click(object sender, RoutedEventArgs e)
    {
        if(!_expressionValidator.TryAddChar('^'))
            return;
        
        CalculateExpression();
    }
}