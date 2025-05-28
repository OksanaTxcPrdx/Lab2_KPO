using Lab2_KPO.CalcValidation;

namespace Lab2_KPO.CalcCommands;

public class AddCharCommand : CalculatorCommand
{
    private readonly char _character;
    
    public AddCharCommand(MathExpressionValidator validator, char character) : base(validator)
    {
        _character = character;
    }
    
    public override void Execute()
    {
        Validator.TryAddChar(_character);
    }

    public override bool CanExecute() => Validator.CanAddChar(_character);

    public override void Undo()
    {
        Validator.RemoveLastChar();
    }
}
