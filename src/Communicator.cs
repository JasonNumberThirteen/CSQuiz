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

		public void WriteRequestToTypeNumber(int min, int max) => Console.Write("{0} {1} {2} {3} {4}: ", Constants.TYPE_NUMBER_STRING, Constants.FROM_STRING, min, Constants.TO_STRING, max);
		public void WriteEnd() => Console.WriteLine(Constants.GAME_END_MESSAGE);
		public void WriteTotalPoints(int gained, int? max) => Console.WriteLine("{0}: {1}/{2}", Constants.POINTS_STRING.ToUpper(), gained, max);
		public void WriteResult(bool answeredCorrectly) => Console.WriteLine(answeredCorrectly ? Constants.CORRECT_ANSWER_MESSAGE : Constants.WRONG_ANSWER_MESSAGE);
		public void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("{0} {1} {2} {3}!\n{0} {4} {5}!", Constants.YOU_HAVE_STRING, Constants.GAINED_STRING, gainedPoints, gainedPoints == 1 ? Constants.POINT_STRING : Constants.POINTS_STRING, points, points == 1 ? Constants.POINT_STRING : Constants.POINTS_STRING);
		private void WriteAnswer(int number, string answer) => Console.WriteLine("{0}) {1}", number, answer);
	}
}