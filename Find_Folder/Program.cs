using System;
using System.IO;

class Program
{
    static bool FindSubdirectory(string subfolderName, string directory)
    {
        try
        {
            foreach (string subdirectory in Directory.GetDirectories(directory))
            {
                if (Path.GetFileName(subdirectory) == subfolderName)
                {
                    Console.WriteLine($"Знайдено підкаталог: {subdirectory}");
                    return true;
                }
                if (FindSubdirectory(subfolderName, subdirectory))
                {
                    return true;
                }
            }
        }
        catch (UnauthorizedAccessException)
        {
            // Помилка доступу
        }
        catch (DirectoryNotFoundException)
        {
            // Папка не знайдена
        }
        return false;
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8; // Встановлюємо кодировку UTF-8

        Console.Write("Введіть шлях до папки, у якій потрібно шукати: ");
        string directoryPath = Console.ReadLine();

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine($"Папка \"{directoryPath}\" не існує.");
            return;
        }

        Console.Write("Введіть назву підкаталогу: ");
        string subfolderName = Console.ReadLine();

        if (!FindSubdirectory(subfolderName, directoryPath))
        {
            Console.WriteLine($"Підкаталог \"{subfolderName}\" не знайдено у папці \"{directoryPath}\" або її підпапках.");
        }
    }
}
