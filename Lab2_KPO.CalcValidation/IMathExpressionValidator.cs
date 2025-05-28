namespace Lab2_KPO.CalcValidation;

public interface IMathExpressionValidator
{
    public bool TryAddChar(char c);
    public bool CanAddChar(char c);
    public string Expression { get; }
    public int CountOpenBracket { get; }
    public void Clear();
    public bool RemoveLastChar();
}
