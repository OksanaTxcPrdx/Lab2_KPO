using Lab2_KPO.Services;

namespace Lab2_KPO.Commands;

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