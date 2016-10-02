using System;
using System.Net;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace HoloComm
{
	public class SparkPostClass
	{
		private string source = "";
		private string target = "";

		private string defaultUrl = "https://api.projectoxford.ai/vision/v1/ocr?language=unk&detectOrientation =true&language=unk&detectOrientation =true";

		public async System.Threading.Tasks.Task<string> SendEmail()
		{

			var httpWebRequest = (HttpWebRequest)WebRequest.Create("https://api.sparkpost.com/api/v1/transmissions");
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/json";
			httpWebRequest.Headers.Add("Authorization", "8c395c016de74a24f22acf60077f1f65f2000fbd");

			using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
			{
				string json = "{\"content\": {\"from\": \"testing@sparkpostbox.com\", \"subject\": \"THIS IS FROM C# YOU LOSER\", \"text\":\"Testing SparkPost - the most awesomest email service in the world\"}, \"recipients\": [{\"address\": \"punhani@usc.edu\"}]}";

				streamWriter.Write(json);
				streamWriter.Flush();
				streamWriter.Close();
			}

			var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			string comp = "\"text\":\"";
			string words = "";
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				var result = streamReader.ReadToEnd();
				for (int i = 0; i < result.Length; i++)
				{
					bool flag = true;
					for (int j = 0; j < comp.Length; j++)
					{
						//Console.Write(comp[j]);
						if (result[i + j] != comp[j])
						{
							//Console.WriteLine();
							flag = false;
							break;
						}
					}
					if (flag)
					{
						//Console.WriteLine(flag);
						i += comp.Length;
						while (result[i] != '\"')
						{
							words += result[i];
							i++;
						}
						words += " ";
					}
				}
			}
			Console.WriteLine(words);
			return words;

		
		}

	}
}
