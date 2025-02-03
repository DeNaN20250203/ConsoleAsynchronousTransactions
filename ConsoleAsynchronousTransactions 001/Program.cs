namespace ConsoleAsynchronousTransactions_001
{
	internal class Program
    {
        static async Task Main(string[] args)
        {
			// Создаем новый экземпляр класса Worker
			var worker = new Worker();

			// Запускаем асинхронный метод DoWork
			var doWorkTask = worker.DoWork();

			// Запускаем асинхронный метод PrintPoints для вывода точек в консоль
			var printPointsTask = Worker.PrintPoints(worker);

			// Ожидаем завершения обоих задач
			await Task.WhenAll(doWorkTask, printPointsTask);
			Console.WriteLine();
        }
    }
}
