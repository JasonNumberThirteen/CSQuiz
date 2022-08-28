namespace Quiz
{
	readonly struct NumbersRange : IValidatable
	{
		public readonly int min, max;

		public NumbersRange(int min, int max)
		{
			this.min = min;
			this.max = max;

			Validate();
		}

		public void Validate()
		{
			if(min > max)
			{
				throw new Exception(Constants.INCORRECT_RANGE_OF_NUMBERS_EXCEPTION_MESSAGE);
			}
		}
	}
}