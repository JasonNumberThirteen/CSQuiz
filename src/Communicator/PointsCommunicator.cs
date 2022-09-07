namespace Quiz
{
	abstract class PointsCommunicator<T> : ConsoleCommunicator where T : QuestionDataWithPoints
	{
		protected PointsCounter<T> pointsCounter;

		public PointsCommunicator(PointsCounter<T> pointsCounter)
		{
			this.pointsCounter = pointsCounter;
		}

		public abstract void WriteGainedPoints(int gainedPoints, int points);
		public abstract void WriteTotalPoints();
		public abstract string SingularOrPluralPointNoun(int value);
	}
}