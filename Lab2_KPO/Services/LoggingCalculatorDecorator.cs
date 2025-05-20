namespace Lab2_KPO.Services;

public class LoggingCalculatorDecorator(ICalculator calculator) : CalculatorDecorator(calculator)
{
    public override double Compute(string expression)
    {
        Console.WriteLine($"Вычисление выражения: {expression}");
        double result = base.Compute(expression);
        Console.WriteLine($"Результат: {result}");
        return result;
    }
}