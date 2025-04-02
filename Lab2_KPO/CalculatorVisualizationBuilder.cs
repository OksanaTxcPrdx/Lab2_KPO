using System.Windows;
using System.Windows.Controls;

namespace Lab2_KPO;

public class CalculatorVisualizationBuilder
{
    public delegate void OperatorInvoke(char usesOperator);
    
    private readonly List<(int sequenceNumber, string visualizationOperator, char usesOperator, OperatorInvoke onOperatorInvoke)>
        _operators = [];

    private int _countButton = 0;


    public CalculatorVisualizationBuilder AddCalculatorOperator(
        string visualizationOperator,
        char usesOperator,
        OperatorInvoke onOperatorInvoke)
    {
        _operators.Add((_countButton, visualizationOperator, usesOperator, onOperatorInvoke));
        _countButton++;

        return this;
    }
    
    public void Build(Grid grid, Style? buttonStyle = null)
    {
        int m = grid.ColumnDefinitions.Count;

        for (int i = 0; i < _operators.Count; i++)
        {
            var (row, column) = SequenceNumberToGridPosition(_operators[i].sequenceNumber, m);

            Button newButton = new Button();

            Grid.SetRow(newButton, row);
            Grid.SetColumn(newButton, column);
            newButton.Content = _operators[i].visualizationOperator;
            newButton.Style = buttonStyle;
            var usesOperator = _operators[i].usesOperator;
            var onOperatorInvoke = _operators[i].onOperatorInvoke;
            newButton.Click += (sender, args) => { onOperatorInvoke(usesOperator); };

            grid.Children.Add(newButton);
        }
    }


    private (int row, int column) SequenceNumberToGridPosition(int sequenceNumber, int m)
    {
        return (sequenceNumber / m, sequenceNumber % m);
    }
}