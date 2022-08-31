namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		internal delegate void GameOnStartDelegate();
		internal delegate void GameOnQuestionAskDelegate(T t, int ordinalNumber);
		internal delegate void GameOnCorrectAnswerDelegate(T t);
		internal delegate void GameOnWrongAnswerDelegate(T t);
		internal delegate void GameOnEndDelegate();

		public event GameOnStartDelegate OnStart = delegate {};
		public event GameOnQuestionAskDelegate OnQuestionAsk = delegate {};
		public event GameOnCorrectAnswerDelegate OnCorrectAnswer = delegate {};
		public event GameOnWrongAnswerDelegate OnWrongAnswer = delegate {};
		public event GameOnEndDelegate OnEnd = delegate {};
		
		private readonly QuestionsReader<T> questionsReader;
		private readonly Communicator communicator;
		private readonly Input input;
		
		public Game(QuestionsReader<T> questionsReader, Communicator communicator, Input input)
		{
			this.questionsReader = questionsReader;
			this.communicator = communicator;
			this.input = input;
		}

		public void Start()
		{
			OnStart();
			ConfigureOnQuestionAskEvent();
			AskQuestions();
			OnEnd();
		}

		private void ConfigureOnQuestionAskEvent()
		{
			OnQuestionAsk += communicator.WriteQuestionHeader;
			OnQuestionAsk += communicator.WriteQuestion;
			OnQuestionAsk += communicator.WriteAnswers;
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questionsReader.Data!.Count; ++i)
			{
				T t = questionsReader.Data[i];
				
				OnQuestionAsk(t, i + 1);
				CheckAnswer(t);
				Console.WriteLine();
			}
		}

		private void CheckAnswer(T t)
		{
			if(AnsweredCorrectly(t))
			{
				OnCorrectAnswer(t);
			}
			else
			{
				OnWrongAnswer(t);
			}
		}

		private bool AnsweredCorrectly(T t) => input.NumberFromInput(communicator, new NumbersRange(1, t.Answers!.Length)) == t.CorrectAnswer;
	}
}