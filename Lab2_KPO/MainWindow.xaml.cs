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
        var buttonStyle = (Style)FindResource("SquareButtonStyle");
        InitializeCalculatorUI(buttonStyle);
    }

    private void InitializeCalculatorUI(Style buttonStyle)
    {
        var buttons = new List<CalculatorButton>
        {
            new OperationButton('^', "xʸ", buttonStyle,BtnCalculator_Click),
            new OperationButton('/', "÷", buttonStyle,BtnCalculator_Click),
            new OperationButton('*', "×", buttonStyle,BtnCalculator_Click),
            new SpecialButton(' ', "⌫", buttonStyle,BtnBackSpace_Click),

            new NumberButton('7', buttonStyle,BtnCalculator_Click),
            new NumberButton('8', buttonStyle,BtnCalculator_Click),
            new NumberButton('9', buttonStyle,BtnCalculator_Click),
            new OperationButton('-', "-", buttonStyle,BtnCalculator_Click),
            
            new NumberButton('4', buttonStyle,BtnCalculator_Click),
            new NumberButton('5', buttonStyle,BtnCalculator_Click),
            new NumberButton('6', buttonStyle,BtnCalculator_Click),
            new OperationButton('+', "+", buttonStyle,BtnCalculator_Click),
            
            new NumberButton('1', buttonStyle,BtnCalculator_Click),
            new NumberButton('2', buttonStyle,BtnCalculator_Click),
            new NumberButton('3', buttonStyle,BtnCalculator_Click),
            new OperationButton('(', "(", buttonStyle,BtnCalculator_Click),
            
            new SpecialButton(' ',"C",buttonStyle,BtnClear_Click),
            new NumberButton('0', buttonStyle,BtnCalculator_Click),
            new OperationButton('.',",", buttonStyle,BtnCalculator_Click),
            new OperationButton(')', ")", buttonStyle,BtnCalculator_Click),
        };
        
        int columns = 4;
        for (int i = 0; i < buttons.Count; i++)
        {
            var button = buttons[i];

            Grid.SetRow(button, i / columns);
            Grid.SetColumn(button, i % columns);
            GridCalculatorOperator.Children.Add(button);
        }
    }

    private void BtnCalculator_Click(char usesOperator)
    {
        if (!_expressionValidator.TryAddChar(usesOperator))
            return;

        CalculateExpression();
    }

    private void BtnBackSpace_Click(char s)
    {
        if (_expressionValidator.RemoveLastChar())
            CalculateExpression();
    }

    private void BtnClear_Click(char s)
    {
        _expressionValidator.Clear();
        tbInputExpression.Text = "0";
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
}