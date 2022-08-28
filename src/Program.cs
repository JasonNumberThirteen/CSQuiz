namespace Quiz
{
	class Program
	{
		static void Main(string[] args)
		{
			Communicator communicator = new Communicator();
			JSONQuestionsReader<QuestionDataWithPoints> questionsReader = new JSONQuestionsReader<QuestionDataWithPoints>(Constants.QUESTIONS_FILENAME);
			Game<QuestionDataWithPoints> game = new Game<QuestionDataWithPoints>(questionsReader, communicator);
			PointsCounter pointsCounter = new PointsCounter(questionsReader);

			game.Start();
		}
	}
}