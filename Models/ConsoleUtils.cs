using System;
using System.Globalization;

internal static class ConsoleUtils
{
    public static string ReadNonEmpty(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(s))
                return s.Trim();

            Console.WriteLine("Valor obrigatório. Tente novamente.");
        }
    }

    public static string ReadOptional(string prompt)
    {
        Console.Write(prompt);
        var s = Console.ReadLine();
        return (s ?? "").Trim();
    }

    public static int ReadInt(string prompt, int min = int.MinValue, int? max = null)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = Console.ReadLine();
            int v;
            if (int.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, out v)
                && v >= min && (!max.HasValue || v <= max.Value))
                return v;

            var faixa = max.HasValue ? $"entre {min} e {max}" : $">= {min}";
            Console.WriteLine($"Informe um número inteiro válido {faixa}.");
        }
    }

    public static decimal ReadDecimal(string prompt, decimal min = decimal.MinValue, decimal? max = null)
    {
        while (true)
        {
            Console.Write(prompt);
            var s = (Console.ReadLine() ?? "").Replace(".", ","); // aceita . ou ,
            decimal v;
            if (decimal.TryParse(s, NumberStyles.Number, CultureInfo.CurrentCulture, out v)
                && v >= min && (!max.HasValue || v <= max.Value))
                return v;

            var faixa = max.HasValue ? $"entre {min} e {max}" : $">= {min}";
            Console.WriteLine($"Informe um valor decimal válido {faixa} (use vírgula para centavos).");
        }
    }

    public static void Pause()
    {
        Console.Write("\nPressione ENTER para continuar...");
        Console.ReadLine();
    }
}
