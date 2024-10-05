using MinimalApis.Services.Interface;

namespace MinimalApis.Services
{
    /// <summary>
    /// Provides basic arithmetic operations.
    /// </summary>
    public class OperationsService : IOperationsService
    {
        /// <summary>
        /// Adds two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The sum of the two numbers.</returns>
        public double Addition(double a, double b)
        {
            return a + b;
        }

        /// <summary>
        /// Divides one number by another.
        /// </summary>
        /// <param name="a">Dividend.</param>
        /// <param name="b">Divisor.</param>
        /// <returns>The quotient of the division.</returns>
        /// <exception cref="DivideByZeroException">Thrown when divisor is zero.</exception>
        public double Division(double a, double b)
        {
            return a / b;
        }

        /// <summary>
        /// Subtracts one number from another.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The result of the subtraction.</returns>
        public double Subtraction(double a, double b)
        {
            return a - b;
        }

        /// <summary>
        /// Multiplies two numbers.
        /// </summary>
        /// <param name="a">First number.</param>
        /// <param name="b">Second number.</param>
        /// <returns>The product of the two numbers.</returns>
        public double Multiplication(double a, double b)
        {
            return a * b;
        }
    }
}

