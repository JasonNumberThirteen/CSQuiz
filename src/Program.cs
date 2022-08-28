namespace Quiz
{
	class Program
	{
		static void Main(string[] args)
		{
			Communicator communicator = new Communicator();
			Game<QuestionDataWithPoints> game = new Game<QuestionDataWithPoints>(new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME));
			PointsCounter pointsCounter = new PointsCounter();

			game.Start();
		}
	}
}