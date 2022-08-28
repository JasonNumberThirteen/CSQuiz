namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		internal delegate void GameOnCorrectAnswerDelegate(T t);
		public event GameOnCorrectAnswerDelegate OnCorrectAnswer = delegate {};
		
		private readonly QuestionsReader<T> questionsReader;
		private readonly Communicator communicator = new Communicator();
		private readonly Input input = new Input();
		private readonly PointsCounter pointsCounter = new PointsCounter();
		
		public Game(string questionsFilename)
		{
			questionsReader = new JSONQuestionsReader<T>(questionsFilename);
			
			communicator.WriteGameTitle();
			AddEventToPointsCounter();
			AskQuestions();
			communicator.WriteEnd();
			communicator.WriteTotalPoints(pointsCounter.Points, questionsReader.Data!.Sum<T>(t => t.Points));
		}

		private void AddEventToPointsCounter()
		{
			pointsCounter.OnIncrease += communicator.WriteGainedPoints;
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
				OnCorrectAnswer(t);
			}
		}

		private bool AnsweredCorrectly(T t) => input.NumberFromInput(communicator, new NumbersRange(1, t.Answers!.Length)) == t.CorrectAnswer;
	}
}