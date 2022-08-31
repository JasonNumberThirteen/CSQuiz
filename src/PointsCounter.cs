namespace Quiz
{
	internal delegate void PointsCounterOnIncreaseDelegate(int gainedPoints, int points);
	
	class PointsCounter<T> where T : QuestionDataWithPoints
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

				if(value > 0)
				{
					OnIncrease(points - previous, points);
				}
			}
		}
		public int MaxPoints
		{
			get
			{
				return maxPoints;
			}
		}

		private int points = 0;
		private int maxPoints;

		public PointsCounter(QuestionsReader<T> questionsReader)
		{
			maxPoints = questionsReader.Data!.Sum<T>(d => d.Points);
		}
	}
}