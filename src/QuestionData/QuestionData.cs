namespace Quiz
{
	public class QuestionData : IValidatable
	{
		public string? Question {get; set;}
		public string[]? Answers {get; set;}
		public int CorrectAnswer {get; set;}

		public virtual void Validate()
		{
			if(CorrectAnswer > Answers!.Length)
			{
				throw new Exception("Incorrect questions data! The number of correct answer is greater than amount of answers!");
			}
			else if(CorrectAnswer < 1)
			{
				throw new Exception("Incorrect questions data! The number of correct answer is less than 1!");
			}
			else if(string.IsNullOrEmpty(Question) || string.IsNullOrWhiteSpace(Question))
			{
				throw new Exception("Incorrect questions data! The question is empty!");
			}
			else if(Answers!.Any<string>(a => string.IsNullOrEmpty(a) || string.IsNullOrWhiteSpace(a)))
			{
				throw new Exception("Incorrect questions data! The answer is empty!");
			}
		}
	}
}