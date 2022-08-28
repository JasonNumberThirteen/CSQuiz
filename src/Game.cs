namespace Quiz
{
	class Game<T> where T : QuestionData
	{
		private readonly Questions<T> questions;
		private readonly Communicator communicator = new Communicator();
		private readonly Input input = new Input();
		private readonly PointsCounter pointsCounter = new PointsCounter();
		
		public Game(string questionsFilename)
		{
			questions = new Questions<T>(questionsFilename);
			
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