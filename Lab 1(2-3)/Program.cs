using nickEnv;

internal class Program
{
    private static void Main(string[] args)
    {
        Time time1 = new Time();

        Console.WriteLine("Введите часы (0-23): ");
        string hInput = Console.ReadLine();
        if (TimeValidator.ValidateHours(hInput, out byte h, out string error))
        {
            time1.Hours = h;
            Console.WriteLine($"Часы установлены в {h}");
        }
        else
        {
            Console.WriteLine(error);
            time1.Hours = 0;
        }

     
        Console.WriteLine("Введите минуты (0-59): ");
        string mInput = Console.ReadLine();
        if (TimeValidator.ValidateMinutes(mInput, out byte m, out string errorMin))
        {
            time1.Minutes = m;
            Console.WriteLine($"Минуты установлены в {m}");
        }
        else
        {
            Console.WriteLine(errorMin);
            time1.Minutes = 0;
        }

       
        Console.WriteLine("Введите количество минут для добавления к time1: ");
        string addInput = Console.ReadLine();
        if (uint.TryParse(addInput, out uint addMinutes))
        {
            Time result = time1.AddMinutes(addMinutes);
            Console.WriteLine($"time1 + {addMinutes} минут = {result}");
        }
        else
        {
            Console.WriteLine("Ошибка: введите целое неотрицательное число");
        }

        Time time2 = new Time(2, 30);
        Time time3 = new Time(time2);
    

        Console.WriteLine("\n--- Вывод времени ---");
        Console.WriteLine("time1: " + time1);
        Console.WriteLine("time2: " + time2);
        Console.WriteLine("time3: " + time3);
       

        Console.WriteLine("\n--- Унарные операции ---");
        Console.WriteLine("++time1: " + ++time1);
        Console.WriteLine("--time1: " + --time1);

        Console.WriteLine("\n--- Операции приведения ---");
        Console.WriteLine("Явное приведение к byte (часы): " + (byte)time1);
        Console.WriteLine("Неявное приведение к bool: " + (time1 ? "true" : "false"));

        Console.WriteLine("\n--- Бинарные операции ---");
        Console.WriteLine("time1 + 70 минут: " + (time1 + 70));
        Console.WriteLine("70 минут + time2: " + (70 + time1));
        Console.WriteLine("time1 - 30 минут: " + (time1 - 30));
       
    }
}