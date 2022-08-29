namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		internal delegate void GameOnStartDelegate();
		public event GameOnStartDelegate OnStart = delegate {};
		
		internal delegate void GameOnCorrectAnswerDelegate(T t, bool answeredCorrectly);
		public event GameOnCorrectAnswerDelegate OnCorrectAnswer = delegate {};

		internal delegate void GameOnEndDelegate();
		public event GameOnEndDelegate OnEnd = delegate {};
		
		private readonly QuestionsReader<T> questionsReader;
		private readonly Communicator communicator;
		private readonly Input input = new Input();
		
		public Game(QuestionsReader<T> questionsReader, Communicator communicator)
		{
			this.questionsReader = questionsReader;
			this.communicator = communicator;
		}

		public void Start()
		{
			OnStart();
			AskQuestions();
			OnEnd();
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questionsReader.Data!.Count; ++i)
			{
				T t = questionsReader.Data[i];
				
				communicator.WriteQuestionHeader(i + 1);
				communicator.WriteQuestion(t);
				communicator.WriteAnswers(t);
				CheckAnswer(t);
				Console.WriteLine();
			}
		}

		private void CheckAnswer(T t)
		{
			bool answeredCorrectly = AnsweredCorrectly(t);

			communicator.WriteResult(answeredCorrectly);
			
			if(answeredCorrectly && OnCorrectAnswer != null)
			{
				OnCorrectAnswer(t, answeredCorrectly);
			}
		}

		private bool AnsweredCorrectly(T t) => input.NumberFromInput(communicator, new NumbersRange(1, t.Answers!.Length)) == t.CorrectAnswer;
	}
}