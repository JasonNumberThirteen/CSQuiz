namespace Quiz
{
	class QuestionData : IValidatable
	{
		public string? Question {get; set;}
		public string[]? Answers {get; set;}
		public int CorrectAnswer {get; set;}
		public int Points {get; set;}

		public void Validate()
		{
			if(CorrectAnswer > Answers!.Length)
			{
				throw new Exception("Incorrect questions data! The number of correct answer is greater than amount of answers!");
			}
			else if(CorrectAnswer < 1)
			{
				throw new Exception("Incorrect questions data! The number of correct answer is less than 1!");
			}
			else if(Points < 0)
			{
				throw new Exception("Incorrect questions data! The amount of points is negative!");
			}
		}
	}
}