using Lab2_KPO.CalcValidation;

namespace Lab2_KPO.CalcCommands;

public class BackspaceCommand : CalculatorCommand
{
    public BackspaceCommand(MathExpressionValidator validator) : base(validator)
    {
    }

    public override void Execute()
    {
        Validator.RemoveLastChar();
    }
}
