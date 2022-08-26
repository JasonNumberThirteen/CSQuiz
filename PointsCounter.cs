namespace Quiz
{
	internal delegate void PointsCounterOnIncreaseDelegate(int points);
	
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
				points = value;

				if(value > 0 && OnIncrease != null)
				{
					OnIncrease(points);
				}
			}
		}

		private int points = 0;
	}
}