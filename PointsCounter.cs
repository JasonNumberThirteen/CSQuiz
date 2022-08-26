namespace Quiz
{
	internal delegate void PointsCounterOnIncreaseDelegate(int gainedPoints, int points);
	
	class PointsCounter
	{
		public event PointsCounterOnIncreaseDelegate OnIncrease = delegate {};
		public int Points
		{
			get
			{
				return points;
			}
			set
			{
				int previous = points;
				
				points = value;

				if(value > 0 && OnIncrease != null)
				{
					OnIncrease(points - previous, points);
				}
			}
		}

		private int points = 0;
	}
}