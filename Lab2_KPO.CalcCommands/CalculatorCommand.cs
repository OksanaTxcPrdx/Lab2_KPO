using Lab2_KPO.CalcValidation;

namespace Lab2_KPO.CalcCommands;

public abstract class CalculatorCommand : ICalculatorCommand
{
    protected readonly MathExpressionValidator Validator;

    protected CalculatorCommand(MathExpressionValidator validator)
    {
        Validator = validator;
    }

    public abstract void Execute();
    public virtual bool CanExecute() => true;
    public virtual void Undo() { }
}
