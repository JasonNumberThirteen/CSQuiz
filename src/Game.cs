namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		private Questions<T> questions = new Questions<T>(Constants.QUESTIONS_FILENAME);
		private Communicator communicator = new Communicator();
		private Input input = new Input();
		private PointsCounter pointsCounter = new PointsCounter();
		
		public Game()
		{
			communicator.WriteGameTitle();
			AddEventToPointsCounter();
			AskQuestions();
			communicator.WriteEnd();
			communicator.WriteTotalPoints(pointsCounter.Points, questions.Data!.Sum<T>(t => t.Points));
		}

		private void AddEventToPointsCounter()
		{
			pointsCounter.OnIncrease += communicator.WriteGainedPoints;
		}

		private void AskQuestions()
		{
			for (int i = 0; i < questions.Data!.Count; ++i)
			{
				T t = questions.Data[i];
				
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
			
			if(answeredCorrectly)
			{
				pointsCounter.Points += t.Points;
			}
		}

		private bool AnsweredCorrectly(T t) => input.NumberFromInput(communicator, 1, t.Answers!.Length) == t.CorrectAnswer;
	}
}