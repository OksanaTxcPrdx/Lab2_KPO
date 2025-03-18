using System.Text;

namespace Lab2_KPO;

public class MathExpressionValidator : IMathExpressionValidator
{
    public string Expression => _expression.ToString();
    public int CountOpenBracket { get; private set; }

    private static readonly char[] MathOperators = ['-', '+', '*', '/', '^'];
    private readonly StringBuilder _expression = new("");

    public MathExpressionValidator()
    {
    }
    
    public MathExpressionValidator(string expression)
    {
        foreach (var c in expression)
        {
            if(!TryAddChar(c))
                throw new ArgumentException("Invalid expression");
        }
    }

    public bool TryAddChar(char c)
    {
        if (!CanAddChar(c))
            return false;

        if (c == '(')
            CountOpenBracket++;

        if (c == ')')
            CountOpenBracket--;

        _expression.Append(c);
        return true;
    }

    public bool CanAddChar(char c)
    {
        if (char.IsNumber(c))
            return true;

        if (c == '.')
            return CanAddDecimalPoint();

        if (c == '(')
            return CanAddOpenBracket();
        
        if (c == ')')
            return CanAddCloseBracket();
        
        if (c == '+' || c=='-') 
            return CanAddSimpleMathOperator();
        
        if (c == '*' || c=='/' || c == '^') 
            return CanAddHardMathOperator();

        return false;
    }

    // operators [*, /, ^]
    private bool CanAddHardMathOperator()
    {
        if (_expression.Length == 0)
            return false;

        if (_expression[^1] == '.')
            return false;

        if (IsMathOperator(_expression[^1]))
            return false;

        if (_expression[^1] == '(')
            return false;

        return true;
    }
    
    // operators [+, -]
    private bool CanAddSimpleMathOperator()
    {
        if (_expression.Length == 0)
            return true;

        if (_expression[^1] == '.')
            return false;

        if (IsMathOperator(_expression[^1]))
            return false;

        return true;
    }

    private bool CanAddOpenBracket()
    {
        if (_expression.Length == 0) return true;
        
        if (_expression[^1] != '(' && !IsMathOperator(_expression[^1]))
            return false;

        return true;
    }

    
    private bool CanAddCloseBracket()
    {
        if (_expression.Length == 0)
            return false;

        if (CountOpenBracket  == 0)
            return false;

        if (_expression[^1] == '(')
            return false; 

        if (IsMathOperator(_expression[^1]))
            return false;
        
        return true;
    }

    private bool CanAddDecimalPoint()
    {
        if (_expression.Length == 0)
            return false;

        if (!char.IsNumber(_expression[^1]))
            return false;

        for (int i = _expression.Length - 1; i >= 0; i--)
        {
            char currentChar = _expression[i];

            if (currentChar == '.')
                return false;

            if (!char.IsNumber(currentChar))
                break;
        }

        return true;
    }

    private bool IsMathOperator(char c) => MathOperators.Contains(c);

    public void Clear()
    {
        _expression.Clear();
    }

    public bool RemoveLastChar()
    {
        if (_expression.Length == 0)
            return false;

        _expression.Length--;
        
        return true;
    }
}