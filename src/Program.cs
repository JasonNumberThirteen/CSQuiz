namespace Quiz
{
	class Program
	{
		static void Main(string[] args)
		{
			JSONQuestionsReader<QuestionDataWithPoints> questionsReader = new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME);
			PointsCounter pointsCounter = new PointsCounter(questionsReader);
			PointsCommunicator communicator = new PointsCommunicator(pointsCounter);
			Game<QuestionDataWithPoints> game = new Game<QuestionDataWithPoints>(questionsReader, communicator);

			game.OnStart += communicator.WriteGameTitle;

			pointsCounter.OnIncrease += communicator.WriteGainedPoints;

			game.OnCorrectAnswer += communicator.WriteResult<QuestionDataWithPoints>;
			game.OnCorrectAnswer += delegate(QuestionDataWithPoints qdwp, bool answeredCorrectly)
			{
				pointsCounter.Points += qdwp.Points;
			};

			game.OnEnd += communicator.WriteEnd;
			game.OnEnd += communicator.WriteTotalPoints;

			game.Start();
		}
	}
}