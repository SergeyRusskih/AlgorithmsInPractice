using System;
using System.Collections.Generic;
using Xunit;

namespace StringProcessing.Parsing
{
    public class MathExpression
    {
        [Theory]
        [InlineData("2 + 2 - 1", 3)]
        [InlineData("1 - 2 / 2", 0)]
        [InlineData("1 + 6 / 2 - ( 2 * 5 + 1 ) * 2", -18)]
        [InlineData("1 + 4 / 2 * ( 2 - 5 * 2 ) + 2", -13)]
        [InlineData("1 + 6 / 2 - ( 2 * ( 5 + 1 ) ) * 2", -20)]
        public void Should_Calculate_Properly(string expr, decimal expected)
        {
            var result = Calculate(expr);
            Assert.Equal(expected, result);
        }

        private decimal Calculate(string expression)
        {
            var operators = new Stack<string>();
            var numbers = new Stack<decimal>();

            foreach (string token in expression.Split(' '))
            {
                if (int.TryParse(token, out var number))
                {
                    numbers.Push(number);
                }
                else if (AllowedOperators.TryGetValue(token, out var op1))
                {
                    var tempOperators = new Stack<string>();
                    var tempNumbers = new Stack<decimal>();

                    while (operators.Count > 0 && AllowedOperators.TryGetValue(operators.Peek(), out var op2))
                    {
                        if (op1 < op2)
                        {
                            tempOperators.Push(operators.Pop());
                            tempNumbers.Push(numbers.Pop());

                            if (tempNumbers.Count == 1)
                                tempNumbers.Push(numbers.Pop());
                        }
                        else
                        {
                            break;
                        }
                    }

                    while (tempOperators.Count > 0)
                        EvaluateReverse(tempNumbers, tempOperators.Pop());

                    if (tempNumbers.Count > 0)
                        numbers.Push(tempNumbers.Pop());

                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    string top = "";
                    while (operators.Count > 0 && (top = operators.Pop()) != "(")
                        EvaluateDirect(numbers, top);

                    if (top != "(")
                        throw new ArgumentException("No matching left parenthesis.");
                }
            }

            while (operators.Count > 0)
            {
                var top = operators.Pop();
                if (!AllowedOperators.ContainsKey(top))
                    throw new ArgumentException("No matching right parenthesis.");

                EvaluateDirect(numbers, top);
            }

            return numbers.Pop();
        }

        private void EvaluateDirect(Stack<decimal> numbers, string top)
        {
            var val1 = numbers.Pop();
            var val2 = numbers.Pop();

            numbers.Push(Evaluate(val1, val2, top));
        }

        private void EvaluateReverse(Stack<decimal> numbers, string top)
        {
            var val1 = numbers.Pop();
            var val2 = numbers.Pop();

            numbers.Push(Evaluate(val2, val1, top));
        }

        private decimal Evaluate(decimal val1, decimal val2, string top)
        {
            switch (top)
            {
                case "+":
                    return val2 + val1;
                case "-":
                    return val2 - val1;
                case "*":
                    return val2 * val1;
                case "/":
                    return val2 / (decimal)val1;
                default:
                    throw new NotImplementedException();
            }
        }

        private static readonly Dictionary<string, int> AllowedOperators = new Dictionary<string, int>
        {
            { "*", 3 },
            { "/", 3 },
            { "+", 2 },
            { "-", 2 }
        };
    }
}