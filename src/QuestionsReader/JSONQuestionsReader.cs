using System.Text.Json;

namespace Quiz
{
	class JSONQuestionsReader<T> : QuestionsReader<T> where T : IValidatable
	{
		public JSONQuestionsReader(string filename) : base(filename)
		{

		}

		protected override void GetData(string filename)
		{
			string data = File.ReadAllText(filename);

			Data = JsonSerializer.Deserialize<List<T>>(data);
		}
	}
}