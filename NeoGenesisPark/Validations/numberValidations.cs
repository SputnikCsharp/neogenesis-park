partial class Program
{
    static int IntValidator()
    {
        bool isValid;
        int number;
        do
        {
            string? input = Console.ReadLine();
            isValid = int.TryParse(input, out number);
        
            if (!isValid || number < 0)
            {
                Console.Write("Invalid type of number, insert again the number> ");
            }
        } while (!isValid || number < 0);
        
        return number;
    }

    static double doubleValidator()
    {
        bool isValid;
        double number;
        do
        {
            string? input = Console.ReadLine();
            isValid = double.TryParse(input, out number);
        
            if (!isValid || number < 0)
            {
                Console.Write("Just numbers, insert again» ");
            }
        } while (!isValid || number < 0);
        return number;
    }
}