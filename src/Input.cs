namespace Quiz
{
	class Input
	{
		public int NumberFromInput(int min, int max)
		{
			string? s;
			int number;

			do
			{
				Console.Write("{0} {1} {2} {3} {4}: ", Constants.TYPE_NUMBER_STRING, Constants.FROM_STRING, min, Constants.TO_STRING, max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < min || number > max);

			return number;
		}
	}
}