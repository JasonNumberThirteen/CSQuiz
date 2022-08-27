using System.Text.Json;

namespace Quiz
{
	class Questions
	{
		public List<QuestionData>? Data {get; private set;}

		public Questions(string filename)
		{
			GetData(filename);
			ValidateData();
		}

		public void GetData(string filename)
		{
			string data = File.ReadAllText(filename);

			Data = JsonSerializer.Deserialize<List<QuestionData>>(data);
		}

		public void ValidateData()
		{
			foreach (QuestionData qd in Data!)
			{
				if(qd.CorrectAnswer > qd.Answers!.Length)
				{
					throw new Exception("Incorrect questions data! The number of correct answer is greater than amount of answers!");
				}
				else if(qd.CorrectAnswer < 1)
				{
					throw new Exception("Incorrect questions data! The number of correct answer is less than 1!");
				}
				else if(qd.Points < 0)
				{
					throw new Exception("Incorrect questions data! The amount of points is negative!");
				}
			}
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