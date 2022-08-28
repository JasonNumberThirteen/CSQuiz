namespace Quiz
{
	class CommunicatorForPoints : Communicator
	{
		private PointsCounter pointsCounter;
		
		public CommunicatorForPoints(PointsCounter pointsCounter)
		{
			this.pointsCounter = pointsCounter;
		}
	}
}