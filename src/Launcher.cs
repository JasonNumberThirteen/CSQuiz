namespace Quiz
{
	class Launcher
	{
		private readonly JSONQuestionsReader<QuestionDataWithPoints> questionsReader;
		private readonly PointsCounter<QuestionDataWithPoints> pointsCounter;
		private readonly PointsConsoleCommunicator<QuestionDataWithPoints> communicator;
		private readonly KeyboardInput input;
		private readonly Game<QuestionDataWithPoints> game;
		
		public Launcher()
		{
			questionsReader = new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME);
			pointsCounter = new PointsCounter<QuestionDataWithPoints>(questionsReader);
			communicator = new PointsConsoleCommunicator<QuestionDataWithPoints>(pointsCounter);
			input = new KeyboardInput();
			game = new Game<QuestionDataWithPoints>(questionsReader, communicator, input);

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
			game.OnCorrectAnswer += communicator.WriteCorrectAnswer<QuestionDataWithPoints>;
			game.OnCorrectAnswer += delegate(QuestionDataWithPoints qdwp)
			{
				pointsCounter.Points += qdwp.Points;
			};
		}

		private void ConfigureOnWrongAnswerEvent()
		{
			game.OnWrongAnswer += communicator.WriteWrongAnswer<QuestionDataWithPoints>;
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