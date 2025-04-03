using System.Windows;

namespace Lab2_KPO;

public static class CalculatorButtonFactory
{
    public static CalculatorButton CreateButton(char op, string content, Style style, Action<char>? onClick)
    {
        return op switch
        {
            >= '0' and <= '9' => new NumberButton(op, style, onClick),
            '^' or '/' or '*' or '-' or '+' or '(' or ')' or '.' => new OperationButton(op, content, style, onClick),
            _ => new SpecialButton(op, content, style, onClick)
        };
    }
}
