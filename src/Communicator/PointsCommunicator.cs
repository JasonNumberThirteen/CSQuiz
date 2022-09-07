namespace Quiz
{
	class PointsCommunicator<T> : ConsoleCommunicator where T : QuestionDataWithPoints
	{
		private PointsCounter<T> pointsCounter;
		
		public PointsCommunicator(PointsCounter<T> pointsCounter)
		{
			this.pointsCounter = pointsCounter;
		}

		public void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("{0} {1} {2} {3}!\n{0} {4} {5}!", PointsConstants.YOU_HAVE_STRING, PointsConstants.GAINED_STRING, gainedPoints, SingularOrPluralPointNoun(gainedPoints), points, SingularOrPluralPointNoun(points));
		public void WriteTotalPoints() => Console.WriteLine("{0}: {1}/{2}", PointsConstants.POINTS_STRING.ToUpper(), pointsCounter.Points, pointsCounter.MaxPoints);

		private string SingularOrPluralPointNoun(int value) => value == 1 ? PointsConstants.POINT_STRING : PointsConstants.POINTS_STRING;
	}
}