using System.Windows;
using System.Windows.Controls;

namespace Lab2_KPO;

public abstract class CalculatorButton : Button
{
    public char Operator { get; }
    public event Action<char>? OnClick;

    protected CalculatorButton(char op, string content, Style style, Action<char>? onClick = null)
    {
        Operator = op;
        Content = content;
        Style = style;
        OnClick = onClick;
        Click += (s, e) => OnClick?.Invoke(Operator);
    }
}

public class NumberButton : CalculatorButton
{
    public NumberButton(char number, Style style, Action<char>? onClick = null) 
        : base(number, number.ToString(), style,onClick) {}
}

public class OperationButton : CalculatorButton
{
    public OperationButton(char op, string content, Style style, Action<char>? onClick = null) 
        : base(op, content, style,onClick) {}
}

public class SpecialButton : CalculatorButton
{
    public SpecialButton(char op, string content, Style style, Action<char>? onClick = null) 
        : base(op, content, style,onClick) {}
}