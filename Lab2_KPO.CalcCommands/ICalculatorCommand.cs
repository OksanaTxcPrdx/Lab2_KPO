namespace Lab2_KPO.CalcCommands;

public interface ICalculatorCommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}
