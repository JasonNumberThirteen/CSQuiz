namespace Quiz
{
	class Program
	{
		static void Main(string[] args)
		{
			new Game<QuestionData>(Constants.QUESTIONS_FILENAME);
		}
	}
}