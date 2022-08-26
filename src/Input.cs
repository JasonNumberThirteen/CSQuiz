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
				Console.Write("Type number from {0} to {1}: ", min, max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < min || number > max);

			return number;
		}
	}
}