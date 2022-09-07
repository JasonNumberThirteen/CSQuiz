namespace Quiz
{
	public class ConsoleCommunicator : Communicator
	{
		public override void WriteGameTitle() => Console.WriteLine(Constants.GAME_TITLE);
		public override void WriteQuestionHeader<T>(T t, int ordinalNumber) => Console.WriteLine("{0} {1}", Constants.QUESTION_MESSAGE, ordinalNumber);
		public override void WriteQuestion<T>(T t, int ordinalNumber) => Console.WriteLine(t.Question);
		
		public override void WriteAnswers<T>(T t, int ordinalNumber)
		{
			for (int a = 0; a < t.Answers!.Length; ++a)
			{
				WriteAnswer(a + 1, t.Answers[a]);
			}
		}

		public override void WriteAnswer(int number, string answer) => Console.WriteLine("{0}) {1}", number, answer);
		public override void WriteRequestToTypeNumber(int min, int max) => Console.Write("{0} {1} {2} {3} {4}: ", Constants.TYPE_NUMBER_STRING, Constants.FROM_STRING, min, Constants.TO_STRING, max);
		public override void WriteCorrectAnswer<T>(T t) => Console.WriteLine(Constants.CORRECT_ANSWER_MESSAGE);
		public override void WriteWrongAnswer<T>(T t) => Console.WriteLine(Constants.WRONG_ANSWER_MESSAGE);
		public override void WriteEnd() => Console.WriteLine(Constants.GAME_END_MESSAGE);
	}
}