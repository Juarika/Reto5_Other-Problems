internal class Program
{
    private static void Main(string[] args)
    {
        int opc = 0;
        while (opc != 3)
        {
            Console.Clear();
            Console.WriteLine("MENU RETO 5");
            Console.WriteLine("1. SAM AND KELLY.");
            Console.WriteLine("2. Subsequences of Array.");
            Console.WriteLine("3. Salir.");
            opc = Int32.Parse(Console.ReadLine());

            switch (opc)
            {
                case 1:
                    SamAndKelly();
                    Console.ReadKey();
                    break;
                case 2:
                    Subsequences();
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine("Hasta Luego");
                    break;
                default:
                    Console.WriteLine("Invalido");
                    break;
            }
        }
    }

    public static void SamAndKelly()
    {
        Console.Write("SamDaily: ");
        int samDaily = Int32.Parse(Console.ReadLine());
        Console.Write("KellyDaily: ");
        int kellyDaily = Int32.Parse(Console.ReadLine());
        Console.Write("Difference: ");
        int difference = Int32.Parse(Console.ReadLine());

        int samSolved = samDaily + difference;
        int kellySolved = kellyDaily;

        if (samDaily >= kellyDaily)
        {
            Console.WriteLine(-1);
        }

        int day = 1;
        while (kellySolved < samSolved)
        {
            samSolved += samDaily;
            kellySolved += kellyDaily;
            day++;
        }

        Console.WriteLine(
            $"Sam is {difference} problems ahead of Kelly and they solve {samDaily} and {kellyDaily} problems a day. \nAnd Kelly will pass Sam on day {day}."
        );
    }

    public static void Subsequences()
    {
        Console.Write("Array length: ");
        int x = Int32.Parse(Console.ReadLine());
        List<int> numberList = new();

        for (int i = 1; i <= x; i++)
        {
            Console.Write($"Number {i}: ");
            numberList.Add(Int32.Parse(Console.ReadLine()));
        }

        numberList.Sort();
        bool isValid = IsValid(numberList);

        if (isValid)
        {
            Console.WriteLine(
                $"máximum posible length of a valid subsequence is {numberList.Count}."
            );
        }
        else
        {
            List<int> newList = new();
            newList.AddRange(numberList);
            for (int i = 0; i < numberList.Count; i++)
            {
                newList.AddRange(numberList);
                isValid = IsValid(newList);
                if (isValid)
                {
                    Console.WriteLine(
                        $"máximum posible length of a valid subsequence is {newList.Count}."
                    );
                }
            }
        }
    }

    public static bool IsValid(List<int> values)
    {
        int sumOfDiff = 0;
        for (int j = 1; j < values.Count; j++)
        {
            int difference = values[j] - values[j - 1];
            sumOfDiff += difference;
        }
        return sumOfDiff % 2 == 0 ? true : false;
    }
}
