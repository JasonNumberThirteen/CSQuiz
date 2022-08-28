namespace Quiz
{
	abstract class QuestionsReader<T> where T : IValidatable
	{
		public List<T>? Data {get; set;}
		
		public QuestionsReader(string filename)
		{
			GetData(filename);
		}

		public abstract void GetData(string filename);
	}
}