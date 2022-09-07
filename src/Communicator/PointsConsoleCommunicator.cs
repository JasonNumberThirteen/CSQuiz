namespace Quiz
{
	class PointsConsoleCommunicator<T> : PointsCommunicator<T> where T : QuestionDataWithPoints
	{
		public PointsConsoleCommunicator(PointsCounter<T> pointsCounter) : base(pointsCounter)
		{
			
		}

		public override void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("{0} {1} {2} {3}!\n{0} {4} {5}!", PointsConstants.YOU_HAVE_STRING, PointsConstants.GAINED_STRING, gainedPoints, SingularOrPluralPointNoun(gainedPoints), points, SingularOrPluralPointNoun(points));
		public override void WriteTotalPoints() => Console.WriteLine("{0}: {1}/{2}", PointsConstants.POINTS_STRING.ToUpper(), pointsCounter.Points, pointsCounter.MaxPoints);
		public override string SingularOrPluralPointNoun(int value) => value == 1 ? PointsConstants.POINT_STRING : PointsConstants.POINTS_STRING;
	}
}