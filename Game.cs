using System;
using System.Text.Json;

namespace Quiz
{
	class Game
	{
		private List<QuestionData>? questionsData;
		private Communicator communicator = new Communicator();
		private Input input = new Input();
		private int points = 0;
		
		public Game()
		{
			communicator.WriteGameTitle();
			GetQuestionsData();
			AskQuestions();
			communicator.WriteEnd();
			communicator.WriteTotalPoints(points, questionsData?.Count);
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
				
				communicator.WriteQuestionHeader(i + 1);
				communicator.WriteQuestion(qd);
				communicator.WriteAnswers(qd);
				CheckAnswer(qd);
				Console.WriteLine();
			}
		}

		private void CheckAnswer(QuestionData qd)
		{
			bool answeredCorrectly = AnsweredCorrectly(qd);

			communicator.WriteResult(answeredCorrectly);
			
			if(answeredCorrectly)
			{
				communicator.WritePoints(++points);
			}
		}

		private bool AnsweredCorrectly(QuestionData qd) => input.NumberFromInput(1, qd.Answers!.Length) == qd.CorrectAnswer;
	}
}