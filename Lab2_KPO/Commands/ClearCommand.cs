using Lab2_KPO.Services;

namespace Lab2_KPO.Commands;

public class ClearCommand(MathExpressionValidator validator) : CalculatorCommand(validator)
{
    private string _previousExpression;

    public override void Execute()
    {
        _previousExpression = Validator.Expression;
        Validator.Clear();
    }

    public override void Undo()
    {
        foreach (var c in _previousExpression)
        {
            Validator.TryAddChar(c);
        }
    }
}