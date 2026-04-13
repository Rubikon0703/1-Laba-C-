using nickEnv;

internal class Program
{
    private static void Main(string[] args)
    {
        Word w1 = new Word();
        Console.WriteLine("Введите строку: ");
        w1.Text = Console.ReadLine();
        Word w2 = new Word("Привет");
        Word w3 = new Word(w1);
        Console.WriteLine(w1.ToString());
        Console.WriteLine(w2.ToString());
        Console.WriteLine(w3.ToString());
        Console.WriteLine("Первый и последний символ w1: " + w1.FirstLast());
        Console.WriteLine("Введите новую строку для w2:");
        w2.Text = Console.ReadLine();
        Console.WriteLine(w2.ToString());

     
        Password p1 = new Password();
        Password p2 = new Password("qwerty123", 5);
        Password p3 = new Password(p2);

        Console.WriteLine("\n--- Тестирование Password ---");
        Console.WriteLine(p1.ToString());
        Console.WriteLine(p2.ToString());
        Console.WriteLine(p3.ToString());

        Console.WriteLine("Проверка сложности пароля p2: " + p2.CheckStrength());

        p3.SetPassword("newPass", 3);
        Console.WriteLine("После смены пароля: " + p3.ToString());

        p2.Mask();

        Console.WriteLine("Попытка ввода пароля для p2:");
        string attempt = Console.ReadLine();
        p2.Verify(attempt);

        Password.CompareStrength(p1, p2);
    }
}