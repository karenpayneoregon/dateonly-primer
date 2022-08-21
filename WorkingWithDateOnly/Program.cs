using WorkingWithDateOnly.Classes;

namespace WorkingWithDateOnly
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            JsonOperations.SerializeDeserialize();

            var rule = new Rule("[green1]DateOnly examples[/]");
            AnsiConsole.Write(rule);

            DateOnlyExamples();
            Console.WriteLine();

            rule = new Rule("[turquoise2]DateTime examples[/]");
            AnsiConsole.Write(rule);
            DateTimeExamples();

            /*
             * Parse a string to DateOnly, notice the culture
             */
            Console.WriteLine();
            Console.WriteLine("Assertion to determine if a string can represent a DateOnly");
            if (DateOnly.TryParse("09/01/2022", new CultureInfo("en"), DateTimeStyles.None, out var date))
            {
                Console.WriteLine(date);
            }
            else
            {
                Console.WriteLine("Failed");
            }


            if (DateOnly.TryParse("28/09/2022", new CultureInfo("en"), DateTimeStyles.None, out var result))
            {
                Console.WriteLine(result);
            }
            else
            {
                Console.WriteLine("Failed");
            }

            Console.ReadLine();
        }
    }
}