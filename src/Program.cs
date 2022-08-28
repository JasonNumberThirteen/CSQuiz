namespace Quiz
{
	class Program
	{
		static void Main(string[] args)
		{
			Game<QuestionData> game = new Game<QuestionData>(Constants.QUESTIONS_FILENAME);

			game.Start();
		}
	}
}