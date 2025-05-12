using Lab2_KPO.Services;

namespace Lab2_KPO.Commands;

public class AddCharCommand(
    MathExpressionValidator validator, 
    char character) : CalculatorCommand(validator)
{
    public override void Execute()
    {
        Validator.TryAddChar(character);
    }

    public override bool CanExecute() => Validator.CanAddChar(character);

    public override void Undo()
    {
        Validator.RemoveLastChar();
    }
}