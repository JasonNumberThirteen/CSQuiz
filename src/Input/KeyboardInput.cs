namespace Quiz
{
	public class KeyboardInput : Input
	{
		public override int NumberFromInput(Communicator communicator, NumbersRange nr)
		{
			string? s;
			int number;

			do
			{
				communicator.WriteRequestToTypeNumber(nr.min, nr.max);
				
				s = Console.ReadLine();
			}
			while (!int.TryParse(s, out number) || number < nr.min || number > nr.max);

			return number;
		}
	}
}