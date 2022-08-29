namespace Quiz
{
	class Launcher
	{
		private readonly JSONQuestionsReader<QuestionDataWithPoints> questionsReader;
		private readonly PointsCounter pointsCounter;
		private readonly PointsCommunicator communicator;
		private readonly Game<QuestionDataWithPoints> game;
		
		public Launcher()
		{
			questionsReader = new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME);
			pointsCounter = new PointsCounter(questionsReader);
			communicator = new PointsCommunicator(pointsCounter);
			game = new Game<QuestionDataWithPoints>(questionsReader, communicator);

			ConfigureEvents();
			game.Start();
		}

		private void ConfigureEvents()
		{
			ConfigureOnStartEvent();
			ConfigureOnCorrectAnswerEvent();
			ConfigureOnWrongAnswerEvent();
			ConfigureOnEndEvent();
			ConfigureOnIncreaseEvent();
		}

		private void ConfigureOnStartEvent()
		{
			game.OnStart += communicator.WriteGameTitle;
		}

		private void ConfigureOnCorrectAnswerEvent()
		{
			game.OnCorrectAnswer += communicator.WriteResult<QuestionDataWithPoints>;
			game.OnCorrectAnswer += delegate(QuestionDataWithPoints qdwp, bool answeredCorrectly)
			{
				pointsCounter.Points += qdwp.Points;
			};
		}

		private void ConfigureOnWrongAnswerEvent()
		{
			game.OnWrongAnswer += communicator.WriteResult<QuestionDataWithPoints>;
		}

		private void ConfigureOnEndEvent()
		{
			game.OnEnd += communicator.WriteEnd;
			game.OnEnd += communicator.WriteTotalPoints;
		}

		private void ConfigureOnIncreaseEvent()
		{
			pointsCounter.OnIncrease += communicator.WriteGainedPoints;
		}
	}
}