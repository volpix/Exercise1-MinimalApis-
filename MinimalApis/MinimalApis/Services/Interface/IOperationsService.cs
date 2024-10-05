namespace MinimalApis.Services.Interface
{
    /// <summary>
    /// Operations service interface.
    /// </summary>
    public interface IOperationsService
    {
        double Addition(double a, double b);
        double Division(double a, double b);
        double Subtraction(double a, double b);
        double Multiplication(double a, double b);

    }
}
