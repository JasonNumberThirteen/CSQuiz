namespace Quiz
{
	class Communicator
	{
		public void WriteGameTitle() => Console.WriteLine(Constants.GAME_TITLE);
		public void WriteQuestionHeader<T>(T t, int ordinalNumber) where T : QuestionData => Console.WriteLine("{0} {1}", Constants.QUESTION_MESSAGE, ordinalNumber);
		public void WriteQuestion<T>(T t, int ordinalNumber) where T : QuestionData => Console.WriteLine(t.Question);

		public void WriteAnswers<T>(T t, int ordinalNumber) where T : QuestionData
		{
			for (int a = 0; a < t.Answers!.Length; ++a)
			{
				WriteAnswer(a + 1, t.Answers[a]);
			}
		}

		public void WriteRequestToTypeNumber(int min, int max) => Console.Write("{0} {1} {2} {3} {4}: ", Constants.TYPE_NUMBER_STRING, Constants.FROM_STRING, min, Constants.TO_STRING, max);
		public void WriteCorrectAnswer<T>(T t) where T : QuestionData => Console.WriteLine(Constants.CORRECT_ANSWER_MESSAGE);
		public void WriteWrongAnswer<T>(T t) where T : QuestionData => Console.WriteLine(Constants.WRONG_ANSWER_MESSAGE);
		public void WriteEnd() => Console.WriteLine(Constants.GAME_END_MESSAGE);
		
		private void WriteAnswer(int number, string answer) => Console.WriteLine("{0}) {1}", number, answer);
	}
}