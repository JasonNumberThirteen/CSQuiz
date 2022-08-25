using System;
using System.Text.Json;

namespace Quiz
{
	class Game
	{
		private List<QuestionData>? questionsData;
		
		public Game()
		{
			Console.WriteLine("QUIZ");
			GetQuestionsData();
			AskQuestions();
		}

		private void GetQuestionsData()
		{
			string data = File.ReadAllText("questions.json");

			questionsData = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questionsData!.Count; ++i)
			{
				QuestionData qd = questionsData[i];
				
				Console.WriteLine("QUESTION {0}", i + 1);
				Console.WriteLine(qd.Question);
			}
		}

		private int NumberFromInput(int min, int max)
		{
			string? s;
			int number;

			do
			{
				Console.WriteLine("Type number from {0} to {1}: ", min, max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < min || number > max);

			return number;
		}
	}
}