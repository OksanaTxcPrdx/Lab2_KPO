namespace Lab2_KPO.Commands;

public interface ICalculatorCommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}