using ProjectAnalizer.Core;

var standartPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Input");

DirectoryInfo directoryInfo = new DirectoryInfo(standartPath);

if (!directoryInfo.Exists)
{
    directoryInfo.Create();
    Console.WriteLine("Директория создана. Скопируйте файлы для анализа");
    Console.ReadKey();
}
else
{
    Console.WriteLine("Введите путь или будет проанализирована стандартная папка Input: ");
    var userPath = Console.ReadLine();
    if (userPath == "")
    {
        int countFilesAndDirectories = Directory.GetFiles(standartPath, "*", SearchOption.AllDirectories).Length;
        if (countFilesAndDirectories == 0)
        {
            Console.WriteLine("Папка пуста");
        }
        else
        {
            Counting counting = new Counting(countFilesAndDirectories);
            counting.pathView(standartPath);
            WatchingData watchingData = new WatchingData();
            watchingData.OnWatch(counting);
        }
    }
    else
    {
        int countFilesAndDirectories = Directory.GetFiles(userPath, "*", SearchOption.AllDirectories).Length;
        if (countFilesAndDirectories == 0)
        {
            Console.WriteLine("Папка пуста");
        }
        else
        {
            Counting counting = new Counting(countFilesAndDirectories);
            counting.pathView(userPath);
            WatchingData watchingData = new WatchingData();
            watchingData.OnWatch(counting);
        }
    }
}

