using System.Text.Json;

namespace Quiz
{
	class Questions
	{
		public List<QuestionData>? Data {get; private set;}

		public Questions(string filename)
		{
			GetData(filename);
		}

		public void GetData(string filename)
		{
			string data = File.ReadAllText(filename);

			Data = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}

		public int PointsFromAllQuestions()
		{
			int count = 0;

			foreach (QuestionData qd in Data!)
			{
				count += qd.Points;
			}

			return count;
		}
	}
}