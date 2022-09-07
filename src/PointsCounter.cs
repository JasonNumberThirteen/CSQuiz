namespace Quiz
{
	public delegate void PointsCounterOnIncreaseDelegate(int gainedPoints, int points);
	
	public class PointsCounter<T> where T : QuestionDataWithPoints
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
				return questionsReader.Data!.Sum<T>(d => d.Points);
			}
		}

		private int points = 0;
		private QuestionsReader<T> questionsReader;

		public PointsCounter(QuestionsReader<T> questionsReader)
		{
			this.questionsReader = questionsReader;
		}
	}
}