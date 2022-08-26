using System;
using System.Text.Json;

namespace Quiz
{
	class Game
	{
		private List<QuestionData>? questionsData;
		private int points = 0;
		
		public Game()
		{
			Console.WriteLine(Constants.GAME_TITLE);
			GetQuestionsData();
			AskQuestions();
			WriteEnd();
		}

		private void GetQuestionsData()
		{
			string data = File.ReadAllText(Constants.QUESTIONS_FILENAME);

			questionsData = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questionsData!.Count; ++i)
			{
				QuestionData qd = questionsData[i];
				
				Console.WriteLine("{0} {1}", Constants.QUESTION_MESSAGE, i + 1);
				WriteQuestionWithAnswers(qd);
				CheckAnswer(qd);
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

		private void CheckAnswer(QuestionData qd)
		{
			bool answeredCorrectly = AnsweredCorrectly(qd);

			WriteResult(answeredCorrectly);
			
			if(answeredCorrectly)
			{
				WritePoints();
			}
		}

		private void WriteResult(bool answeredCorrectly) => Console.WriteLine(answeredCorrectly ? Constants.CORRECT_ANSWER_MESSAGE : Constants.WRONG_ANSWER_MESSAGE);
		private void WritePoints() => Console.WriteLine("{0}\nYou have {1} {2}!", Constants.GAINED_POINT_MESSAGE, ++points, points > 1 ? "points" : "point");

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

		private void WriteEnd()
		{
			Console.WriteLine("{0}\nPOINTS: {1}/{2}", Constants.GAME_END_MESSAGE, points, questionsData?.Count);
		}
	}
}