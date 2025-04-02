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

        new CalculatorVisualizationBuilder()
            .AddCalculatorOperator("xʸ", '^', BtnCalculator_Click)
            .AddCalculatorOperator("÷",'/', BtnCalculator_Click)
            .AddCalculatorOperator("×",'*', BtnCalculator_Click)
            .AddCalculatorOperator("⌫",' ', BtnBackSpace_Click)
            
            .AddCalculatorOperator("7",'7', BtnCalculator_Click)
            .AddCalculatorOperator("8",'8', BtnCalculator_Click)
            .AddCalculatorOperator("9",'9', BtnCalculator_Click)
            .AddCalculatorOperator("-",'-', BtnCalculator_Click)
            
            .AddCalculatorOperator("4",'4', BtnCalculator_Click)
            .AddCalculatorOperator("5",'5', BtnCalculator_Click)
            .AddCalculatorOperator("6",'6', BtnCalculator_Click)
            .AddCalculatorOperator("+",'+', BtnCalculator_Click)
            
            .AddCalculatorOperator("1",'1', BtnCalculator_Click)
            .AddCalculatorOperator("2",'2', BtnCalculator_Click)
            .AddCalculatorOperator("3",'3', BtnCalculator_Click)
            .AddCalculatorOperator("(",'(', BtnCalculator_Click)
            
            .AddCalculatorOperator("С",' ', BtnClear_Click)
            .AddCalculatorOperator("0",'0', BtnCalculator_Click)
            .AddCalculatorOperator(",",',', BtnCalculator_Click)
            .AddCalculatorOperator(")",')', BtnCalculator_Click)
            
            .Build(GridCalculatorOperator, (Style)FindResource("SquareButtonStyle")!);
    }

    private void BtnCalculator_Click(char usesOperator)
    {
        if(!_expressionValidator.TryAddChar(usesOperator))
            return;
        
        CalculateExpression();
    }
    private void BtnBackSpace_Click(char s)
    {
        if(_expressionValidator.RemoveLastChar())
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