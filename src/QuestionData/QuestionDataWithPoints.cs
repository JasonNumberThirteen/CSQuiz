namespace Quiz
{
	public class QuestionDataWithPoints : QuestionData
	{
		public int Points {get; set;}

		public override void Validate()
		{
			base.Validate();

			if(Points < 0)
			{
				throw new Exception("Incorrect questions data! The amount of points is negative!");
			}
		}
	}
}