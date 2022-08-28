namespace Quiz
{
	class Game
	{
		private Questions<QuestionData> questions = new Questions<QuestionData>(Constants.QUESTIONS_FILENAME);
		private Communicator communicator = new Communicator();
		private Input input = new Input();
		private PointsCounter pointsCounter = new PointsCounter();
		
		public Game()
		{
			communicator.WriteGameTitle();
			AddEventToPointsCounter();
			AskQuestions();
			communicator.WriteEnd();
			communicator.WriteTotalPoints(pointsCounter.Points, PointsFromAllQuestions());
		}

		private void AddEventToPointsCounter()
		{
			pointsCounter.OnIncrease += communicator.WriteGainedPoints;
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questions.Data!.Count; ++i)
			{
				QuestionData qd = questions.Data[i];
				
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
				pointsCounter.Points += qd.Points;
			}
		}

		private int PointsFromAllQuestions()
		{
			int count = 0;

			foreach (QuestionData qd in questions.Data!)
			{
				count += qd.Points;
			}

			return count;
		}

		private bool AnsweredCorrectly(QuestionData qd) => input.NumberFromInput(communicator, 1, qd.Answers!.Length) == qd.CorrectAnswer;
	}
}