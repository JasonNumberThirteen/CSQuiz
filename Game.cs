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
		}

		private void GetQuestionsData()
		{
			string data = File.ReadAllText("questions.json");

			questionsData = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}
	}
}