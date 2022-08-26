using System.Text.Json;

namespace Quiz
{
	class Questions
	{
		public List<QuestionData>? Data {get; private set;}

		public Questions()
		{
			GetData();
		}

		public void GetData()
		{
			string data = File.ReadAllText(Constants.QUESTIONS_FILENAME);

			Data = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}
	}
}