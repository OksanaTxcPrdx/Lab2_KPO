using Lab2_KPO.Services;

namespace Lab2_KPO.Commands;

public class BackspaceCommand(MathExpressionValidator validator) : CalculatorCommand(validator)
{
    private char _removedChar;
    private bool _charRemoved;

    public override void Execute()
    {
        if (Validator.Expression.Length > 0)
        {
            _removedChar = Validator.Expression[^1];
            _charRemoved = Validator.RemoveLastChar();
        }
    }

    public override bool CanExecute() => Validator.Expression.Length > 0;

    public override void Undo()
    {
        if (_charRemoved)
        {
            Validator.TryAddChar(_removedChar);
        }
    }
}