using System.Text.Json;

namespace Quiz
{
	class Questions<T> where T : IValidatable
	{
		public List<T>? Data {get; private set;}

		public Questions(string filename)
		{
			GetData(filename);
			Data!.ForEach(d => d.Validate());
		}

		private void GetData(string filename)
		{
			string data = File.ReadAllText(filename);

			Data = JsonSerializer.Deserialize<List<T>>(data);
		}
	}
}