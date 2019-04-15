using System;
using System.IO;

public class Solution
{
    static void Main(string[] args)
    {
        var file = new StreamReader("input.txt");

        var numberOfDigits = int.Parse(Console.ReadLine());

        var digits = new int[numberOfDigits];
        for (var i = 0; i < numberOfDigits; i++)
        {
            digits[i] = int.Parse(Console.ReadLine());
        }


        Console.WriteLine("");
    }

    private static int GetNext(StreamReader file)
    {
        var s = string.Empty;

        int i = 0;

        while ((i = file.Read()) != -1)
        {
            var c = Convert.ToChar(i);
            if (char.IsDigit(c) || char.IsLetter(c))
            {
                s = s + c;
            }
            else
            {
                if (s.Trim() != string.Empty)
                    return int.Parse(s);

                s = string.Empty;
            }
        }

        if (s.Trim() != string.Empty)
            return int.Parse(s);

        throw new InvalidOperationException();
    }
}