using System;
using System.Text.Json;

namespace Quiz
{
	class Game
	{
		public Game()
		{
			Console.WriteLine("QUIZ");

			string data = File.ReadAllText("questions.json");
			List<QuestionData>? questionsData = JsonSerializer.Deserialize<List<QuestionData>>(data);

			foreach (QuestionData qd in questionsData!)
			{
				Console.WriteLine(qd.Question);

				foreach (string answer in qd.Answers!)
				{
					Console.WriteLine("\t{0}", answer);
				}

				Console.WriteLine(qd.CorrectAnswer);
			}
		}
	}
}