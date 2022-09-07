namespace Quiz
{
	public abstract class Communicator
	{
		public abstract void WriteGameTitle();
		public abstract void WriteQuestionHeader<T>(T t, int ordinalNumber) where T : QuestionData;
		public abstract void WriteQuestion<T>(T t, int ordinalNumber) where T : QuestionData;
		public abstract void WriteAnswers<T>(T t, int ordinalNumber) where T : QuestionData;
		public abstract void WriteAnswer(int number, string answer);
		public abstract void WriteRequestToTypeNumber(int min, int max);
		public abstract void WriteCorrectAnswer<T>(T t) where T : QuestionData;
		public abstract void WriteWrongAnswer<T>(T t) where T : QuestionData;
		public abstract void WriteEnd();
	}
}