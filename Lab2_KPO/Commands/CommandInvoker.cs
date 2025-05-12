namespace Lab2_KPO.Commands;

public class CommandInvoker
{
    private readonly Stack<ICalculatorCommand> _undoStack = new();

    public void ExecuteCommand(ICalculatorCommand command)
    {
        if (command.CanExecute())
        {
            command.Execute();
            _undoStack.Push(command);
        }
    }

    public void Undo()
    {
        if (_undoStack.Count > 0)
        {
            var command = _undoStack.Pop();
            command.Undo();
        }
    }

    public void ClearHistory() => _undoStack.Clear();
}