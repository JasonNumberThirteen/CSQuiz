namespace Quiz
{
	internal delegate void QuestionDataOnCorrectAnswerDelegate();
	
	class QuestionData : IValidatable
	{
		public event QuestionDataOnCorrectAnswerDelegate OnCorrectAnswer = delegate {};
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
		}
	}
}