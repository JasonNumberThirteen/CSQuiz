namespace Quiz
{
	class Communicator
	{
		public void WriteGameTitle() => Console.WriteLine(Constants.GAME_TITLE);
		public void WriteQuestionHeader(int number) => Console.WriteLine("{0} {1}", Constants.QUESTION_MESSAGE, number);
		public void WriteQuestion(QuestionData qd) => Console.WriteLine(qd.Question);

		public void WriteAnswers(QuestionData qd)
		{
			for (int a = 0; a < qd.Answers!.Length; ++a)
			{
				WriteAnswer(a + 1, qd.Answers[a]);
			}
		}

		public void WriteEnd() => Console.WriteLine(Constants.GAME_END_MESSAGE);
		public void WriteTotalPoints(int gained, int? max) => Console.WriteLine("POINTS: {0}/{1}", gained, max);
		public void WriteResult(bool answeredCorrectly) => Console.WriteLine(answeredCorrectly ? Constants.CORRECT_ANSWER_MESSAGE : Constants.WRONG_ANSWER_MESSAGE);
		public void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("You have gained {0} {1}!\nYou have {2} {3}!", gainedPoints, gainedPoints > 1 ? "points" : "point", points, points > 1 ? "points" : "point");
		private void WriteAnswer(int number, string answer) => Console.WriteLine("{0}) {1}", number, answer);
	}
}