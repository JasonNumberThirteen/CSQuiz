using System;
using System.Text.Json;

namespace Quiz
{
	class Game
	{
		private List<QuestionData>? questionsData;
		private Input input = new Input();
		private int points = 0;
		
		public Game()
		{
			WriteGameTitle();
			GetQuestionsData();
			AskQuestions();
			WriteEnd();
			WriteTotalPoints();
		}

		private void WriteGameTitle()
		{
			Console.WriteLine(Constants.GAME_TITLE);
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
				
				WriteQuestionHeader(i + 1);
				WriteQuestion(qd);
				WriteAnswers(qd);
				CheckAnswer(qd);
				Console.WriteLine();
			}
		}

		private void WriteQuestionHeader(int number)
		{
			Console.WriteLine("{0} {1}", Constants.QUESTION_MESSAGE, number);
		}

		private void WriteQuestion(QuestionData qd)
		{
			Console.WriteLine(qd.Question);
		}

		private void WriteAnswers(QuestionData qd)
		{
			for (int a = 0; a < qd.Answers!.Length; ++a)
			{
				WriteAnswer(a + 1, qd.Answers[a]);
			}
		}

		private void WriteAnswer(int number, string answer)
		{
			Console.WriteLine("{0}) {1}", number, answer);
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

		private bool AnsweredCorrectly(QuestionData qd) => input.NumberFromInput(1, qd.Answers!.Length) == qd.CorrectAnswer;

		private void WriteEnd()
		{
			Console.WriteLine(Constants.GAME_END_MESSAGE);
		}

		private void WriteTotalPoints()
		{
			Console.WriteLine("POINTS: {0}/{1}", points, questionsData?.Count);
		}
	}
}