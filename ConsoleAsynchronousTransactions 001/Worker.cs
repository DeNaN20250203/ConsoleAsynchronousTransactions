namespace ConsoleAsynchronousTransactions_001
{
	/// <summary>
	/// Представляет рабочий процесс в многопоточном окружении.
	/// </summary>
	public class Worker
	{
		/// <summary>
		/// Указывает, завершена ли работа. 
		/// Ключевое слово volatile означает, что поле может изменяться несколькими потоками одновременно.
		/// </summary>
		private volatile bool _isComplete;

		/// <summary>
		/// Получает или задает значение, указывающее, завершена ли работа.
		/// </summary>
		public bool IsComplete
		{
			get => _isComplete;
			set => _isComplete = value;
		}

		/// <summary>
		/// Выполняет работу асинхронно.
		/// </summary>
		/// <returns>Task, представляющая асинхронную операцию.</returns>
		public async Task DoWork()
		{
			IsComplete = false;
			Console.WriteLine("Doing work");

			await LongOperation();
			Console.WriteLine();

			Console.WriteLine("Work completed");

			IsComplete = true;
		}

		/// <summary>
		/// Выполняет длительную операцию с асинхронной задержкой.
		/// </summary>
		/// <returns>Task, представляющая асинхронную операцию.</returns>
		private async Task LongOperation()
		{
			Console.WriteLine("Working!");
			await Task.Delay(2000); // Используем асинхронную задержку
		}

		/// <summary>
		/// Печатает точки в консоль, пока работа не будет завершена.
		/// </summary>
		/// <param name="worker">Объект Worker, который выполняет работу.</param>
		/// <returns>Task, представляющая асинхронную операцию.</returns>
		public static async Task PrintPoints(Worker worker)
		{
			while (!worker.IsComplete)
			{
				Console.Write(".");
				await Task.Delay(100);
			}
			Console.WriteLine();
		}
	}
}
