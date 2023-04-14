using ProjectAnalizer.Core;

var path = Path.Combine(Environment.CurrentDirectory, "Input");
DirectoryInfo directoryInfo = new DirectoryInfo(path);
if (!directoryInfo.Exists)
{
    directoryInfo.Create();
    Console.WriteLine("Директория создана. Скопируйте файлы для анализа");
    Console.ReadKey(); 
}
else
{
    Counting counting = new Counting();
    counting.pathView(path);
    counting.Watch();
}

