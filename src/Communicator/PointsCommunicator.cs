namespace Quiz
{
	class PointsCommunicator : Communicator
	{
		private PointsCounter pointsCounter;
		
		public PointsCommunicator(PointsCounter pointsCounter)
		{
			this.pointsCounter = pointsCounter;
		}

		public void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("{0} {1} {2} {3}!\n{0} {4} {5}!", Constants.YOU_HAVE_STRING, Constants.GAINED_STRING, gainedPoints, SingularOrPluralPointNoun(gainedPoints), points, SingularOrPluralPointNoun(points));
		public void WriteTotalPoints() => Console.WriteLine("{0}: {1}/{2}", Constants.POINTS_STRING.ToUpper(), pointsCounter.Points, pointsCounter.MaxPoints);

		private string SingularOrPluralPointNoun(int value) => value == 1 ? Constants.POINT_STRING : Constants.POINTS_STRING;
	}
}