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
				WriteQuestionWithAnswers(qd);
				WriteResult(qd);
				Console.WriteLine();
			}
		}

		private void WriteQuestionWithAnswers(QuestionData qd)
		{
			Console.WriteLine(qd.Question);
			WriteAnswers(qd);
		}

		private void WriteAnswers(QuestionData qd)
		{
			for (int a = 0; a < qd.Answers!.Length; ++a)
			{
				Console.WriteLine("{0}) {1}", a + 1, qd.Answers[a]);
			}
		}

		private void WriteResult(QuestionData qd)
		{
			if(AnsweredCorrectly(qd))
			{
				Console.WriteLine("Correct!");
			}
			else
			{
				Console.WriteLine("Wrong!");
			}
		}

		private bool AnsweredCorrectly(QuestionData qd) => NumberFromInput(1, qd.Answers!.Length) == qd.CorrectAnswer;

		private int NumberFromInput(int min, int max)
		{
			string? s;
			int number;

			do
			{
				Console.Write("Type number from {0} to {1}: ", min, max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < min || number > max);

			return number;
		}
	}
}