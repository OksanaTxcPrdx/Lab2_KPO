namespace Lab2_KPO.Services;

public interface IMathExpressionValidator
{
    public bool TryAddChar(char c);
    public bool CanAddChar(char c);
}