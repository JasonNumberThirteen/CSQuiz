namespace Quiz
{
	class Input
	{
		public int NumberFromInput(Communicator communicator, int min, int max)
		{
			string? s;
			int number;

			if(min > max)
			{
				throw new Exception(Constants.INCORRECT_RANGE_OF_NUMBERS_EXCEPTION_MESSAGE);
			}

			do
			{
				communicator.WriteRequestToTypeNumber(min, max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < min || number > max);

			return number;
		}
	}
}