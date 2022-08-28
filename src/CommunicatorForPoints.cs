namespace Quiz
{
	class CommunicatorForPoints : Communicator
	{
		private PointsCounter pointsCounter;
		
		public CommunicatorForPoints(PointsCounter pointsCounter)
		{
			this.pointsCounter = pointsCounter;
		}

		public void WriteGainedPoints(int gainedPoints, int points) => Console.WriteLine("{0} {1} {2} {3}!\n{0} {4} {5}!", Constants.YOU_HAVE_STRING, Constants.GAINED_STRING, gainedPoints, gainedPoints == 1 ? Constants.POINT_STRING : Constants.POINTS_STRING, points, points == 1 ? Constants.POINT_STRING : Constants.POINTS_STRING);
		public void WriteTotalPoints(int gained, int? max) => Console.WriteLine("{0}: {1}/{2}", Constants.POINTS_STRING.ToUpper(), gained, max);
	}
}