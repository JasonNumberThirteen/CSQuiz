namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		internal delegate void GameOnCorrectAnswerDelegate(T t, bool answeredCorrectly);
		public event GameOnCorrectAnswerDelegate OnCorrectAnswer = delegate {};
		
		private readonly QuestionsReader<T> questionsReader;
		private readonly Communicator communicator = new Communicator();
		private readonly Input input = new Input();
		
		public Game(string questionsFilename)
		{
			questionsReader = new JSONQuestionsReader<T>(questionsFilename);
			
			communicator.WriteGameTitle();
			AskQuestions();
			communicator.WriteEnd();
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